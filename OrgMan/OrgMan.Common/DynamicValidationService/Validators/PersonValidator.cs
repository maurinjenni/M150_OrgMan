using OrgMan.Common.LinqExpressionService;
using OrgMan.DataModel;

namespace OrgMan.Common.DynamicValidationService.Validators
{
    public class PersonValidator : ValidatorBase<Person>
    {
        public PersonValidator(ILinqExpressionService<Person> linqExpressionService) : base(linqExpressionService)
        {
            CreateValidations("");
            AddFluentValidations();
        }

        private void AddFluentValidations()
        {
            
        }
    }
}
