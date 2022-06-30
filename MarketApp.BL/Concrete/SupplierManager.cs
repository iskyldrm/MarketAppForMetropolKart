using MarketApp.BL.Abstract;
using MarketApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp.BL.Concrete
{
    public class SupplierManager:ManagerBase<Supplier>, ISupplierManager
    {
        public override int Add(Supplier input)
        {

            var companyName = base.GetAll(p => p.CompanyName == input.CompanyName);

            if (companyName == null)
                return base.Add(input);
            else
                return -1;
        }
    }
}
