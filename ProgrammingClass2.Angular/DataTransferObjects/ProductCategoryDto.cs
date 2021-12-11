using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.Angular.DataTransferObjects
{
    public class ProductCategoryDto
    {
        [Required]
        public ReferencedProductDto Product { get; set; }

        [Required]
        public ReferencedCategoryDto Category { get; set; }
    }
}
