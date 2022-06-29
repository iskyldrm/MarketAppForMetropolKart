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
        /// <summary>
        /// benzersiz kolon ID değeri. Generi olarak değiştirilebilir
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Stok Tutma Birimi Barkod No
        /// </summary>
        private string SKUBarkod;
        //Rastgele kod oluşturmaya çalıştım
        public string? MyProperty
        {
            get { return SKUBarkod; }
            set { 
                var val = new Random(1000);
                var str = "SKU";
                var val1 = val.Next(0, 10000);
                var val2 = val.Next(0,10000);
                SKUBarkod = val1.ToString() + str + val2.ToString();
            }
        }
        /// <summary>
        /// 40 Karakter uzunluğunda olacak şekilde girilmesi zorunlu alan.
        /// </summary>
        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }
        /// <summary>
        /// Gerekli açıklamalar
        /// </summary>
        public string? ProductDescirption { get; set; }
        public int? SupplierID { get; set; }
        public int? CategoryID { get; set; }
        /// <summary>
        /// Satılabilecek en küçük birim içindeki miktar
        /// </summary>
        [Required]
        [StringLength(20)]
        public string QuantityPerUnit { get; set; }
        /// <summary>
        /// Kdv tipi ve oranı
        /// </summary>
        public Kdv Kdv { get; set; }
        /// <summary>
        /// Satılabilecek en küçük birim için Fiyat
        /// </summary>
        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }
        /// <summary>
        /// Üreticinin önerdiği perakende satış fiyatı
        /// </summary>
        [Column(TypeName = "money")]
        public decimal? MSRP { get; set; }
        /// <summary>
        /// Stokda bulunan miktar
        /// </summary>
        public short? UnitsInStock { get; set; }
        /// <summary>
        /// satılabilirlik durumu
        /// </summary>
        public bool Discontinued { get; set; }
        public Image Image { get; set; }
        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
        /// <summary>
        /// Üretilme tarihi
        /// </summary>
        public DateTime ProductionTime { get; set; }
        /// <summary>
        /// Son kullanma tarihi
        /// </summary>
        public DateTime ExpirationTime { get; set; }
        /// <summary>
        /// Ürünün listeye eklenme tarihi
        /// </summary>
        public DateTime CreatTime { get; set; }
        /// <summary>
        /// Listedeki ürün bilgilerinin güncellenme tarihi
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
    
}
