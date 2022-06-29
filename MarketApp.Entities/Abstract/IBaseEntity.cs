using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp.Entities.Abstract
{
    public interface IBaseEntity<T>
    {
        public T Id { get; set; }
        public DateTime CreatTime { get; set; }
        public DateTime UpdateTime { get; set; }

    }
}
