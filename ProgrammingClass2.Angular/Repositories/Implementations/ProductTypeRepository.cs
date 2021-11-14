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

        public ProductTypeRepository (ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ProductType> GetAllProductTypes()
        {
            return _context.ProductTypes.ToList();

        }

        public ProductType Create(ProductType productType)
        {
            _context.ProductTypes.Add(productType);
            _context.SaveChanges();

            return productType;
        }

        public ProductType Get(int id)
        {
            return _context.ProductTypes.Find(id);
        }

        public ProductType Update(ProductType productType)
        {
            _context.ProductTypes.Update(productType);
            _context.SaveChanges();

            return productType;
        }

        public ProductType Delete(int id)
        {
            var productType = Get(id);
            
            if (productType != null)
            {
                _context.ProductTypes.Remove(productType);
                _context.SaveChanges();

                return productType;
            }

            return null;
        }
    }
}
