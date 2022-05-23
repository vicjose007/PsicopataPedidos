using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsicopataPedidos.Application.ProductCategoryServices;
using PsicopataPedidos.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PsicopataPedidos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProductCategoryService _service;

        public ProductCategoryController(IProductCategoryService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult<List<ProductCategory>> Get()
        {
            var productsCategoriesFromService = _service.GetAllProductsCategories();
            return Ok(productsCategoriesFromService);
        }


        [HttpPost]
        public ActionResult<ProductCategory> PostProduct(ProductCategory productCategory)
        {
            var productsCategoriesFromService = _service.CreateProductCategory(productCategory);
            return Ok(productCategory);
        }


        [HttpDelete]
        public ActionResult<ProductCategory> DeleteProduct(ProductCategory productCategory)
        {
            var productsCategoriesFromService = _service.DeleteProductCategory(productCategory);
            return Ok(productCategory);
        }
    }
}
