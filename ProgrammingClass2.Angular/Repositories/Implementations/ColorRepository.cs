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
    public class ColorRepository : IColorRepository
    {
        private readonly ApplicationDbContext _context;

        public ColorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Color>> GetAllAsync()
        {
            return await _context.Colors.ToListAsync();
        }

        public async Task<Color> GetAsync(int id)
        {
            return await _context
                .Colors
                .FindAsync(id);
        }

        public async Task<Color> CreateAsync(Color color)
        {
            _context.Colors.Add(color);
            await _context.SaveChangesAsync();

            return color;
        }

        public async Task<Color> UpdateAsync(Color color)
        {
            _context.Colors.Update(color);
            await _context.SaveChangesAsync();

            return color;
        }

        public async Task<Color> DeleteAsync(int id)
        {
            var color = await GetAsync(id);

            if (color != null)
            {
                _context.Colors.Remove(color);
                await _context.SaveChangesAsync();

                return color;
            }

            return null;
        }
    }
}
