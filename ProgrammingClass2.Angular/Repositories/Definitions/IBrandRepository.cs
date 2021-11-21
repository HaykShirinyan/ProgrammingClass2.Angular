using ProgrammingClass2.Angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.Angular.Repositories.Definitions
{
    public interface IBrandRepository
    {
        Task<List<Brand>> GetAllAsync();

        Task<Brand> GetAsync(int id);

        Task<Brand> AddAsync(Brand category);

        Task<Brand> UpdateAsync(Brand category);

        Task<Brand> DeleteAsync(int id);
    }
}
