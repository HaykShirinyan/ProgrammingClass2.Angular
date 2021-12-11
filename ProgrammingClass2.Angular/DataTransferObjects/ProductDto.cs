﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.Angular.DataTransferObjects
{
    public class ProductDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(300)]
        public string Description { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }

        public ReferencedUnitOfMeasureDto UnitOfMeasure { get; set; }
    }

    public class ReferencedProductDto
    {
        [Required]
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
