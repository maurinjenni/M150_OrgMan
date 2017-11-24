using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.Common.DynamicValidationService.DynamicValidationModel.Enum
{
    public enum CriteriaTypeEnum
    {
        NotNull,
        NotEmpty,
        NotNullOrEmpty,
        Equal,
        NotEqual,
        MinLength,
        MaxLength,
        Length,
        LessThan,
        LessThanOrEquals,
        GreatherThan,
        GreatherThanOrEquals,
        ExclusiveBetween,
        InclusiveBetween,
        EmailAdress,
        PhoneNumber,
        Uri
    }
}
