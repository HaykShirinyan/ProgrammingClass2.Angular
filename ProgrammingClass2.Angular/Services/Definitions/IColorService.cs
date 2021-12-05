using ProgrammingClass2.Angular.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.Angular.Services.Definitions
{
    public interface IColorService
    {
        Task<List<ColorDto>> GetAllAsync();

        Task<ColorDto> GetAsync(int id);

        Task<ColorDto> CreateAsync(ColorDto color);

        Task<ColorDto> UpdateAsync(ColorDto dto);

        Task<ColorDto> DeleteAsync(int id);
    }
}
