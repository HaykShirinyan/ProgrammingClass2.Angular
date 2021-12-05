using ProgrammingClass2.Angular.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.Angular.Services.Definitions
{
    public interface ICurrencyService
    {
        Task<List<CurrencyDto>> GetAllAsync();

        Task<CurrencyDto> GetAsync(int id);

        Task<CurrencyDto> CreateAsync(CurrencyDto dto);

        Task<CurrencyDto> UpdateAsync(CurrencyDto dto);

        Task<CurrencyDto> DeleteAsync(int id);
    }
}
