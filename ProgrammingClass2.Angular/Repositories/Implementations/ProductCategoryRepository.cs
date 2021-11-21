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
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ProductCategory>> GetAllAsync(int productId)
        {
            return await _context
                .ProductCategories
                .Include(p => p.Category)
                .Where(p => p.ProductId == productId)
                .ToListAsync();
        }

        public async Task<ProductCategory> GetAsync(int productId, int categoryId)
        {
            return await _context
                .ProductCategories
                .Include(p => p.Category)
                .Include(p => p.Product)
                .SingleOrDefaultAsync(p => p.ProductId == productId && p.CategoryId == categoryId);
        }

        public async Task<ProductCategory> AddAsync(ProductCategory productCategory)
        {
            _context.ProductCategories.Add(productCategory);
            await _context.SaveChangesAsync();

            return productCategory;
        }

        public async Task<ProductCategory> DeleteAsync(int productId, int categoryId)
        {
            var productCategory = await GetAsync(productId, categoryId);

            if (productCategory != null)
            {
                _context.ProductCategories.Remove(productCategory);
                await _context.SaveChangesAsync();

                return productCategory;
            }

            return null;
        }
    }
}
