using System.Collections.Generic;

namespace OrgMan.Common.DynamicValidationService.DynamicValidationModel
{
    public class DynamicValidationType
    {
        public string Type { get; set; }

        public List<DynamicValidationProperty> Properties { get; set; }
    }
}
