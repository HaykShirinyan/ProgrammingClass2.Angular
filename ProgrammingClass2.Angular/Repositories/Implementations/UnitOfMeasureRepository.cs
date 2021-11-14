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

        public List<UnitOfMeasure> GetAllUnitOfMeasures()
        {
            return _context.UnitOfMeasures.ToList();
        }

        public UnitOfMeasure Get(int id)
        {
            return _context.UnitOfMeasures.Find(id);
        }

        public UnitOfMeasure Create(UnitOfMeasure unitOfMeasure)
        {
            _context.UnitOfMeasures.Add(unitOfMeasure);
            _context.SaveChanges();

            return unitOfMeasure;
        }

        public UnitOfMeasure Update(UnitOfMeasure unitOfMeasure)
        {
            _context.UnitOfMeasures.Update(unitOfMeasure);
            _context.SaveChanges();

            return unitOfMeasure;
        }

        public UnitOfMeasure Delete(int id)
        {
            var unitOfMeasure = Get(id);

            if (unitOfMeasure != null)
            {
                _context.UnitOfMeasures.Remove(unitOfMeasure);
                _context.SaveChanges();

                return unitOfMeasure;
            }

            return null;
        }
    }
}
