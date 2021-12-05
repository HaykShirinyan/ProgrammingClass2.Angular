using ProgrammingClass2.Angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.Angular.Repositories.Definitions
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllAsync();

        Task<Category> GetAsync(int id);

        Task<Category> CreateAsync(Category category);

        Task<Category> UpdateAsync(Category category);

        Task<Category> DeleteAsync(int id);
    }
}
