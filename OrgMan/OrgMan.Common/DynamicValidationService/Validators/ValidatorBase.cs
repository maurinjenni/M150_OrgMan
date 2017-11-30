using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using FluentValidation;
using Newtonsoft.Json;
using OrgMan.Common.DynamicValidationService.DynamicValidationModel;
using OrgMan.Common.DynamicValidationService.DynamicValidationModel.Enum;
using OrgMan.Common.LinqExpressionService;

namespace OrgMan.Common.DynamicValidationService.Validators
{
    public class ValidatorBase<T> : AbstractValidator<T>
    {
        private ILinqExpressionService<T> _linqExpressionService;

        public ValidatorBase(ILinqExpressionService<T> linqExpressionService)
        {
            _linqExpressionService = linqExpressionService;
        }

        public void CreateValidations(string jsonPath)
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
                        CreateValidationsForList(property);
                    }
                    else
                    {
                        CreateValidationsForField(property);
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

        private void CreateValidationsForList(DynamicValidationProperty property)
        {
            throw new NotImplementedException();
        }

        private void CreateValidationsForField(DynamicValidationProperty property)
        {
            var propertyExpression = _linqExpressionService.GetParameterExpression(typeof(T), property.PropertyName);

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

            if (propertyExpression.Type == typeof(string))
            {
                Expression<Func<T, string>> stringExpression = ExpressionTostringExpression(propertyExpression);

                CreateValidationsForString(stringExpression, property.ValidationCriterias);
            }

            if (propertyExpression.Type == typeof(int))
            {
                Expression<Func<T, int>> intExpression = ExpressionToIntExpression(propertyExpression);

                CreateValidationsForInt(intExpression, property.ValidationCriterias);

            }
        }

        private void CreateValidationsForString(Expression<Func<T, string>> stringExpression,
            List<DynamicValidationCriteria> validationCriterias)
        {
            foreach (var validationCriteria in validationCriterias)
            {
                switch (validationCriteria.CriteriaType)
                {
                    case CriteriaTypeEnum.MinLength:
                        RuleFor(stringExpression).MinimumLength((int) validationCriteria.Value);
                        break;
                    case CriteriaTypeEnum.MaxLength:
                        RuleFor(stringExpression).MaximumLength((int) validationCriteria.Value);
                        break;
                    case CriteriaTypeEnum.Length:
                        RuleFor(stringExpression).Length((int)validationCriteria.Value);
                        break;
                    case CriteriaTypeEnum.EmailAdress:
                        RuleFor(stringExpression).EmailAddress();
                        break;
                    case CriteriaTypeEnum.PhoneNumber:
                        RuleFor(stringExpression).Matches("");
                        break;
                    case CriteriaTypeEnum.Uri:
                        RuleFor(stringExpression).Matches("");
                        break;
                    case CriteriaTypeEnum.Regex:
                        RuleFor(stringExpression).Matches((string) validationCriteria.Value);
                        break;
                    default:
                        throw new Exception("Invalid CriteriaType");
                }
            }
        }

        private void CreateValidationsForInt(Expression<Func<T, int>> stringExpression,
            List<DynamicValidationCriteria> validationCriterias)
        {
            foreach (var validationCriteria in validationCriterias)
            {
                switch (validationCriteria.CriteriaType)
                {
                    case CriteriaTypeEnum.LessThan:
                        RuleFor(stringExpression).LessThan((int)validationCriteria.Value);
                        break;
                    case CriteriaTypeEnum.LessThanOrEquals:
                        RuleFor(stringExpression).LessThanOrEqualTo((int)validationCriteria.Value);
                        break;
                    case CriteriaTypeEnum.GreaterThan:
                        RuleFor(stringExpression).GreaterThan((int)validationCriteria.Value);
                        break;
                    case CriteriaTypeEnum.GreaterThanOrEqual:
                        RuleFor(stringExpression).GreaterThanOrEqualTo((int)validationCriteria.Value);
                        break;
                    case CriteriaTypeEnum.ExclusiveBetween:
                        RuleFor(stringExpression).ExclusiveBetween(Convert.ToInt32(((string)validationCriteria.Value).Split('-')[0]), Convert.ToInt32(((string)validationCriteria.Value).Split('-')[2]));
                        break;
                    case CriteriaTypeEnum.InclusiveBetween:
                        RuleFor(stringExpression).InclusiveBetween(Convert.ToInt32(((string)validationCriteria.Value).Split('-')[0]), Convert.ToInt32(((string)validationCriteria.Value).Split('-')[2]));
                        break;
                    default:
                        throw new Exception("Invalid CriteriaType");
                }
            }
        }

        private Expression<Func<T, string>> ExpressionTostringExpression(Expression<Func<T, object>> func)
        {
            ParameterExpression parameter = Expression.Parameter(func.GetType());

            MemberExpression member = Expression.Property(parameter, "");

            LambdaExpression lambda = Expression.Lambda(func.GetType(), member);

            return (Expression<Func<T, string>>)lambda;
        }

        private Expression<Func<T, int>> ExpressionToIntExpression(Expression<Func<T, object>> func)
        {
            ParameterExpression parameter = Expression.Parameter(func.GetType());

            MemberExpression member = Expression.Property(parameter, "");

            LambdaExpression lambda = Expression.Lambda(func.GetType(), member);

            return (Expression<Func<T, int>>)lambda;
        }
    }
}