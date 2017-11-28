using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrgMan.Common.LinqExpressionService;
using OrgMan.DataModel;

namespace OrgMan.Common.DynamicValidationService.Validators
{
    public class MeetingValidator : ValidatorBase<Meeting>
    {
        public MeetingValidator(ILinqExpressionService<Meeting> linqExpressionService) : base(linqExpressionService)
        {
            CreateValidations("");
            AddFluentValidations();
        }

        private void AddFluentValidations()
        {

        }
    }
}
