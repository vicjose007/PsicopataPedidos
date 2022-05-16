using PsicopataPedidos.Application;
using PsicopataPedidos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsicopataPedidos.Infrastructure
{
    public class ProductRepository : IProductRepository
    {
        public static List<Product> products = new List<Product>()
        {

        };
        private readonly ProductDbContext _productDbContext;

        public ProductRepository(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public Product CreateProduct(Product product)
        {
            _productDbContext.Products.Add(product);
            _productDbContext.SaveChanges();
            return product;
        }

        public Product DeleteProduct(Product product)
        {
            _productDbContext.Products.Remove(product);
            _productDbContext.SaveChanges();

            return null;
        }

        public List<Product> GetAllProducts()
        {
            return _productDbContext.Products.ToList();  
        }
    }
}
