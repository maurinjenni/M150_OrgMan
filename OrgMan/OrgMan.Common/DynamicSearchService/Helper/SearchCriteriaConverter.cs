using OrgMan.Common.DynamicSearchService.DynamicSearchModel;
using OrgMan.Common.DynamicSearchService.DynamicSearchModel.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace OrgMan.Common.DynamicSearchService.Helper
{
    public class SearchCriteriaConverter
    {
        public static List<SearchCriteriaDomainModel> Convert(List<SearchCriteriaDomainModel> searchCriterias)
        {
            foreach (var searchCriteria in searchCriterias)
            {
                var searchCriteriavalues = new List<object>();

                foreach (var value in searchCriteria.Values)
                {
                    switch (searchCriteria.DataType)
                    {
                        // 1
                        case SearchCriteriaDataTypeDomainModelEnum.Boolean:
                            searchCriteriavalues.Add(ConvertSearchCriteria<bool>(value));
                            break;

                        // 2
                        case SearchCriteriaDataTypeDomainModelEnum.DateTime:
                            searchCriteriavalues.Add(ConvertSearchCriteria<DateTime>(value));
                            break;

                        // 3
                        case SearchCriteriaDataTypeDomainModelEnum.Float:
                            searchCriteriavalues.Add(ConvertSearchCriteria<float>(value));
                            break;

                        // 4
                        case SearchCriteriaDataTypeDomainModelEnum.Int:
                            searchCriteriavalues.Add(ConvertSearchCriteria<int>(value));
                            break;

                        // 5
                        case SearchCriteriaDataTypeDomainModelEnum.String:
                            // Guid transmited as String
                            Guid guidValue;

                            // if Guid else String
                            if (Guid.TryParse(value.ToString(), out guidValue))
                            {
                                searchCriteriavalues.Add(ConvertSearchCriteria<Guid>(guidValue));
                            }
                            else
                            {
                                searchCriteriavalues.Add(value.ToString());
                            }

                            break;

                        // 6
                        case SearchCriteriaDataTypeDomainModelEnum.Decimal:
                            searchCriteriavalues.Add(ConvertSearchCriteria<decimal>(value));
                            break;
                    }
                }

                searchCriteria.Values = searchCriteriavalues;
            }

            return searchCriterias;
        }

        private static T ConvertSearchCriteria<T>(object value)
        {
            try
            {
                // Converter... will be used to Convert the values into the spesific datatype
                var converter = TypeDescriptor.GetConverter(typeof(T));

                // Make each value to a string
                var stringValue = value.ToString();

                // Need to consider Culture Info by a Decimal value
                if (typeof(T) == typeof(decimal))
                {
                    // Other Locations
                    stringValue = stringValue.Replace(",", ".");

                    // Convert the value
                    return (T)converter.ConvertFromString(null, System.Globalization.CultureInfo.InvariantCulture, stringValue);
                }

                // Convert the value
                return (T)converter.ConvertFromString(stringValue);
            }
            catch (Exception ex)
            {
                throw new FormatException(ex.Message);
            }
        }
    }
}
