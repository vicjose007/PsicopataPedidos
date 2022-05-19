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
        Task<Product> CreateProduct(Product product);
        Task<Product> DeleteProduct(int id);
        Task<Product> GetProductById(int id);
        Task<Product> UpdateProduct(Product product);
    }
}
