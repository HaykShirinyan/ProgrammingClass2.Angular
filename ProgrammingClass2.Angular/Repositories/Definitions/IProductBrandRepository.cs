using ProgrammingClass2.Angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.Angular.Repositories.Definitions
{
    public interface IProductBrandRepository
    {
        Task<List<ProductBrand>> GetAllAsync(int productId);

        Task<ProductBrand> GetAsync(int productId, int brandId);

        Task<ProductBrand> AddAsync(ProductBrand productBrand);

        Task<ProductBrand> DeleteAsync(int productId, int brandId);
    }
}
