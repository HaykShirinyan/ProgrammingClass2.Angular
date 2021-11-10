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
        List<UnitOfMeasure> GetAllUnitOfMeasures();

        UnitOfMeasure Get(int id);

        UnitOfMeasure Create(UnitOfMeasure unitOfMeasure);

        UnitOfMeasure Update(UnitOfMeasure unitOfMeasure);

        UnitOfMeasure Delete(int id);
    }
}
