using ProgrammingClass2.Angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.Angular.Repositories.Definitions
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();

        Task<Product> GetAsync(int id);

        Task<Product> CreateAsync(Product product);

        Task<Product> UpdateAsync(Product product);

        Task<Product> DeleteAsync(int id);
    }
}
