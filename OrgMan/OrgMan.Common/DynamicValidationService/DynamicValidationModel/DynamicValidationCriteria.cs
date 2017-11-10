using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrgMan.Common.DynamicValidationService.DynamicValidationModel.Enum;

namespace OrgMan.Common.DynamicValidationService.DynamicValidationModel
{
    public class DynamicValidationCriteria
    {
        public CriteriaTypeEnum CriteriaType { get; set; }

        public object Value { get; set; }
    }
}
