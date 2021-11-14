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

        public List<Collor> GetAll()
        {
            return _context.Collors.ToList();
        }

        public Collor Get(int id)
        {
            return _context.Collors.Find(id);
        }

        public Collor Create(Collor color)
        {
            _context.Collors.Add(color);
            _context.SaveChanges();

            return color;
        }

        public Collor Update(Collor color)
        {
            _context.Collors.Update(color);
            _context.SaveChanges();

            return color;
        }

        public Collor Delete(int id)
        {
            var color = Get(id);

            if (color != null)
            {
                _context.Collors.Remove(color);
                _context.SaveChanges();

                return color;
            }

            return null;
        }

    }
}

    

