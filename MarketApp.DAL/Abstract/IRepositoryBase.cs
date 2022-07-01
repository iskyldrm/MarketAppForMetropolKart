using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp.DAL.Abstract
{
    public interface IRepositoryBase<TEntity> where TEntity : class, new()
    {
        /// <summary>
        /// Ekleme işlemi için kulalnılacak metod.
        /// </summary>
        /// <param name="input">Girilecek nesnede name quantityperunit ve fiyat requiredtır</param>
        /// <returns></returns>
        public int Add(TEntity input);
        /// <summary>
        /// Güncelleme işlemi için kulalnılacak metod.
        /// </summary>
        /// <param name="input">Girilecek nesnede name quantityperunit ve fiyat requiredtır</param>
        /// <returns></returns>
        public int Update(TEntity input);
        /// <summary>
        /// Silme işlemi için kulalnılacak metod.
        /// </summary>
        /// <param name="input">Girilecek nesnede name quantityperunit ve fiyat requiredtır</param>
        /// <returns></returns>
        public int Delete(TEntity input);
        /// <summary>
        /// Sadece tek bir nesne döndürme işlemi için kulalnılacak metod.
        /// </summary>
        /// <param name="input">Girilecek nesnede name quantityperunit ve fiyat requiredtır</param>
        /// <returns></returns>
        public TEntity Find(int id);
        /// <summary>
        /// Tüm tablo datasını getirme işlemi için kulalnılacak metod.
        /// </summary>
        /// <param name="input">Girilecek nesnede name quantityperunit ve fiyat requiredtır</param>
        /// <returns></returns>
        public IList<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);
        /// <summary>
        /// ek sorgu işlemi için  işlemi için kulalnılacak metod.
        /// </summary>
        /// <param name="input">Girilecek nesnede name quantityperunit ve fiyat requiredtır</param>
        /// <returns></returns>
        public IQueryable<TEntity> GetAllInclude(Expression<Func<TEntity, bool>> filter = null, params Expression<Func<TEntity, object>>[] include);

    }
}
