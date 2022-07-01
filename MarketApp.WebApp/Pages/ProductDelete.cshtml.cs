using AutoMapper;
using MarketApp.BL.Abstract;
using MarketApp.Entities.Concrete;
using MarketApp.WebApp.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Text;
using System.Text.Json;

namespace MarketApp.WebApp.Pages
{
    public class ProductDeleteModel : PageModel
    {
        private readonly ILogger<IndexModel> logger;
        private readonly IProductManager productManager;
        private readonly IMapper mapper;
        private readonly ICatagoryManager catagoryManager;
        private readonly ISupplierManager supplierManager;
        private readonly ITaxManager taxManager;

        public ProductDeleteModel(ILogger<IndexModel> logger,
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
            //Seçilencek ürünün ID si
            public int Id { get; set; }
        }

        public List<ProductDTO> ProductsWeb { get; set; }
        public void OnGet()
        {
            ProductsWeb = new List<ProductDTO>();
            #region Delete REST API
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
            #endregion


            ProductsWeb = list.ToList();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //Post edildikten sonra Produck nesnesinin geitirlmesi
            var product = productManager.Find(Input.Id);

            if (ModelState.IsValid)
            {
                //Gerekli rest serialize
                var ProductJson = JsonSerializer.Serialize(product, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                HttpClient http = new HttpClient();
                var httpMessage = new HttpRequestMessage(HttpMethod.Delete, "https://localhost:7210/api/Product")
                {
                    Content = new StringContent(ProductJson, Encoding.UTF8, "application/json")
                };
                var result = await http.SendAsync(httpMessage);
            }
            //Silme iþleminden sonra delete page nin getirilmesi getirilmesi
            return RedirectToPage("/ProductDelete", new { area = "" });
        }
        
    }
}
