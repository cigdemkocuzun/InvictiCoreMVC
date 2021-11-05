using MVCCoreTemplate.Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace MVCCoreTemplate.Core.EntityFramework
{

    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
where TEntity : class, IEntitiy, new()
where TContext : DbContext, new()
    {
        public int Delete(TEntity obj)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().Remove(obj);
                return context.SaveChanges();
            }
        }

        public TEntity GetById(Expression<Func<TEntity, bool>> where)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().FirstOrDefault(where);
            }
        }

        public List<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public int Insert(TEntity obj)
        {
            using (var context = new TContext())
            {
                //var addedEntity = contex.Entry(obj);
                //addedEntity.State = EntityState.Added;
                context.Set<TEntity>().Add(obj);
                return context.SaveChanges();
            }
        }

        public int Update(TEntity obj)
        {
            using (var context = new TContext())
            {
                var updateEntity = context.Entry(obj);
                updateEntity.State = EntityState.Modified;
                return context.SaveChanges();
            }
        }
    }

}
