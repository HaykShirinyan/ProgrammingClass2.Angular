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
    public class ProductCurrencyRepository : IProductCurrencyRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductCurrencyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductCurrency>> GetAllAsync(int productId)
        {
            return await _context
                .ProductCurrencies
                .Include(p => p.Currency)
                .Where(p => p.ProductId == productId)
                .ToListAsync();
        }

        public async Task<ProductCurrency> GetAsync(int productId, int currencyId)
        {
            return await _context
                .ProductCurrencies
                .Include(p => p.Currency)
                .Include(p => p.Product)
                .SingleOrDefaultAsync(p => p.ProductId == productId && p.CurrencyId == currencyId);
        }

        public async Task<ProductCurrency> AddAsync(ProductCurrency productCurrency)
        {
            _context.ProductCurrencies.Add(productCurrency);
            await _context.SaveChangesAsync();

            return productCurrency;
        }

        public async Task<ProductCurrency> DeleteAsync(int productId, int currencyId)
        {
            var productCurrency = await GetAsync(productId, currencyId);

            if (productCurrency != null)
            {
                _context.ProductCurrencies.Remove(productCurrency);
                await _context.SaveChangesAsync();

                return productCurrency;
            }

            return null;
        }
    }
}
