using PsicopataPedidos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsicopataPedidos.Application
{
    public interface IProductService
    {
        List<Product> GetAllProducts();

        Product CreateProduct(Product product);

        Product DeleteProduct(Product productId);

        Product UpdateProduct(Product product);
    }
}
