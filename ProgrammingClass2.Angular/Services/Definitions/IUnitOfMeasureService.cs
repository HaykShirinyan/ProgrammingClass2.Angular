using ProgrammingClass2.Angular.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.Angular.Services.Definitions
{
    public interface IUnitOfMeasureService
    {
        Task<List<UnitOfMeasureDto>> GetAllAsync();

        Task<UnitOfMeasureDto> GetAsync(int id);

        Task<UnitOfMeasureDto> CreateAsync(UnitOfMeasureDto dto);

        Task<UnitOfMeasureDto> UpdateAsync(UnitOfMeasureDto dto);

        Task<UnitOfMeasureDto> DeleteAsync(int id);
    }
}
