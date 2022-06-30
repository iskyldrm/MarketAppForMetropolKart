using MarketApp.API.Models;
using MarketApp.BL.Abstract;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MarketApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxController : ControllerBase
    {
        private readonly ITaxManager _taxManager;

        public TaxController(ITaxManager taxManager)
        {
            this._taxManager = taxManager;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_taxManager.GetAll());
        }
    }
}
