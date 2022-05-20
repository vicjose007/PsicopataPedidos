using Microsoft.AspNetCore.Mvc;
using PsicopataPedidos.Domain.Models;

namespace PsicopataPedidos.Application
{
    public class ProductService: IProductService
        
    {
        private readonly IProductRepository _productRepository;
        protected readonly IMapper _mapper;
        protected readonly IValidator<ProductDto> _validator;



        public ProductService(IProductRepository productRepository,IMapper mapper, IValidator<ProductDto> validator)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _validator = validator;

        }
        public virtual async Task<ProductDto> GetByIdAsync(int id)
        {
            var entity = await _productRepository.GetProductById(id);
            var dto = _mapper.Map<ProductDto>(entity);
            return dto;
        }

        public virtual async Task<ProductDto> AddAsync(ProductDto dto)
        {
            var validationResult = _validator.Validate(dto);
            if (validationResult.IsValid is false)
                return null;

            Product entity = _mapper.Map<Product>(dto);

            try
            {
                var product = await _productRepository.CreateProduct(entity);

                var result =_mapper.Map(product, dto);
                return result;
            }
            catch (Exception e)
            {
                string msg = e.Message;
                return null;
            }
        }

        public virtual async Task<ProductDto> UpdateAsync(int id, ProductDto dto)
        {
            var validationResult = _validator.Validate(dto);

            if (validationResult.IsValid is false)
                return null;

            var entity = await _productRepository.GetProductById(id);

            if (entity is null)
                return null;

            entity = await _productRepository.UpdateProduct(entity);
            
            var result = _mapper.Map(entity, dto);

            return result;
        }

        public virtual async Task<ProductDto> DeleteByIdAsync(int id)
        {
            var entity = await _productRepository.GetProductById(id);

            if (entity is null)
                return null;

            entity = await _productRepository.DeleteProduct(id);

            var dto = _mapper.Map<ProductDto>(entity);

            return dto;
        }

        public List<Product> GetAllProducts()
        {
            var products = _productRepository.GetAllProducts();

            return products;
        }
    }
}

