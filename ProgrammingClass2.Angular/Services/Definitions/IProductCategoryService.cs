using ProgrammingClass2.Angular.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.Angular.Services.Definitions
{
    public interface IProductCategoryService
    {
        Task<List<ProductCategoryDto>> GetAllAsync(int productId);

        Task<ProductCategoryDto> GetAsync(int productId, int categoryId);

        Task<ProductCategoryDto> AddAsync(ProductCategoryDto productCategory);

        Task<ProductCategoryDto> DeleteAsync(int productId, int categoryId);
    }
}
