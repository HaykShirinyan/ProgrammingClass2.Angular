using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.Angular.Models
{
    public class ProductBrand
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}

