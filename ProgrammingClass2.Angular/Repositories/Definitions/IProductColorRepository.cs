using ProgrammingClass2.Angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.Angular.Repositories.Definitions
{
    public interface IProductColorRepository
    {
        Task<List<ProductColor>> GetAllAsync(int productId);

        Task<ProductColor> GetAsync(int productId, int colorId);

        Task<ProductColor> CreateAsync(ProductColor productColor);

        Task<ProductColor> DeleteAsync(int productId, int colorId);
    }
}
