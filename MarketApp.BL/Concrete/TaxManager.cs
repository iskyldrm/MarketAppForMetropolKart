using MarketApp.BL.Abstract;
using MarketApp.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp.BL.Concrete
{
    public class TaxManager:ManagerBase<Tax>,ITaxManager
    {
        public override int Add(Tax input)
        {

            var taxs = base.GetAll(p => p.TaxType == input.TaxType);

            if (taxs == null)
                return base.Add(input);
            else
                return -1;
        }
    }
}
