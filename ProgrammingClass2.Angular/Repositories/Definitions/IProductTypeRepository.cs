using ProgrammingClass2.Angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.Angular.Repositories.Definitions
{
    public interface IProductTypeRepository
    {
        Task<List<ProductType>> GetAllProductTypesAsync();

        Task<ProductType> CreateAsync(ProductType productType);

        Task<ProductType> UpdateAsync(ProductType productType);

        Task<ProductType> DeleteAsync(int id);

        Task<ProductType> GetAsyncint (int id);
    }
}
