using ProgrammingClass2.Angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.Angular.Repositories.Definitions
{
    public interface IColorRepository
    {
        Task<List<Color>> GetAllAsync();

        Task<Color> GetAsync(int id);

        Task<Color> AddAsync(Color color);

        Task<Color> UpdateAsync(Color color);

        Task<Color> DeleteAsync(int id);
    }
}
