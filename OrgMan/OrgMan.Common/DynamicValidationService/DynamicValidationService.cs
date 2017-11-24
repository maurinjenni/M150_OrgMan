using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using OrgMan.Common.DynamicValidationService.Validators;
using OrgMan.DataModel;

namespace OrgMan.Common.DynamicValidationService
{
    public class DynamicValidationService<T>
    {
        private readonly PersonValidator personValidator;
        public bool Validate(T obj)
        {
            IDictionary<Type,Delegate> typeofProcessMap = new Dictionary<Type, Delegate>
            {
                {typeof(Person), new Action<Person>(p =>
                    {
                        personValidator.Validate((Person)obj);
                    
                    })
                },
                {typeof(Meeting), new Action<Meeting>(m =>
                    {
                        
                    })
                }
            };

            typeofProcessMap[typeof(T)].DynamicInvoke(obj);

            return true;
        }
    }
}

