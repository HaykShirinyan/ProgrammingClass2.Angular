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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // Task veradardznox function-nere, voronq kareli e await-ov kanchel anune dnum enq "Async" verjavorutjamb
        public async Task<List<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetAsync(int id)
        {
            return await _context
                .Categories
                .FindAsync(id);
        }

        public async Task<Category> CreateAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<Category> DeleteAsync(int id)
        {
            var category = await GetAsync(id);

            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();

                return category;
            }

            return null;
        }
    }
}
