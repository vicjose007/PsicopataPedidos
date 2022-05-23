using PsicopataPedidos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsicopataPedidos.Application.OrderServices
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();

        Order CreateOrder(Order order);

        Order DeleteOrder(Order order);

    }
}
