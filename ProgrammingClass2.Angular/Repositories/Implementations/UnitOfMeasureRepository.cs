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
    public class UnitOfMeasureRepository : IUnitOfMeasureRepository
    {
        private readonly ApplicationDbContext _context;

        public UnitOfMeasureRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<UnitOfMeasure>> GetAllAsync()
        {
            return _context.UnitOfMeasures.ToListAsync();
        }

        public Task<UnitOfMeasure> GetAsync(int id)
        {
            return _context.UnitOfMeasures.SingleOrDefaultAsync(u => u.Id == id);
        }

        public async Task<UnitOfMeasure> CreateAsync(UnitOfMeasure unitOfMeasure)
        {
            _context.UnitOfMeasures.Add(unitOfMeasure);
            await _context.SaveChangesAsync();

            return unitOfMeasure;
        }

        public async Task<UnitOfMeasure> UpdateAsync(UnitOfMeasure unitOfMeasure)
        {
            _context.UnitOfMeasures.Update(unitOfMeasure);
            await _context.SaveChangesAsync();

            return unitOfMeasure;
        }

        public async Task<UnitOfMeasure> DeleteAsync(int id)
        {
            var unitOfMeasure = await GetAsync(id);

            if (unitOfMeasure != null)
            {
                _context.UnitOfMeasures.Remove(unitOfMeasure);
                await _context.SaveChangesAsync();

                return unitOfMeasure;
            }

            return null;
        }
    }
}
