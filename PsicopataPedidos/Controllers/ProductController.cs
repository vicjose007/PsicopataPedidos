using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsicopataPedidos.Application;
using PsicopataPedidos.Application.Dtos;
using PsicopataPedidos.Domain.Models;
using System.Net;

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
        [HttpGet("[action]/")]
        public ActionResult<List<Product>> GetAllProducts()
        {
            var productsFromService = _service.GetAllProducts();
            return Ok(productsFromService);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> GetById([FromRoute] int id)
        {
            var result = await _service.GetByIdAsync(id);

            if (result is null)
                return NotFound($"El usuario con el id {id} no existe");

            return Ok(result);
        }

        [HttpPost("[action]/")]
        public virtual async Task<IActionResult> AddProduct(ProductDto product)   
        {
            var result = await _service.AddAsync(product);
            return CreatedAtAction(WebRequestMethods.Http.Get, new { id = result.ProductId });
        }


        [HttpDelete("{id}")]
        public ActionResult<Product> DeleteProduct([FromRoute]int id)
        {
            var result = _service.DeleteByIdAsync(id);
            if (result is null)
                return NotFound($"El usuario con el id {id} no existe");
            return Ok(result);
        }
        [HttpPut("{id}")]
        public virtual async Task<IActionResult> Put([FromRoute] int id, [FromBody] ProductDto dto)
        {
            var result = await _service.UpdateAsync(id, dto);

            if (result is null)
                return NotFound($"El usuario con el id {id} no existe");

            return Ok(result);
        }
    }
}
