using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgrammingClass2.Angular.Data;
using ProgrammingClass2.Angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.Angular.Controllers
{
    [Route("api/product-types")]
    [ApiController]
    public class ProductTypesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductTypesController(ApplicationDbContext context) 
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var productType = _context.ProductTypes.ToList();
            return Ok(productType);
        }

        [HttpGet("{id}")] 
        public IActionResult Get(int id)
        {
            var productType = _context.ProductTypes.Find(id);

            if (productType != null )
            {
                return Ok(productType);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Create(ProductType productType)
        {
            if (ModelState.IsValid)
            {
                _context.ProductTypes.Add(productType);
                _context.SaveChanges();

                return Ok(productType);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ProductType productType)
        {
            if (ModelState.IsValid)
            {
                if (id != productType.Id)
                {
                    return BadRequest();
                }
                _context.Update(productType);
                _context.SaveChanges();

                return Ok(productType);
            }
            return BadRequest(ModelState);
        }
        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var productType = _context.ProductTypes.Find(id);

            if (productType != null)
            {
                _context.ProductTypes.Remove(productType);
                _context.SaveChanges();

                return Ok(productType);
            }

            return NotFound();
        }
    }
}
