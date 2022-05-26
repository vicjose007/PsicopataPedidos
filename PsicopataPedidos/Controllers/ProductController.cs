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

        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var products = _service.GetAllProducts().Find(x => x.Id == id);
            if (products == null)
                return BadRequest("Product not found");
            return Ok(products);
        }


        [HttpPost, Authorize]
        public ActionResult<Product> PostProduct(Product product)
        {
            _service.CreateProduct(product);
            return Ok(product);
        }


        [HttpPut]
        public ActionResult<List<Product>> UpdateProduct(Product request)
        {
            var products = _service.GetAllProducts().Find(x => x.Id == request.Id);
            if (products == null)
                return BadRequest("Product not found");


            products.ProductName = request.ProductName;
            products.Description = request.Description;
            products.ProductCategoryId = request.ProductCategoryId;
            products.Price = request.Price;
            products.Stock = request.Stock;

            return Ok(products);
        }


        [HttpDelete, Authorize]
        public ActionResult<Product> DeleteProduct(Product product)
        {
            var productsFromService = _service.DeleteProduct(product);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public ActionResult<List<Product>> DeleteProduct(int id)
        {
            var products = _service.GetAllProducts().Find(x => x.Id == id);
            if (products == null)
                return BadRequest("Product not found");
            _service.DeleteProduct(products);
            return Ok(products);
        }
    }
}
