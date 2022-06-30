using AutoMapper;
using MarketApp.API.Models;
using MarketApp.BL.Abstract;
using MarketApp.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarketApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductManager productManager;
        private readonly IMapper mapper;
        private readonly ICatagoryManager catagoryManager;
        private readonly ISupplierManager supplierManager;
        private readonly ITaxManager taxManager;

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
        [HttpGet]
        public IActionResult GetProducts()
        {
            var urunler = productManager.GetAllInclude(null, p => p.Supplier, p => p.Category,p=>p.Kdv).ToList();
            IList<ProductDTO> list = mapper.Map<IList<ProductDTO>>(urunler);

            var taxsList = taxManager.GetAll();
            var supplierList = supplierManager.GetAll();
            var categoryList = catagoryManager.GetAll();

            return Ok(list);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var result = productManager.Find(id);
            return Ok(result);
        }

        // POST api/<ProductController>
        // https://localhost:7210/api/Product
        [HttpPost]
        public IActionResult Post([FromBody]Product  product)
        {
            var result = productManager.Add(product);

            return Ok(result);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete]
        [ActionName("Delete")]
        public IActionResult Delete([FromBody]Product product)
        {
            var result = productManager.Delete(product);

            return Ok(result);
        }
    }
}
