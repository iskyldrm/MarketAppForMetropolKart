using MarketApp.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace MarketApp.Entities.Concrete
{
    public class Supplier : IBaseEntity<int>,IEntity
    {
        /// <summary>
        /// benzersiz kolon ID değeri. Generi olarak değiştirilebilir
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// tedarikçi ismi
        /// </summary>
        [Required]
        [StringLength(50)]
        public string CompanyName { get; set; }

        public IList<Product> Products { get; set; }
        /// <summary>
        /// listeye eklenme tarihi
        /// </summary>
        public DateTime CreatTime { get; set; }

        /// <summary>
        /// Listedeki bilgilerinin güncellenme tarihi
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}