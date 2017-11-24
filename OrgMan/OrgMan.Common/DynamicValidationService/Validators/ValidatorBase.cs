using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Newtonsoft.Json;
using OrgMan.Common.DynamicValidationService.DynamicValidationModel;
using OrgMan.Common.DynamicValidationService.DynamicValidationModel.Enum;

namespace OrgMan.Common.DynamicValidationService.Validators
{
    public class ValidatorBase<T> : AbstractValidator<T>
    {
        public ValidatorBase(string jsonPath)
        {
            DynamicValidationType validationType = ReadValidationTypeFromJson(jsonPath);

            if (validationType.Type != nameof(T))
            {
                throw new Exception("ValidationType.Type in JSON file does not fit with Object Type");
            }

            if (validationType.Properties.Any())
            {
                foreach (var property in validationType.Properties)
                {
                    bool propertyIsList = typeof(T) == typeof(List<object>) || typeof(T) == typeof(IEnumerable<object>);

                    if (propertyIsList)
                    {
                        throw new NotImplementedException();

                        var propertyListExpression = GetExpressionForPropertyList(property);

                        if (!property.AllowNullOrEmpty)
                        {
                            RuleFor(propertyListExpression).NotNull().NotEmpty();
                        }
                    }
                    else
                    {
                        var propertyExpression = GetExpressionForProperty(property);

                        var propertyIsString = propertyExpression.Type == typeof(string);

                        if (!property.AllowNullOrEmpty)
                        {
                            RuleFor(propertyExpression).NotNull().NotEmpty();
                        }

                        foreach (var validationCriteria in property.ValidationCriterias)
                        {
                            switch (validationCriteria.CriteriaType)
                            {

                                case CriteriaTypeEnum.NotNull:
                                    RuleFor(propertyExpression).NotNull();
                                    break;
                                case CriteriaTypeEnum.NotEmpty:
                                    RuleFor(propertyExpression).NotEmpty();
                                    break;
                                case CriteriaTypeEnum.NotNullOrEmpty:
                                    RuleFor(propertyExpression).NotNull().NotEmpty();
                                    break;
                                case CriteriaTypeEnum.Equal:
                                    RuleFor(propertyExpression).Equal(validationCriteria.Value);
                                    break;
                                case CriteriaTypeEnum.NotEqual:
                                    RuleFor(propertyExpression).NotEqual(validationCriteria.Value);
                                    break;
                                default:
                                    throw new Exception("Invalid CriteriaType");

                            }
                        }
                    }
                }
            }
        }

        private DynamicValidationType ReadValidationTypeFromJson(string jsonPath)
        {
            if (string.IsNullOrEmpty(jsonPath))
            {
                throw new ArgumentNullException(nameof(jsonPath));
            }

            using (StreamReader r = new StreamReader(jsonPath))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<DynamicValidationType>(json);
            }
        }

        private Expression<Func<T, object>> GetExpressionForProperty(DynamicValidationProperty dynamicValidationProperty)
        {
            throw new NotImplementedException();

            return null;
        }

        private Expression<Func<T, IEnumerable<object>>> GetExpressionForPropertyList(
            DynamicValidationProperty dynamicValidationProperty)
        {
            throw new NotImplementedException();
            return null;
        }
    }
}