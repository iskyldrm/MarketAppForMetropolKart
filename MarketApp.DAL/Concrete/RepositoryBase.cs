using MarketApp.DAL.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp.DAL.Concrete
{
    public class RepositoryBase<TEntity, TContext> : IRepositoryBase<TEntity>
        where TEntity : class, new()
        where TContext : DbContext, new()
    {
        protected TContext db;
        public RepositoryBase()
        {
            db = new TContext();
        }
        public virtual int Add(TEntity input)
        {
            db.Add(input);
            return db.SaveChanges();
        }

        public virtual int Delete(TEntity input)
        {
            db.Set<TEntity>().Remove(input);
            return db.SaveChanges();
        }

        public virtual TEntity Find(int id)
        {
            return db.Set<TEntity>().Find(id);
        }

        

        public IList<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            if (filter == null)
            {
                return db.Set<TEntity>().ToList();
            }
            else
            {
                return db.Set<TEntity>().Where(filter).ToList();
            }
        }
        public IQueryable<TEntity> GetAllInclude(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] include)
        {
            IQueryable<TEntity> query;

            if (filter != null)
                query = db.Set<TEntity>().Where(filter);
            else
                query = db.Set<TEntity>();



            return include.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public virtual int Update(TEntity input)
        {
            var result = db.Entry<TEntity>(input);
            result.State = EntityState.Modified;
            return db.SaveChanges();
        }


    }
}
