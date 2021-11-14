using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass2.Angular.Data;
using ProgrammingClass2.Angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.Angular.Controllers
{
    // Ays controller-i bolor endpoint-nere sksum en /api/products URL-ov.
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // /api/products
        [HttpGet]
        public IActionResult Index()
        {
            var products = _context
                .Products
                .Include(p => p.UnitOfMeasure)
                .Include(p => p.ProductType)
                .ToList();

            return Ok(products);
        }

        // /api/products/45
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _context.Products.Find(id);

            if (product != null)
            {
                return Ok(product);
            }

            return NotFound();
        }

        // /api/products
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                _context.SaveChanges();

                    return Ok(product);
                }

            // BadRequest(ModelState) het enq veradardznum erb ModelStat valid chi.
            // Aysinqn erb validaiton-i error-ner kan.
            return BadRequest(ModelState);
        }

        // HttpPut ogtagorcum en update anenlu hamar.
        // /api/products/45
        [HttpPut("{id}")]
        public IActionResult Update(int id, Product product)
        {
            if (ModelState.IsValid)
            {
                if (id != product.Id)
                {
                    return BadRequest();
                }

                _context.Products.Update(product);
                _context.SaveChanges();

                return Ok(product);
            }

            // BadRequest(ModelState) het enq veradardznum erb ModelStat valid chi.
            // Aysinqn erb validaiton-i error-ner kan.
            return BadRequest(ModelState);
        }

        // /api/products/45
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);

            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();

                return Ok(product);
            }

            return NotFound();
        }
    }
}
