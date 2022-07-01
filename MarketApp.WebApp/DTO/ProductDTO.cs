namespace MarketApp.WebApp.DTO
{
    /// <summary>
    /// Produck nesnesini Listeleme için kullanılan DTO MODEL
    /// </summary>
    public class ProductDTO
    {
        public int Id { get; set; }

        public string? SKU { get; set; }

        public string ProductName { get; set; }

        public string? ProductDescirption { get; set; }

        public string? SupplierID { get; set; }

        public string? CategoryID { get; set; }

        public string? TaxId { get; set; }

        public string QuantityPerUnit { get; set; }

        public decimal? UnitPrice { get; set; }

        public decimal? MSRP { get; set; }

        public short? UnitsInStock { get; set; }

        public bool Discontinued { get; set; }

        
    }
}
