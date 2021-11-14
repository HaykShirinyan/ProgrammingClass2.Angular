using ProgrammingClass2.Angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.Angular.Repositories.Definitions
{
    public interface IColorRepository
    {
        List<Collor> GetAll();
        Collor Get(int id);
        Collor Create(Collor color);
        Collor Update(Collor color);
        Collor Delete(int id);

    }
}
