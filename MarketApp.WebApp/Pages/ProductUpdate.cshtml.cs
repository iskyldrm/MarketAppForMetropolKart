using AutoMapper;
using MarketApp.BL.Abstract;
using MarketApp.Entities.Concrete;
using MarketApp.WebApp.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net;
using System.Text;
using System.Text.Json;

namespace MarketApp.WebApp.Pages.Shared
{
    public class ProductUpdateModel : PageModel
    {
        private readonly ILogger<IndexModel> logger;
        private readonly IProductManager productManager;
        private readonly IMapper mapper;
        private readonly ICatagoryManager catagoryManager;
        private readonly ISupplierManager supplierManager;
        private readonly ITaxManager taxManager;
        private object productmanager;

        public ProductUpdateModel(ILogger<IndexModel> logger,
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

        //Inputlar için gerekli model
        public class InputModel
        {
            public int ProductID { get; set; }

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
        public List<ProductDTO> ProductsWeb { get; set; }
        public SelectList SelectedProduct { get; set; }
        public SelectList Categories { get; set; }
        public SelectList Suppliers { get; set; }
        public SelectList Taxs { get; set; }
        public void OnGet()
        {
            //Seçilecek üründe update edilebilcek selectlistler
            SelectedProduct = new SelectList(productManager.GetAll(), nameof(Product.Id), nameof(Product.ProductName));
            Categories = new SelectList(catagoryManager.GetAll(), nameof(Category.Id), nameof(Category.CategoryName));
            Suppliers = new SelectList(supplierManager.GetAll(), nameof(Supplier.Id), nameof(Supplier.CompanyName));
            Taxs = new SelectList(taxManager.GetAll(), nameof(Tax.Id), nameof(Tax.TaxType));

            ProductsWeb = new List<ProductDTO>();


            HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create($"https://localhost:7210/api/Product");
            httpWebRequest.Method = "GET";

            string Products = string.Empty;
            using (HttpWebResponse response1 = (HttpWebResponse)httpWebRequest.GetResponse())
            {
                Stream stream = response1.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                Products = reader.ReadToEnd();
                reader.Close();
                stream.Close();

            }
            var products = JsonSerializer.Deserialize<List<ProductDTO>>(Products, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            IList<ProductDTO> list = mapper.Map<IList<ProductDTO>>(products);
            

            ProductsWeb = list.ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //Seçilen ürünün ID si ile ýnputtan gelen nesne eþleþtirildi.
            var product = productManager.GetAll(p => p.Id == Input.ProductID);

            //Güncellenen deðerler için yeni product nesnesi oluþturuldu.
            var newProduct = CreateProduct();
            newProduct.Id = Input.ProductID;
            newProduct.ProductName = product[0].ProductName;
            newProduct.ProductDescirption = Input.ProductDescirption;
            newProduct.CategoryID = Input.CategoryID;
            newProduct.SupplierID = Input.SupplierID;
            newProduct.TaxId = Input.TaxId;
            newProduct.QuantityPerUnit = Input.QuantityPerUnit;
            newProduct.MSRP = Input.MSRP;
            newProduct.UnitPrice = Input.UnitPrice;
            newProduct.UnitsInStock = Input.UnitsInStock;
            newProduct.Discontinued = Input.Discontinued;
            

            if (ModelState.IsValid)
            {
                

                var productjson = JsonSerializer.Serialize(newProduct, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                HttpClient http = new HttpClient();
                var httpMessage = new HttpRequestMessage(HttpMethod.Put, $"https://localhost:7210/api/Product")
                {
                    Content = new StringContent(productjson, Encoding.UTF8, "application/json")
                };
                var result = await http.SendAsync(httpMessage);

                
            }

            return RedirectToPage("/ProductUpdate", new { area = "" });
        }
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
