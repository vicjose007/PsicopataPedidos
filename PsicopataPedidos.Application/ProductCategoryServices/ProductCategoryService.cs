using PsicopataPedidos.Domain.Models;

namespace PsicopataPedidos.Application.ProductCategoryServices
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryService(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        public ProductCategory CreateProductCategory(ProductCategory productCategory)
        {
            _productCategoryRepository.CreateProductCategory(productCategory);
            return productCategory;
        }

        public ProductCategory DeleteProductCategory(ProductCategory productCategory)
        {
            _productCategoryRepository.DeleteProductCategory(productCategory);
            return productCategory;
        }

        public List<ProductCategory> GetAllProductsCategories()
        {
            var products = _productCategoryRepository.GetAllProductsCategories();

            return products;
        }
    }
}

