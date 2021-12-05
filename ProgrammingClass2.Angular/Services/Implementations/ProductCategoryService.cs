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
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly IMapper _mapper;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoryService(IMapper mapper, IProductCategoryRepository productCategoryRepository)
        {
            _mapper = mapper;
            _productCategoryRepository = productCategoryRepository;
        }

        public async Task<List<ProductCategoryDto>> GetAllAsync(int productId)
        {
            var modelList = await _productCategoryRepository.GetAllAsync(productId);
            var dtoList = _mapper.Map<List<ProductCategoryDto>>(modelList);

            return dtoList;
        }

        public async Task<ProductCategoryDto> GetAsync(int productId, int categoryId)
        {
            var model = await _productCategoryRepository.GetAsync(productId, categoryId);

            if (model != null)
            {
                return _mapper.Map<ProductCategoryDto>(model);
            }

            return null;
        }

        public async Task<ProductCategoryDto> AddAsync(ProductCategoryDto productCategory)
        {
            var model = _mapper.Map<ProductCategory>(productCategory);
            var created = await _productCategoryRepository.AddAsync(model);

            if (created != null)
            {
                return _mapper.Map<ProductCategoryDto>(created);
            }

            return null;
        }

        public async Task<ProductCategoryDto> DeleteAsync(int productId, int categoryId)
        {
            var deleted = await _productCategoryRepository.DeleteAsync(productId, categoryId);

            if (deleted != null)
            {
                return _mapper.Map<ProductCategoryDto>(deleted);
            }

            return null;
        }
    }
}
