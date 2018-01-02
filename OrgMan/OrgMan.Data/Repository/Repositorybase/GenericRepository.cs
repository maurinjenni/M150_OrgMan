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
            List<Guid> mandatorUids,
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "",
            int? numberOfRows = null)
        {
            IQueryable<TEntity> query = DbSet;

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

            if (orderBy != null)
            {
                query =  orderBy(query);
            }
            
            var list =  query.ToList();

            if (mandatorUids != null)
            {
                list = list.Where(q => q.MandatorUIDs != null && mandatorUids.Intersect(q.MandatorUIDs).Any()).ToList();
            }

            if (numberOfRows != null)
            {
                list = list.Take(numberOfRows.Value).ToList();
            }

            return list;
        }

        public virtual TEntity Get(Guid uid)
        {
            //return DbSet.Where(t => t.MandatorUID == mandatorUid).FirstOrDefault(t => t.UID == uid);

            return DbSet.FirstOrDefault(t => t.UID == uid);
        }

        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Delete(Guid uid)
        {
            TEntity entityToDelete = DbSet.Find(uid);

            if (entityToDelete != null)
            {
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


        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);

            var entry = Context.Entry(entityToUpdate);

            entry.Property(x => x.SysInsertAccountUID).IsModified = false;
            entry.Property(x => x.SysInsertTime).IsModified = false;


            entry.State = EntityState.Modified;
        }
    }
}
