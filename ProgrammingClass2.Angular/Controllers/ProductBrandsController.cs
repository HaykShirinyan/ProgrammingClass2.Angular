
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgrammingClass2.Angular.Models;
using ProgrammingClass2.Angular.Repositories.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.Angular.Controllers
{
    [Route("api/products/{productId}/brands")]
    [ApiController]
    public class ProductBrandsController : ControllerBase
    {
        private readonly IProductBrandRepository _productBrandRepository;

        public ProductBrandsController(IProductBrandRepository productBrandRepository)
        {
            _productBrandRepository = productBrandRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int productId)
        {
            var productBrands = await _productBrandRepository.GetAllAsync(productId);
            return Ok(productBrands);
        }

        [HttpGet("{brandId}")]
        public async Task<IActionResult> GetAsync(int productId, int brandId)
        {
            var productBrand = await _productBrandRepository.GetAsync(productId, brandId);

            if (productBrand != null)
            {
                return Ok(productBrand);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(int productId, ProductBrand productBrand)
        {
            if (this.ModelState.IsValid)
            {
                if (productId != productBrand?.ProductId)
                {
                    return BadRequest();
                }

                var added = await _productBrandRepository.AddAsync(productBrand);
                return Ok(added);
            }

            return BadRequest(this.ModelState);
        }

        [HttpDelete("{brandId}")]
        public async Task<IActionResult> DeleteAsync(int productId, int brandId)
        {
            var deleted = await _productBrandRepository.DeleteAsync(productId, brandId);

            if (deleted != null)
            {
                return Ok(deleted);
            }

            return NotFound();
        }
    }
}