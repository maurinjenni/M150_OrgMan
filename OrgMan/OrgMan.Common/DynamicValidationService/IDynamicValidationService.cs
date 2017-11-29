using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrgMan.Common.DynamicValidationService
{
    public interface IDynamicValidationService<T>
    {
        bool Validate(T obj);
    }
}
