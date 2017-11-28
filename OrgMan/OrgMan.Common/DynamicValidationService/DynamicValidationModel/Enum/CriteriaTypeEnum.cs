using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.Common.DynamicValidationService.DynamicValidationModel.Enum
{
    public enum CriteriaTypeEnum
    {
        NotNull, // DONE
        NotEmpty, // DONE
        NotNullOrEmpty, // DONE
        Equal,// DONE
        NotEqual,// DONE
        MinLength,// DONE
        MaxLength,// DONE
        Length,// DONE
        LessThan,// DONE
        LessThanOrEquals,// DONE
        GreaterThan,// DONE
        GreaterThanOrEqual,// DONE
        ExclusiveBetween, // DONE
        InclusiveBetween,// DONE
        EmailAdress, // DONE
        PhoneNumber,// DONE
        Uri,// DONE
        Regex// DONE
    }
}
