using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace OrgMan.API.HttpModule
{
    public class InputValidation : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += (ValidateInput);
        }

        public void Dispose()
        {
            
        }

        static RegexOptions _defaultRegexOptions = RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace;

        RegexWithDesc[] _regexCollection = new RegexWithDesc[]
        {
                    new RegexWithDesc(@"((¼|<)[^\n]+(>|¾)*)|javascript|unescape", _defaultRegexOptions, "XSS"), //3.3
                    new RegexWithDesc(@"(\')|(\-\-)", _defaultRegexOptions, "SQL Injection"), //2.1
                    new RegexWithDesc(@"(=)[^\n]*(\'|(\-\-)|(;))", _defaultRegexOptions, "SQL Injection"),    //2.2
                    new RegexWithDesc(@"\w*(\')(or)", _defaultRegexOptions, "SQL Injection"),  //2.3
                    new RegexWithDesc(@"(\')\s*(or|union|insert|delete|drop|update|create|(declare\s+@\w+))", _defaultRegexOptions, "SQL Injection"),   //2.4
                    new RegexWithDesc(@"exec(((\s|\+)+(s|x)p\w+)|(\s@))", _defaultRegexOptions, "SQL Injection")    //2.5
        };

        private void ValidateInput(object sender, EventArgs e)
        {
            List<string> toCheck = new List<string>();

            foreach (string key in HttpContext.Current.ApplicationInstance.Request.QueryString.AllKeys)
            {
                toCheck.Add(HttpContext.Current.ApplicationInstance.Request[key]);
            }
            foreach (string key in HttpContext.Current.ApplicationInstance.Request.Form.AllKeys)
            {
                toCheck.Add(HttpContext.Current.ApplicationInstance.Request.Form[key]);
            }

            foreach (RegexWithDesc regex in _regexCollection)
            {
                foreach (string param in toCheck)
                {
                    string dp = HttpUtility.UrlDecode(param);
                    if (regex.IsMatch(dp))
                    {
                        HttpContext.Current.Response.Clear();
                        HttpContext.Current.Response.ClearHeaders();

                        HttpContext.Current.Response.StatusCode = 403;
                        HttpContext.Current.Response.Write(regex.ErrorText);
                        HttpContext.Current.Response.Flush();

                        HttpContext.Current.ApplicationInstance.CompleteRequest();
                        return;
                    }
                }
            }
        }
    }

    public class RegexWithDesc : Regex
    {
        string _errorText;

        public string ErrorText
        {
            get { return _errorText; }
        }

        public RegexWithDesc(string regex, RegexOptions options, string errorText)
            : base(regex, options)
        {
            _errorText = errorText;
        }
    }
}