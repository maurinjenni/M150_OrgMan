using OrgMan.Common.DynamicValidationService.DynamicValidationModel.Enum;

namespace OrgMan.Common.DynamicValidationService.DynamicValidationModel
{
    public class DynamicValidationCriteria
    {
        public CriteriaTypeEnum CriteriaType { get; set; }

        public object Value { get; set; }
    }
}
