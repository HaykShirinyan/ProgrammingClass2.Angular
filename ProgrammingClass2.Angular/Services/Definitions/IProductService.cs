using ProgrammingClass2.Angular.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.Angular.Services.Definitions
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAllAsync();

        Task<ProductDto> GetAsync(int id);

        Task<ProductDto> CreateAsync(ProductDto dto);

        Task<ProductDto> UpdateAsync(ProductDto dto);

        Task<ProductDto> DeleteAsync(int id);
    }
}
