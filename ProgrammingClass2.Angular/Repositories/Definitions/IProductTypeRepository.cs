using ProgrammingClass2.Angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.Angular.Repositories.Definitions
{
    public interface IProductTypeRepository
    {
        List<ProductType> GetAll();
        ProductType Get(int id);
        ProductType Create(ProductType productType);
        ProductType Update(ProductType productType);
        ProductType Delete(int id);
    }
}
