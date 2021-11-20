using Microsoft.EntityFrameworkCore;
using ProgrammingClass2.Angular.Data;
using ProgrammingClass2.Angular.Models;
using ProgrammingClass2.Angular.Repositories.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.Angular.Repositories.Implementations
{
    public class CurrencyRepository: ICurrencyRepository
    {
        private readonly ApplicationDbContext _context;

        public CurrencyRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<Currency>> GetAllAsync()
        {
            return await _context.Currencies.ToListAsync();
        }

        public async Task<Currency> GetAsync(int id)
        {
            return await _context.Currencies.FindAsync(id);
        }

        public async Task<Currency> AddAsync(Currency currency)
        {
            _context.Currencies.Add(currency);
            await _context.SaveChangesAsync();

            return currency;
        }

        public async Task<Currency> UpdateAsync(Currency currecny)
        {
            _context.Currencies.Update(currecny);
            await _context.SaveChangesAsync();

            return currecny;
        }

        public async Task<Currency> DeleteAsync(int id)
        {
            var currency = await GetAsync(id);

            if (currency != null)
            {
                _context.Currencies.Remove(currency);
                await _context.SaveChangesAsync();

                return currency;
            }
            return null;
        }
    }
}
