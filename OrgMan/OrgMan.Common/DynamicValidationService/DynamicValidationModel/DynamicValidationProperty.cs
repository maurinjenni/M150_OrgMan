using System.Collections.Generic;

namespace OrgMan.Common.DynamicValidationService.DynamicValidationModel
{
    public class DynamicValidationProperty
    {
        public string PropertyName { get; set; }

        public bool Editable { get; set; }

        public bool AllowNullOrEmpty { get; set; }

        public List<DynamicValidationCriteria> ValidationCriterias { get; set; }
    }
}
