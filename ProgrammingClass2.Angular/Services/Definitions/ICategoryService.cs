using ProgrammingClass2.Angular.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.Angular.Services.Definitions
{
    public interface ICategoryService
    {
        Task<List<CategoryDto>> GetAllAsync();

        Task<CategoryDto> GetAsync(int id);

        Task<CategoryDto> CreateAsync(CategoryDto dto);

        Task<CategoryDto> UpdateAsync(CategoryDto dto);

        Task<CategoryDto> DeleteAsync(int id);
    }
}
