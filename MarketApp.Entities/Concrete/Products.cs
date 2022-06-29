using MarketApp.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketApp.Entities.Concrete
{
    public class Products : IBaseEntity<int>,IEntity
    {
        public int Id { get; set; }
        /// <summary>
        /// 40 Karakter uzunluğunda olacak şekilde girilmesi zorunlu alan.
        /// </summary>
        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }

        public int? SupplierID { get; set; }

        public int? CategoryID { get; set; }

        [StringLength(20)]
        public string QuantityPerUnit { get; set; }

        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

        public short? UnitsOnOrder { get; set; }

        public short? ReorderLevel { get; set; }

        public bool Discontinued { get; set; }

        public virtual Category Category { get; set; }
        public DateTime CreatTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
