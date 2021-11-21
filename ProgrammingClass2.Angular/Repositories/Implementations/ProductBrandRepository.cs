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
    public class ProductBrandRepository : IProductBrandRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductBrandRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductBrand>> GetAllAsync(int productId)
        {
            return await _context
                .ProductBrands
                .Include(p => p.Brand)
                .Where(p => p.ProductId == productId)
                .ToListAsync();
        }

        public async Task<ProductBrand> GetAsync(int productId, int brandId)
        {
            return await _context
                .ProductBrands
                .Include(p => p.Brand)
                .Include(p => p.Product)
                .SingleOrDefaultAsync(p => p.ProductId == productId && p.BrandId == brandId);
        }

        public async Task<ProductBrand> AddAsync(ProductBrand productBrand)
        {
            _context.ProductBrands.Add(productBrand);
            await _context.SaveChangesAsync();

            return productBrand;
        }

        public async Task<ProductBrand> DeleteAsync(int productId, int brandId)
        {
            var productBrand = await GetAsync(productId, brandId);

            if (productBrand != null)
            {
                _context.ProductBrands.Remove(productBrand);
                await _context.SaveChangesAsync();

                return productBrand;
            }

            return null;
        }
    }
}
