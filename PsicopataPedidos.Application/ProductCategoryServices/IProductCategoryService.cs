using PsicopataPedidos.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsicopataPedidos.Application.ProductCategoryServices
{
    public interface IProductCategoryService
    {
        List<ProductCategory> GetAllProductsCategories();

        ProductCategory CreateProductCategory(ProductCategory productCategory);

        ProductCategory DeleteProductCategory(ProductCategory productCategoryId);

    }
}
