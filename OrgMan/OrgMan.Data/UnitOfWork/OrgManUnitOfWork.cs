using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrgMan.DataModel;

namespace OrgMan.Data.UnitOfWork
{
    public class OrgManUnitOfWork
    {
        private readonly OrgManEntities _context;

        public OrgManUnitOfWork(OrgManEntities context)
        {
            _context = context;
        }

        public void Commit()
        {
            bool saveFailed;
            do
            {
                saveFailed = false;

                try
                {
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;

                    var entry = ex.Entries.Single();
                    entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                }

            } while (saveFailed);
        }
    }
}
