using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrgMan.DataModel;

namespace OrgMan.Common.DynamicValidationService.Validators
{
    public class PersonValidator : ValidatorBase<Person>
    {
        public PersonValidator() : base("")
        {
            
            AddFluentValidations();
        }

        private void AddFluentValidations()
        {

        }
    }
}
