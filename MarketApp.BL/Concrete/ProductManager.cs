using MarketApp.BL.Abstract;
using MarketApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp.BL.Concrete
{
    public class ProductManager:ManagerBase<Product>,IProductManager
    {
    }
}
