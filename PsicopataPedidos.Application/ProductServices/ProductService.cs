using Microsoft.AspNetCore.Mvc;
using PsicopataPedidos.Domain.Models;

namespace PsicopataPedidos.Application
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product CreateProduct(Product product)
        {
            _productRepository.CreateProduct(product);
            return product;
        }


        public Product DeleteProduct(Product product)
        {
            _productRepository.DeleteProduct(product);
            return product;
        }

        public List<Product> GetAllProducts()
        {
            var products = _productRepository.GetAllProducts();

            return products;
        }

        public Product UpdateProduct(Product product)
        {
            var products = _productRepository.UpdateProduct(product);

            return products;
        }
    }
}

