using Microsoft.EntityFrameworkCore;
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
        private readonly DbSet<Product> _productSet;

        public ProductRepository(ProductDbContext productDbContext, DbSet<Product> productSet)
        {
            _productDbContext = productDbContext;
            _productSet = productSet;
        }
        public IQueryable<Product> Query()
        {
            return _productSet.AsQueryable();
        }
        public async Task<Product> GetProductById(int id)
        {
            var product = await _productSet.Where(x => x.Id == id).FirstOrDefaultAsync();
            return product;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            var result = await _productSet.AddAsync(product);
            await _productDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Product> DeleteProduct(int Id)
        {
           var product = await GetProductById(Id);
           var result = _productSet.Remove(product);
           return result.Entity;
        }
        public async Task<Product> UpdateProduct(Product product)
        {
            _productDbContext.Entry(product).State = EntityState.Modified;
            await _productDbContext.SaveChangesAsync();
            return product;
        }

        public List<Product> GetAllProducts()
        {
            return _productDbContext.Products.ToList();  
        }
    }
}
