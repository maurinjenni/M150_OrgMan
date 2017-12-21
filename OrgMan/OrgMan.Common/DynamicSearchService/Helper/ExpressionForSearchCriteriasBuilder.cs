using OrgMan.Common.DynamicSearchService.DynamicSearchModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OrgMan.Common.DynamicSearchService.Helper
{
    public class ExpressionForSearchCriteriasBuilder
    {
        public static Expression GetExpression(List<SearchCriteriaDomainModel> searchCriterias, ParameterExpression parameter)
        {

            Expression dynamicLinqExpression = null;

            foreach (var searchCriteria in searchCriterias)
            {
                if (dynamicLinqExpression == null)
                {
                    // First SearchCriterias... has to create an new Expression
                    dynamicLinqExpression = CreateExpressionForCriteria(parameter, searchCriteria);
                }
                else
                {
                    // Next SearchCriterias... Expression already Exists... need to append Expression
                    dynamicLinqExpression = Expression.AndAlso(dynamicLinqExpression, CreateExpressionForCriteria(parameter, searchCriteria));
                }
            }

            return dynamicLinqExpression;
        }

        private static Expression CreateExpressionForCriteria(ParameterExpression parameter,
            SearchCriteriaDomainModel searchCriteria)
        {
            var isCriteriaCollection = false;
            var constants = new List<ConstantExpression>();
            var allFieldParts = searchCriteria.FieldName.Split('.').ToList();

            //MemberExpression member = null;
            var member = Expression.Property(parameter, allFieldParts.First());
            allFieldParts.Remove(allFieldParts.First());

            Expression expression = null;

            if (allFieldParts.Count > 0)
            {
                foreach (string searchFieldPart in allFieldParts)
                {
                    // is Type a Collection
                    if (typeof(IEnumerable).IsAssignableFrom(member.Type) && member.Type != typeof(string))
                    {
                        isCriteriaCollection = true;
                        expression = GetCollectionExpression(parameter.Type,
                            member.Type.GenericTypeArguments.First(), parameter, allFieldParts[allFieldParts.IndexOf(searchFieldPart) - 1],
                            searchCriteria);
                    }
                    else
                    {
                        member = Expression.Property(member, searchFieldPart);
                    }
                }

                // When no Collection
                if (!isCriteriaCollection)
                {
                    // Add values
                    foreach (var value in searchCriteria.Values)
                    {
                        constants.Add(Expression.Constant(value));
                    }

                    expression = ExpressionCreator.GetExpression(searchCriteria.OperationType, member, constants);
                }
            }
            else
            {
                // Add values
                foreach (var value in searchCriteria.Values)
                {
                    constants.Add(Expression.Constant(value));
                }

                expression = ExpressionCreator.GetExpression(searchCriteria.OperationType, member, constants);
            }

            return expression;
        }

        private static Expression GetCollectionExpression(Type mainEntityType, Type subEntityType, ParameterExpression mainType,
            string collectionProperty, SearchCriteriaDomainModel searchCriteria)
        {
            if (mainEntityType == null)
            {
                throw new NullReferenceException(nameof(mainEntityType));
            }

            if (subEntityType == null)
            {
                throw new NullReferenceException(nameof(subEntityType));
            }

            var fieldName = searchCriteria.FieldName.Split('.').Last();

            var constants = new List<ConstantExpression>();
            var baseTypeSubEntity = Expression.Parameter(subEntityType, "s");

            if (fieldName != null)
            {
                Expression member = Expression.Property(baseTypeSubEntity, subEntityType.GetProperty(fieldName));

                // add Value
                foreach (var value in searchCriteria.Values)
                {
                    constants.Add(Expression.Constant(value));
                }

                // Lambda for Subentities
                var innerWhereExpression = ExpressionCreator.GetExpression(searchCriteria.OperationType, member, constants);
                var innerWhereFunction = Expression.Lambda(innerWhereExpression, baseTypeSubEntity);

                var methodWithAnySelection =
                    typeof(Enumerable).GetMethods()
                        .Single(m => m.Name == "Any" && m.GetParameters().Length == 2)
                        .MakeGenericMethod(subEntityType);

                if (collectionProperty != null)
                {
                    var whereExpressionOnCollectionProperty = Expression.Call(methodWithAnySelection,
                        Expression.Property(mainType, mainEntityType.GetProperty(collectionProperty)), innerWhereFunction);

                    return whereExpressionOnCollectionProperty;
                }

                throw new NullReferenceException(nameof(collectionProperty));
            }

            throw new NullReferenceException(nameof(fieldName));
        }
    }
}
