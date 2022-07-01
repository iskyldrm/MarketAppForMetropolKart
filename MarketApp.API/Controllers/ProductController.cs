using AutoMapper;
using MarketApp.API.Models;
using MarketApp.BL.Abstract;
using MarketApp.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MarketApp.API.Controllers
{
    /// <summary>
    /// Bu Controller Product için gerekli Ekle/Sil/Güncelle/Listeleme/Filtreleme işlemleri için gerekli metodları barındırır.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager productManager;
        private readonly IMapper mapper;
        private readonly ICatagoryManager catagoryManager;
        private readonly ISupplierManager supplierManager;
        private readonly ITaxManager taxManager;

        // Gerekli ve gerekebilecek manager sınıfları inject edilmiştir.
        public ProductController
            (IProductManager productManager,
            IMapper mapper,
            ICatagoryManager catagoryManager,
            ISupplierManager supplierManager,
            ITaxManager taxManager)
        {
            this.productManager = productManager;
            this.mapper = mapper;
            this.catagoryManager = catagoryManager;
            this.supplierManager = supplierManager;
            this.taxManager = taxManager;
        }
        // GET: api/<ProductController>
        // Get Metod manager projesinden gelen productmanager ile databaseden productlar getirilmiştir.
        [HttpGet]
        public IActionResult GetProducts(string? input = null)
        {
            // Eğer arama inputundan değer gelmezse çalışacak olan kısım
            if (input==null)
            {
                var urunler = productManager.GetAllInclude(null, p => p.Supplier, p => p.Category, p => p.Kdv).ToList();
                IList<ProductDTO> list = mapper.Map<IList<ProductDTO>>(urunler);

                var taxsList = taxManager.GetAll();
                var supplierList = supplierManager.GetAll();
                var categoryList = catagoryManager.GetAll();

                return Ok(list);
            }
            //Arama kısmına parametre girilir ve input!=null olursa çalaışacak olan sorgu.
            else
            {
                var urunler = productManager.GetAllInclude
                    (p=>p.ProductName.Contains(input) || 
                    p.Category.CategoryName.Contains(input), 
                    p => p.Supplier, 
                    p => p.Category, 
                    p => p.Kdv).ToList();
                IList<ProductDTO> list = mapper.Map<IList<ProductDTO>>(urunler);

                var taxsList = taxManager.GetAll();
                var supplierList = supplierManager.GetAll();
                var categoryList = catagoryManager.GetAll();

                return Ok(list);
            }
            
        }

        // GET api/<ProductController>/5
        // ID parametresi ile ürün arama yapılmış gelen sonuç ile FROMBODY den silme işlemi yapılmıştır.
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = productManager.Find(id);
            return Ok(result);
        }

        // POST api/<ProductController>
        // Frombody den gelen product ile Post metodunda add işlemi yapılmıştır. Ürün ekleme için çalışır.
        [HttpPost]
        public IActionResult Add([FromBody]Product  product)
        {
            var result = productManager.Add(product);

            return Ok(result);
        }

        // PUT api/<ProductController>/5
        //Güncelleme işlemi için çalıştırılır.
        [HttpPut]
        public IActionResult Update([FromBody] Product product)
        {
            var result = productManager.Update(product);

            return Ok(result);
        }

        // DELETE api/<ProductController>/5
        // Delete işlemi FromBody den gelen entityi silme işlemi yapar.
        [HttpDelete]
        public IActionResult Delete([FromBody]Product product)
        {
            var result = productManager.Delete(product);

            return Ok(result);
        }
    }
}
