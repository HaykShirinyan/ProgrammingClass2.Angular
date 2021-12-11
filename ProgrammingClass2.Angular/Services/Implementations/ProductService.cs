using AutoMapper;
using ProgrammingClass2.Angular.DataTransferObjects;
using ProgrammingClass2.Angular.Models;
using ProgrammingClass2.Angular.Repositories.Definitions;
using ProgrammingClass2.Angular.Services.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.Angular.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var modelList = await _productRepository.GetAllAsync();
            var dtoList = _mapper.Map<List<ProductDto>>(modelList);

            return dtoList;
        }

        public async Task<ProductDto> GetAsync(int id)
        {
            var model = await _productRepository.GetAsync(id);

            if (model != null)
            {
                return _mapper.Map<ProductDto>(model);
            }

            return null;
        }

        public async Task<ProductDto> CreateAsync(ProductDto dto)
        {
            var model = _mapper.Map<Product>(dto);
            var created = await _productRepository.CreateAsync(model);

            if (created != null)
            {
                return _mapper.Map<ProductDto>(created);
            }

            return null;
        }

        public async Task<ProductDto> UpdateAsync(ProductDto dto)
        {
            var model = _mapper.Map<Product>(dto);
            var updated = await _productRepository.UpdateAsync(model);

            if (updated != null)
            {
                return _mapper.Map<ProductDto>(updated);
            }

            return null;
        }

        public async Task<ProductDto> DeleteAsync(int id)
        {
            var deleted = await _productRepository.DeleteAsync(id);

            if (deleted != null)
            {
                return _mapper.Map<ProductDto>(deleted);
            }

            return null;
        }
    }
}
