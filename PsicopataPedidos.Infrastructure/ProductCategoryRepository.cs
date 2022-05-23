using PsicopataPedidos.Application.ProductCategoryServices;
using PsicopataPedidos.Domain.Models;

namespace PsicopataPedidos.Infrastructure
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        public static List<ProductCategory> productsCategories = new List<ProductCategory>()
        {

        };
        private readonly ProductDbContext _productCategoryDbContext;

        public ProductCategoryRepository(ProductDbContext productCategoryDbContext)
        {
            _productCategoryDbContext = productCategoryDbContext;
        }

        public ProductCategory CreateProductCategory(ProductCategory productCategory)
        {
            _productCategoryDbContext.ProductsCategories.Add(productCategory);
            _productCategoryDbContext.SaveChanges();
            return productCategory;
        }

        public ProductCategory DeleteProductCategory(ProductCategory productCategory)
        {
            _productCategoryDbContext.ProductsCategories.Remove(productCategory);
            _productCategoryDbContext.SaveChanges();

            return null;
        }

        public List<ProductCategory> GetAllProductsCategories()
        {
            return _productCategoryDbContext.ProductsCategories.ToList();
        }
    }
}
