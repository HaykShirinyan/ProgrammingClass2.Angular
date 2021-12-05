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
    public class ProductTypeRepository : IProductTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<ProductType>> GetAllAsync()
        {
            return _context.ProductTypes.ToListAsync();
        }

        public Task<ProductType> GetAsync(int id)
        {
            return _context.ProductTypes.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<ProductType> CreateAsync(ProductType productType)
        {
            _context.ProductTypes.Add(productType);
            await _context.SaveChangesAsync();

            return productType;
        }

        public async Task<ProductType> UpdateAsync(ProductType productType)
        {
            _context.ProductTypes.Update(productType);
            await _context.SaveChangesAsync();

            return productType;
        }

        public async Task<ProductType> DeleteAsync(int id)
        {
            var productType = await GetAsync(id);

            if (productType != null)
            {
                _context.ProductTypes.Remove(productType);
                await _context.SaveChangesAsync();

                return productType;
            }

            return null;
        }
    }
}
