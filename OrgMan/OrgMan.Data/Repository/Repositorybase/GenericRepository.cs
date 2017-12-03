using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using OrgMan.DataContracts.Repository.RepositoryBase;
using OrgMan.DataModel;

namespace OrgMan.Data.Repository.Repositorybase
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntityUID
    {
        internal OrgManEntities Context;
        internal DbSet<TEntity> DbSet;

        public GenericRepository(OrgManEntities context)
        {
            Context = context;
            DbSet = Context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(
            Guid mandatorUid,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "",
            int? numberOfRows = null)
        {
            IQueryable<TEntity> query = DbSet;

            //query = query.Where(d => d.MandatorUID == mandatorUid);

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            if (numberOfRows != null)
            {
                query = query.Take(numberOfRows.Value);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public virtual TEntity Get(Guid mandatorUid, Guid uid)
        {
            return DbSet.Where(t => t.MandatorUID == mandatorUid).FirstOrDefault(t => t.UID == uid);
        }

        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Delete(Guid mandatorUid, Guid uid)
        {
            TEntity entityToDelete = DbSet.Find(uid);

            if (entityToDelete != null)
            {
                if (entityToDelete.MandatorUID != mandatorUid)
                {
                    throw new Exception("Trying to delete Entity with false Mandator : " + uid);
                }

                if (Context.Entry(entityToDelete).State == EntityState.Detached)
                {
                    DbSet.Attach(entityToDelete);
                }
                DbSet.Remove(entityToDelete);
            }
            else
            {
                throw new Exception("No Entity found to UID : " + uid);
            }

        }

        public virtual void Delete(Guid mandatorUid, TEntity entityToDelete)
        {
            if (entityToDelete.MandatorUID != mandatorUid)
            {
                throw new Exception("Trying to delete Entity with false Mandator : " + entityToDelete.UID);
            }

            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }

        public virtual void Update(Guid mandatorUid, TEntity entityToUpdate)
        {
            if (entityToUpdate.MandatorUID != mandatorUid)
            {
                throw new Exception("Trying to delete Entity with false Mandator : " + entityToUpdate.UID);
            }

            DbSet.Attach(entityToUpdate);

            var entry = Context.Entry(entityToUpdate);

            entry.Property(x => x.SysInsertAccountUID).IsModified = false;
            entry.Property(x => x.SysInsertTime).IsModified = false;


            entry.State = EntityState.Modified;
        }
    }
}
