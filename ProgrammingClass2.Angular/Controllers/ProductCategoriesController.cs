using Microsoft.AspNetCore.Authorization;
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
    // /api/products/5/categories
    [Route("api/products/{productId}/categories")]
    [ApiController]
    [Authorize]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductCategoriesController(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository = productCategoryRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllAsync(int productId)
        {
            var productCategories = await _productCategoryRepository.GetAllAsync(productId);
            return Ok(productCategories);
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetAsync(int productId, int categoryId)
        {
            var productCategory = await _productCategoryRepository.GetAsync(productId, categoryId);

            if (productCategory != null)
            {
                return Ok(productCategory);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(int productId, ProductCategory productCategory)
        {
            if (this.ModelState.IsValid)
            {
                if (productId != productCategory?.ProductId)
                {
                    return BadRequest();
                }

                var added = await _productCategoryRepository.AddAsync(productCategory);
                return Ok(added);
            }

            return BadRequest(this.ModelState);
        }

        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> DeleteAsync(int productId, int categoryId)
        {
            var deleted = await _productCategoryRepository.DeleteAsync(productId, categoryId);

            if (deleted != null)
            {
                return Ok(deleted);
            }

            return NotFound();
        }
    }
}
