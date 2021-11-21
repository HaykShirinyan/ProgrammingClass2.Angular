using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.Angular.Models
{
    public class ProductCurrency
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
    }
}
