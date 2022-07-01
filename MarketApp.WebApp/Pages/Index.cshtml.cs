using AutoMapper;
using MarketApp.BL.Abstract;
using MarketApp.Entities.Concrete;
using MarketApp.WebApp.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using System.Text.Json;

namespace MarketApp.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IProductManager productManager;
        private readonly IMapper mapper;
        private readonly ICatagoryManager catagoryManager;
        private readonly ISupplierManager supplierManager;
        private readonly ITaxManager taxManager;

        public IndexModel
            (ILogger<IndexModel> logger,
            IProductManager productManager,
            IMapper mapper,
            ICatagoryManager catagoryManager,
            ISupplierManager supplierManager,
            ITaxManager taxManager)
        {
            _logger = logger;
            this.productManager = productManager;
            this.mapper = mapper;
            this.catagoryManager = catagoryManager;
            this.supplierManager = supplierManager;
            this.taxManager = taxManager;
        }
        /// <summary>
        /// Search işlemi için inputtan gelen veriyi tutmak ve ikinci gGet metodu çalışmasında kullanılması için.
        /// </summary>
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        
        /// <summary>
        /// Seriliaze edilen apı datasını ekrana basmak için yazıldı.
        /// </summary>
        public List<ProductDTO> ProductsWeb { get; set; }

        public void OnGet()
        {
            ProductsWeb = new List<ProductDTO>();

            #region GetAll Rest API
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
            #endregion

            //Gelen productsların maplenmesi
            IList<ProductDTO> list = mapper.Map<IList<ProductDTO>>(products);

            #region Filtreli GetAll Rest API
            if (!string.IsNullOrEmpty(SearchString))
            {
                httpWebRequest = (HttpWebRequest)HttpWebRequest.Create($"https://localhost:7210/api/Product?input={SearchString}");
                httpWebRequest.Method = "GET";

                Products = string.Empty;
                using (HttpWebResponse response1 = (HttpWebResponse)httpWebRequest.GetResponse())
                {
                    Stream stream = response1.GetResponseStream();
                    StreamReader reader = new StreamReader(stream);
                    Products = reader.ReadToEnd();
                    reader.Close();
                    stream.Close();

                }
                products = JsonSerializer.Deserialize<List<ProductDTO>>(Products, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                list = mapper.Map<IList<ProductDTO>>(products);
            } 
            #endregion
            //cs.htmlde dataya erişim
            ProductsWeb = list.ToList();
            

        }
        
    }
}