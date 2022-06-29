using MarketApp.BL.Abstract;
using MarketApp.DAL.Abstract;
using MarketApp.DAL.Concrete;
using MarketApp.DAL.Context;
using MarketApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp.BL.Concrete
{
    public class ManagerBase<T> : IManagerBase<T> where T : class, IEntity, new()
    {
        private readonly IRepositoryBase<T> repositoryBase;
        public ManagerBase()
        {
            repositoryBase = new RepositoryBase<T, SqlDbContext>();
        }
        
        public int Add(T input)
        {
            return repositoryBase.Add(input);  
        }

        public int Delete(T input)
        {
            return repositoryBase.Delete(input);
        }

        public T Find(int id)
        {
            return repositoryBase.Find(id);
        }

        public IList<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return repositoryBase.GetAll(filter);
        }

        public IQueryable<T> GetAllInclude(Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] include)
        {
            return repositoryBase.GetAllInclude(filter, include);
        }

        public int Update(T input)
        {
            return repositoryBase.Update(input);
        }
    }
}
