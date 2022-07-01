using AutoMapper;
using MarketApp.BL.Abstract;
using MarketApp.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.Json;

namespace MarketApp.WebApp.Pages
{
    public class ProductAddModel : PageModel
    {
        private readonly ILogger<IndexModel> logger;
        private readonly IProductManager productManager;
        private readonly IMapper mapper;
        private readonly ICatagoryManager catagoryManager;
        private readonly ISupplierManager supplierManager;
        private readonly ITaxManager taxManager;

        public ProductAddModel(ILogger<IndexModel> logger,
            IProductManager productManager,
            IMapper mapper,
            ICatagoryManager catagoryManager,
            ISupplierManager supplierManager,
            ITaxManager taxManager)
        {
            this.logger = logger;
            this.productManager = productManager;
            this.mapper = mapper;
            this.catagoryManager = catagoryManager;
            this.supplierManager = supplierManager;
            this.taxManager = taxManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            public string ProductName { get; set; }

            public string? ProductDescirption { get; set; }

            public int? SupplierID { get; set; }

            public int? CategoryID { get; set; }

            public int? TaxId { get; set; }

            public string QuantityPerUnit { get; set; }

            public decimal? UnitPrice { get; set; }

            public decimal? MSRP { get; set; }

            public short? UnitsInStock { get; set; }

            public bool Discontinued { get; set; }
        }

        public SelectList Categories { get; set; }
        public SelectList Suppliers { get; set; }
        public SelectList Taxs { get; set; }
        public void OnGet()
        {
            Categories = new SelectList(catagoryManager.GetAll(), nameof(Category.Id), nameof(Category.CategoryName));
            Suppliers = new SelectList(supplierManager.GetAll(), nameof(Supplier.Id), nameof(Supplier.CompanyName));
            Taxs = new SelectList(taxManager.GetAll(), nameof(Tax.Id), nameof(Tax.TaxType));
        }
        public async Task<IActionResult> OnPostAsync()
        {
            //Bu kod parçasý eklenen ürün için gerekli eþletirmeyi yapmaktadýr.
            var product = CreateProduct();
            product.ProductName = Input.ProductName;
            product.ProductDescirption = Input.ProductDescirption;
            product.SupplierID = Input.SupplierID;
            product.CategoryID = Input.CategoryID;
            product.TaxId = Input.TaxId;
            product.QuantityPerUnit = Input.QuantityPerUnit;
            product.UnitPrice = Input.UnitPrice;
            product.MSRP = Input.MSRP;
            product.UnitsInStock = Input.UnitsInStock;
            product.Discontinued = Input.Discontinued;

            //Gelen model geçerli bir model ise çalýþacaktýr.
            if (ModelState.IsValid)
            {
                //Gelen data serialize edilip Post metodu için REST API çaðrýlacaktýr.
                var ProductJson = JsonSerializer.Serialize(product, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
             
                var data = new StringContent(ProductJson, Encoding.UTF8, "application/json");

                using var client = new HttpClient();

                //REST API POST METODU
                //Data bodye gönderildi.
                var response = await client.PostAsync($"https://localhost:7210/api/Product", data);

                //string result = response.Content.ReadAsStringAsync().Result;
            }

            return RedirectToPage("/Index", new { area = "" });
        }
        /// <summary>
        /// Activator kullanýlarak Instance alma
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        private Product CreateProduct()
        {
            try
            {
                return Activator.CreateInstance<Product>();
            }
            catch
            {
                throw new InvalidOperationException();
            }
        }
    }
}
