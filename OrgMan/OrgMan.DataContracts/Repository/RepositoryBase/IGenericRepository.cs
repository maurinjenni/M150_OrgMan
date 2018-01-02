using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OrgMan.DataContracts.Repository.RepositoryBase
{
    public interface IGenericRepository<TEntity>
    {
        IEnumerable<TEntity> Get(
    List<Guid> mandatorUid,
    Expression<Func<TEntity, bool>> filter = null,
    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
    string includeProperties = "", int? numberOfRows = null);

        TEntity Get(Guid uid);

        void Insert(TEntity entity);

        void Delete(Guid uid);

        void Delete(TEntity entityToDelete);

        void Update(TEntity entityToUpdate);
    }
}
