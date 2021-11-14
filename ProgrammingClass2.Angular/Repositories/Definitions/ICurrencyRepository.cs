using ProgrammingClass2.Angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.Angular.Repositories.Definitions
{
    public interface ICurrencyRepository
    {
        List<Currency> GetAll();
        Currency Get(int id);
        Currency Create(Currency currency);
        Currency Update(Currency currency);
        Currency Delete(int id);

    }
}
