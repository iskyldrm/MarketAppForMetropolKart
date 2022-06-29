using MarketApp.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace MarketApp.Entities.Concrete
{
    public class Category : IBaseEntity<int>, IEntity
    {
        /// <summary>
        /// benzersiz kolon ID değeri. Generi olarak değiştirilebilir
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// 40 Karakter uzunluğunda olacak şekilde girilmesi zorunlu alan.
        /// </summary>
        [Required]
        [StringLength(40)]
        public string CategoryName { get; set; }
        public virtual int MasterCategoryId { get; set; } = 0;
        public string? Description { get; set; }
        /// <summary>
        ///  listeye eklenme tarihi
        /// </summary>
        public IList<Product>? Products { get; set; }
        public DateTime CreatTime { get; set; }
        /// <summary>
        /// Listedeki  bilgilerinin güncellenme tarihi
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}