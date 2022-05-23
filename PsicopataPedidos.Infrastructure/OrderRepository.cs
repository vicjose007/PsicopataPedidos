using PsicopataPedidos.Application.OrderServices;
using PsicopataPedidos.Domain.Models;

namespace PsicopataPedidos.Infrastructure
{

    public class OrderRepository : IOrderRepository
    {
        public static List<Order> orders = new List<Order>()
        {

        };
        private readonly ProductDbContext _orderDbContext;

        public OrderRepository(ProductDbContext orderDbContext)
        {
            _orderDbContext = orderDbContext;
        }

        public Order CreateOrder(Order order)
        {
            _orderDbContext.Orders.Add(order);
            _orderDbContext.SaveChanges();
            return order;
        }

        public Order DeleteOrder(Order order)
        {
            _orderDbContext.Orders.Remove(order);
            _orderDbContext.SaveChanges();

            return null;
        }

        public List<Order> GetAllOrders()
        {
            return _orderDbContext.Orders.ToList();
        }

    }

}
