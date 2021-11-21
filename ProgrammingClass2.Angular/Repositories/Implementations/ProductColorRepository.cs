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
    public class ProductColorRepository : IProductColorRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductColorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductColor>> GetAllAsync(int productId)
        {
            return await _context
                .ProductColors
                .Include(p => p.Color)
                .Where(p => p.ProductId == productId)
                .ToListAsync();
        }

        public async Task<ProductColor> GetAsync(int productId, int colorId)
        {
            return await _context
                .ProductColors
                .Include(p => p.Color)
                .Include(p => p.Product)
                .SingleOrDefaultAsync(p => p.ProductId == productId && p.ColorId == colorId);
        }

        public async Task<ProductColor> AddAsync(ProductColor productColor)
        {
            _context.ProductColors.Add(productColor);
            await _context.SaveChangesAsync();

            return productColor;
        }

        public async Task<ProductColor> DeleteAsync(int productId, int colorId)
        {
            var productColor = await GetAsync(productId, colorId);

            if (productColor != null)
            {
                _context.ProductColors.Remove(productColor);
                await _context.SaveChangesAsync();

                return productColor;
            }

            return null;
        }
    }
}
