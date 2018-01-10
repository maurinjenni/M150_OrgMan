using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using OrgMan.DataContracts.Repository.RepositoryBase;
using OrgMan.DataModel;
using System.Data;

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

        public virtual TEntity Get(List<Guid> mandatorUids, Guid uid)
        {
            var entity = DbSet.FirstOrDefault(t => t.UID == uid);

            if (entity.MandatorUIDs.Intersect(mandatorUids).Any())
            {
                return entity;
            }
            else
            {
                throw new UnauthorizedAccessException(string.Format("{0} from another Mandator", entity.GetType().BaseType.Name));
            }
        }

        public virtual TEntity Get(Guid uid)
        {
            return DbSet.FirstOrDefault(t => t.UID == uid);
        }

        public virtual void Insert(List<Guid> mandatorUids, TEntity entity)
        {
            if (entity.MandatorUIDs.Intersect(mandatorUids).Any())
            {
                DbSet.Add(entity);
            }
            else
            {
                throw new UnauthorizedAccessException(string.Format("{0} from another Mandator", entity.GetType().BaseType.Name));
            }
        }

        public virtual void Delete(List<Guid> mandatorUids, Guid uid)
        {
            TEntity entityToDelete = DbSet.FirstOrDefault(e => e.UID == uid);

            if (entityToDelete != null)
            {
                if (entityToDelete.MandatorUIDs.Intersect(mandatorUids).Any())
                {
                    if (Context.Entry(entityToDelete).State == EntityState.Detached)
                    {
                        DbSet.Attach(entityToDelete);
                    }

                    DbSet.Remove(entityToDelete);
                }
                else
                {
                    throw new UnauthorizedAccessException(string.Format("{0} from another Mandator", entityToDelete.GetType().BaseType.Name));
                }
            }
            else
            {
                throw new DataException(string.Format("No Entity found to UID : {1}", uid));
            }
        }


        public virtual void Delete(List<Guid> mandatorUids, TEntity entityToDelete)
        {
            if(entityToDelete != null)
            {
                if (entityToDelete.MandatorUIDs.Intersect(mandatorUids).Any())
                {
                    if (Context.Entry(entityToDelete).State == EntityState.Detached)
                    {
                        DbSet.Attach(entityToDelete);
                    }

                    DbSet.Remove(entityToDelete);
                }
                else
                {
                    throw new UnauthorizedAccessException(string.Format("{0} from another Mandator", entityToDelete.GetType().BaseType.Name));
                }
            }
            else
            {
                throw new DataException("No Entity found to delete");
            }
        }

        public virtual void Update(List<Guid> mandatorUids, TEntity entityToUpdate)
        {
            //var oldEntity = DbSet.FirstOrDefault(e => e.UID == entityToUpdate.UID);

            //if(oldEntity != null)
            //{
            //    if (oldEntity.MandatorUIDs.Intersect(mandatorUids).Any())
            //    {
                    DbSet.Attach(entityToUpdate);

                    var entry = Context.Entry(entityToUpdate);

                    entry.Property(x => x.SysInsertAccountUID).IsModified = false;
                    entry.Property(x => x.SysInsertTime).IsModified = false;


                    entry.State = EntityState.Modified;
                //}
        //        else
        //        {
        //            throw new UnauthorizedAccessException(string.Format("{0} from another Mandator", entityToUpdate.GetType().BaseType.Name));
        //        }
        //    }
        //    else
        //    {
        //        throw new DataException(string.Format("No Entity found to UID : {1}", entityToUpdate.UID));
        //    }
        }
    }
}
