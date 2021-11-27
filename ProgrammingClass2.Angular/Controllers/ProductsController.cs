using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass2.Angular.Data;
using ProgrammingClass2.Angular.Models;
using ProgrammingClass2.Angular.Repositories.Definitions;
using ProgrammingClass2.Angular.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.Angular.Controllers
{
    // Ays controller-i bolor endpoint-nere sksum en /api/products URL-ov.
    [Route("api/products")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // /api/products
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            var products = _productRepository.GetAll();

            return Ok(products);
        }

        // /api/products/45
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _productRepository.Get(id);

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
                var created = _productRepository.Create(product);

                return Ok(created);
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

                var updated = _productRepository.Update(product);

                return Ok(updated);
            }

            // BadRequest(ModelState) het enq veradardznum erb ModelStat valid chi.
            // Aysinqn erb validaiton-i error-ner kan.
            return BadRequest(ModelState);
        }

        // /api/products/45
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _productRepository.Delete(id);

            if (deleted != null)
            {
                return Ok(deleted);
            }

            return NotFound();
        }
    }
}
