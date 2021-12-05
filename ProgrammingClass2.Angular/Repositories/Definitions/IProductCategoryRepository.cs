using ProgrammingClass2.Angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.Angular.Repositories.Definitions
{
    public interface IProductCategoryRepository
    {
        Task<List<ProductCategory>> GetAllAsync(int productId);

        Task<ProductCategory> GetAsync(int productId, int categoryId);

        Task<ProductCategory> CreateAsync(ProductCategory productCategory);

        Task<ProductCategory> DeleteAsync(int productId, int categoryId);
    }
}
