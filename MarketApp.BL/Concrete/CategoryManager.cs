using MarketApp.BL.Abstract;
using MarketApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp.BL.Concrete
{
    /// <summary>
    /// Ürün güncelleme işlemi isme göre yapıldığı için ikinci aynı bir isim eklenmemesi gerekiyor.
    /// </summary>
    public class CategoryManager:ManagerBase<Category>,ICatagoryManager
    {
        /// <summary>
        /// Ürün güncelleme işlemi isme göre yapıldığı için ikinci aynı bir isim eklenmemesi gerekiyor.
        /// </summary>
        public override int Add(Category input)
        {

            var categories = base.GetAll(p => p.CategoryName == input.CategoryName);

            if (categories == null)
                return base.Add(input);
            else
                return -1;
        }
    }
}
