using MarketApp.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace MarketApp.Entities.Concrete
{
    public class Tax : IBaseEntity<int>, IEntity
    {
        /// <summary>
        /// benzersiz kolon ID değeri. Generi olarak değiştirilebilir
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Vergi tipi
        /// </summary>
        [Required]
        [StringLength(100)]
        public string TaxType { get; set; }
        /// <summary>
        /// vergi oranı
        /// </summary>
        public decimal TaxValue { get; set; }
        /// <summary>
        /// listeye eklenme tarihi
        /// </summary>
        public IList<Product>? Products { get; set; }
        public DateTime CreatTime { get; set; }
        /// <summary>
        /// Listedeki bilgilerinin güncellenme tarihi
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}