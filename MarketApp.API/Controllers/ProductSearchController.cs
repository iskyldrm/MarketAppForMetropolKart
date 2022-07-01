using AutoMapper;
using MarketApp.API.Models;
using MarketApp.BL.Abstract;
using MarketApp.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductSearchController : ControllerBase
    {
        private readonly IProductManager productManager;
        private readonly IMapper mapper;
        private readonly ICatagoryManager catagoryManager;
        private readonly ISupplierManager supplierManager;
        private readonly ITaxManager taxManager;

        
        public ProductSearchController(IProductManager productManager,
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
        [HttpGet]
        //https://localhost:7210/api/ProductSearch?input=gazl%C4%B1
        public IActionResult GetSearch(string? input=null)
        {
            if (input != null)
            {
                var products = productManager.GetAll(p => p.ProductName.Contains(input) || p.Category.CategoryName.Contains(input));

                IList<ProductDTO> list = mapper.Map<IList<ProductDTO>>(products);

                return Ok(products);
            }
            else
            {
                var products = productManager.GetAll();

                return Ok(products);
            }
            
           
        }
    }
}
