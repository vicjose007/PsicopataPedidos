using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsicopataPedidos.Application;
using PsicopataPedidos.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PsicopataPedidos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            var productsFromService = _service.GetAllProducts();
            return Ok(productsFromService);
        }


        [HttpPost]
        public ActionResult<Product> PostProduct(Product product)   
        {
            var productsFromService = _service.CreateProduct(product);
            return Ok(product);
        }


        [HttpDelete]
        public ActionResult<Product> DeleteProduct(Product product)
        {
            var productsFromService = _service.DeleteProduct(product);
            return Ok(product);
        }
    }
}
