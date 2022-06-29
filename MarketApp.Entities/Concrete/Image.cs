using MarketApp.Entities.Abstract;
using System.ComponentModel.DataAnnotations;

namespace MarketApp.Entities.Concrete
{
    public class Image : IBaseEntity<int>, IEntity
    {
        /// <summary>
        /// benzersiz kolon ID değeri. Generi olarak değiştirilebilir
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// CDN servisinden gelen url
        /// </summary>
        [Url]
        public string Url { get; set; }
        public string? ImageDescription { get; set; }
        public virtual Product? Living { get; set; }
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