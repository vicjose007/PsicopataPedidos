using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsicopataPedidos.Application;
using PsicopataPedidos.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PsicopataPedidos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListController : ControllerBase
    {
        private readonly IShoppingListService _service;

        public ShoppingListController(IShoppingListService service)
        {
            _service = service;
        }
        [HttpGet, Authorize]
        public ActionResult<List<ShoppingList>> GetShoppingList()
        {
            var shoppingListFromService = _service.GetShoppingList();
            return Ok(shoppingListFromService);
        }


        [HttpPost, Authorize]
        public ActionResult<ShoppingList> PostShoppingList(ShoppingList shoppingList)
        {
            var shoppingListFromService = _service.CreateShoppingList(shoppingList);
            return Ok(shoppingList);
        }


        [HttpDelete, Authorize]
        public ActionResult<ShoppingList> DeleteShoppingList(ShoppingList shoppingList)
        {
            var shoppingListFromService = _service.DeleteShoppingList(shoppingList);
            return Ok(shoppingList);
        }
    }
}
