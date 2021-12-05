using ProgrammingClass2.Angular.DataTransferObjects;
using ProgrammingClass2.Angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.Angular.Services.Definitions
{
    public interface IProductTypeService
    {
        Task<List<ProductTypeDto>> GetAllProductTypesAsync();

        Task<ProductTypeDto> GetAsync(int id);

        Task<ProductTypeDto> CreateAsync(ProductTypeDto dto);

        Task<ProductTypeDto> UpdateAsync(ProductTypeDto dto);

        Task<ProductTypeDto> DeleteAsync(int id);
        Task CreateAsync(ProductType productType);
    }
}
