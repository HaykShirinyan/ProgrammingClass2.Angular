using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass2.Angular.DataTransferObjects;
using ProgrammingClass2.Angular.Services.Definitions;
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
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // /api/products
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        // /api/products/45
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var product = await _productService.GetAsync(id);

            if (product != null)
            {
                return Ok(product);
            }

            return NotFound();
        }

        // /api/products
        [HttpPost]
        public async Task<IActionResult> CreateAsync(ProductDto product)
        {
            if (ModelState.IsValid)
            {
                var created = await _productService.CreateAsync(product);
                return Ok(created);
            }

            // BadRequest(ModelState) het enq veradardznum erb ModelStat valid chi.
            // Aysinqn erb validaiton-i error-ner kan.
            return BadRequest(ModelState);
        }

        // HttpPut ogtagorcum en update anenlu hamar.
        // /api/products/45
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, ProductDto product)
        {
            if (ModelState.IsValid)
            {
                if (id != product.Id)
                {
                    return BadRequest();
                }

                var updated = await _productService.UpdateAsync(product);

                return Ok(updated);
            }

            // BadRequest(ModelState) het enq veradardznum erb ModelStat valid chi.
            // Aysinqn erb validaiton-i error-ner kan.
            return BadRequest(ModelState);
        }

        // /api/products/45
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var deleted = await _productService.DeleteAsync(id);

            if (deleted != null)
            {               
                return Ok(deleted);
            }

            return NotFound();
        }
    }
}
