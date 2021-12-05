using ProgrammingClass2.Angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.Angular.Repositories.Definitions
{
    public interface IProductCurrencyRepository
    {
        Task<List<ProductCurrency>> GetAllAsync(int productId);

        Task<ProductCurrency> GetAsync(int productId, int currencyId);

        Task<ProductCurrency> CreateAsync(ProductCurrency productCurrency);

        Task<ProductCurrency> DeleteAsync(int productId, int currencyId);
    }
}
