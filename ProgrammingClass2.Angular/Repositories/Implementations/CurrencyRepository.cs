using ProgrammingClass2.Angular.Data;
using ProgrammingClass2.Angular.Models;
using ProgrammingClass2.Angular.Repositories.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.Angular.Repositories.Implementations
{
    public class CurrencyRepository : ICurrencyRepository
    {

        private readonly ApplicationDbContext _context;

        public CurrencyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Currency> GetAll()
        {
            return _context.Currencies.ToList();
        }

        public Currency Get(int id)
        {
            return _context.Currencies.Find(id);
        }

        public Currency Create(Currency currency)
        {
            _context.Currencies.Add(currency);
            _context.SaveChanges();

            return currency;
        }

        public Currency Update(Currency currency)
        {
            _context.Currencies.Update(currency);
            _context.SaveChanges();

            return currency;
        }

        public Currency Delete(int id)
        {
            var currency = Get(id);

            if (currency != null)
            {
                _context.Currencies.Remove(currency);
                _context.SaveChanges();

                return currency;
            }

            return null;
        }

    }
}
