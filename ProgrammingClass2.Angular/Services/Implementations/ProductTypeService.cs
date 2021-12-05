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
    public class ProductTypeService: IProductTypeService
    {
        private readonly IProductTypeRepository _productTypeRepository;
        private readonly IMapper _mapper;

        public ProductTypeService(IProductTypeRepository productTypeRepository, IMapper mapper)
        {
            _mapper = mapper;
            _productTypeRepository = productTypeRepository;
        }

        public async Task<List<ProductTypeDto>> GetAllProductTypesAsync()
        {
            var modelList = await _productTypeRepository.GetAllProductTypesAsync();
            var dtoList = _mapper.Map<List<ProductTypeDto>>(modelList);

            return dtoList;
        }

        public async Task<ProductTypeDto> GetAsync(int id)
        {
            var model = await _productTypeRepository.GetAsyncint(id);

            if (model != null)
            {
                return _mapper.Map<ProductTypeDto>(model);
            }

            return null;
        } 

        public async Task<ProductTypeDto> CreateAsync(ProductTypeDto dto)
        {
            var model = _mapper.Map<ProductType>(dto);
            var created = await _productTypeRepository.CreateAsync(model);

            if (created != null)
            {
                return _mapper.Map<ProductTypeDto>(created);
            }

            return null;
        }

        public async Task<ProductTypeDto> UpdateAsync(ProductTypeDto dto)
        {
            var model = _mapper.Map<ProductType>(dto);
            var updated = await _productTypeRepository.UpdateAsync(model);

            if (updated != null)
            {
                return _mapper.Map<ProductTypeDto>(updated);
            }

            return null;
        }

        public async Task<ProductTypeDto> DeleteAsync(int id)
        {
            var deleted = await _productTypeRepository.DeleteAsync(id);

            if (deleted != null)
            {
                return _mapper.Map<ProductTypeDto>(deleted);
            }

            return null;
        }
    }
}
