using PsicopataPedidos.Application.Dtos;
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
        Task<ProductDto> GetByIdAsync(int id);
        Task<ProductDto> AddAsync(ProductDto dto);
        Task<ProductDto> UpdateAsync(int id, ProductDto dto);
        Task<ProductDto> DeleteByIdAsync(int id);

    }
}
