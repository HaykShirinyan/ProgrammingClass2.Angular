using ProgrammingClass2.Angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.Angular.Repositories.Definitions
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product Get(int id);
        Product Create(Product product);
        Product Update(Product product);
        Product Delete(int id);
    }
}
