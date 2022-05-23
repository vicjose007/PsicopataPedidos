using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PsicopataPedidos.Application.OrderServices;
using PsicopataPedidos.Domain.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PsicopataPedidos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }
        [HttpGet, Authorize]
        public ActionResult<List<Order>> Get()
        {
            var ordersFromService = _service.GetAllOrders();
            return Ok(ordersFromService);
        }


        [HttpPost, Authorize]
        public ActionResult<Order> PostOrder(Order order)
        {
            var OrdersFromService = _service.CreateOrder(order);
            return Ok(order);
        }


        [HttpDelete, Authorize]
        public ActionResult<Order> DeleteOrder(Order order)
        {
            var OrdersFromService = _service.DeleteOrder(order);
            return Ok(order);
        }
    }
}
