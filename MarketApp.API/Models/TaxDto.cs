namespace MarketApp.API.Models
{
    public class TaxDto
    {
        public int Id { get; set; }
        public string TaxType { get; set; }
        public decimal TaxValue { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; } = DateTime.Now;
    }
}
