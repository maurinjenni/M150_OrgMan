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

        TEntity Get(List<Guid> mandatorUid, Guid uid);

        TEntity Get(Guid uid);

        void Insert(List<Guid> mandatorUid, TEntity entity);

        void Insert(TEntity entity);

        void Delete(List<Guid> mandatorUid, Guid uid);

        void Delete(List<Guid> mandatorUid, TEntity entityToDelete);

        void Delete(Guid uid);

        void Delete(TEntity entityToDelete);

        bool Update(List<Guid> mandatorUid, TEntity entityToUpdate);

        bool Update(TEntity entityToUpdate);
    }
}
