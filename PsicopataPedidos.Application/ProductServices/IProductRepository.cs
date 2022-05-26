using PsicopataPedidos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsicopataPedidos.Application
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();

        Product CreateProduct(Product product);

        Product DeleteProduct(Product product);
        
        Product UpdateProduct(Product product);
    }
}
