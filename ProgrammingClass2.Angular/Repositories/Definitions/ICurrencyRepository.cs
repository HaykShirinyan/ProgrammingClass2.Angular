using ProgrammingClass2.Angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.Angular.Repositories.Definitions
{
   public interface ICurrencyRepository
    {
        Task<List<Currency>> GetAllAsync();

        Task<Currency> GetAsync(int id);

        Task<Currency> AddAsync(Currency currency);

        Task<Currency> UpdateAsync(Currency currecny);

        Task<Currency> DeleteAsync(int id);
    }
}
