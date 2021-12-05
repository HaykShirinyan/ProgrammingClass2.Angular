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
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var modelList = await _categoryRepository.GetAllAsync();
            var dtoList = _mapper.Map<List<CategoryDto>>(modelList);

            return dtoList;
        }

        public async Task<CategoryDto> GetAsync(int id)
        {
            var model = await _categoryRepository.GetAsync(id);

            if (model != null)
            {
                return _mapper.Map<CategoryDto>(model);
            }

            return null;
        }

        public async Task<CategoryDto> CreateAsync(CategoryDto dto)
        {
            var model = _mapper.Map<Category>(dto);
            var created = await _categoryRepository.CreateAsync(model);

            if (created != null)
            {
                return _mapper.Map<CategoryDto>(created);
            }

            return null;
        }

        public async Task<CategoryDto> UpdateAsync(CategoryDto dto)
        {
            var model = _mapper.Map<Category>(dto);
            var updated = await _categoryRepository.UpdateAsync(model);

            if (updated != null)
            {
                return _mapper.Map<CategoryDto>(updated);
            }

            return null;
        }

        public async Task<CategoryDto> DeleteAsync(int id)
        {
            var deleted = await _categoryRepository.DeleteAsync(id);

            if (deleted != null)
            {
                return _mapper.Map<CategoryDto>(deleted);
            }

            return null;
        }
    }
}
}
}
