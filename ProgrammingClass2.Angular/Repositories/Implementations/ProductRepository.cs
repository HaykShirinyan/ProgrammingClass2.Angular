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
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAll()
        {
            return _context
                .Products
                .Include(p => p.UnitOfMeasure)
                .Include(p => p.Currency)
                .Include(p => p.ProductType)
                .ToList();
        }

        public Product Get(int id)
        {
            return _context.Products.Find(id);
        }

        public Product Create(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

            return product;
        }

        public Product Update(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();

            return product;
        }

        public Product Delete(int id)
        {
            var product = Get(id);

            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();

                return product;
            }

            return null;
        }
    }
}
    

