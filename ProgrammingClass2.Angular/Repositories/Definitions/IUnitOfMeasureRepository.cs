using ProgrammingClass2.Angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.Angular.Repositories.Definitions
{
    public interface IUnitOfMeasureRepository
    {
        // Es function vernagirn a. Sranc aveli konkret asum en function signature.
        Task<List<UnitOfMeasure>> GetAllAsync();

        Task<UnitOfMeasure> GetAsync(int id);

        Task<UnitOfMeasure> CreateAsync(UnitOfMeasure unitOfMeasure);

        Task<UnitOfMeasure> UpdateAsync(UnitOfMeasure unitOfMeasure);

        Task<UnitOfMeasure> DeleteAsync(int id);
    }
}
