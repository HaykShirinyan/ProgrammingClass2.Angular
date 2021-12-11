using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgrammingClass2.Angular.DataTransferObjects;
using ProgrammingClass2.Angular.Models;
using ProgrammingClass2.Angular.Repositories.Definitions;
using ProgrammingClass2.Angular.Services.Definitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.Angular.Controllers
{
    // /api/products/5/categories
    [Route("api/products/{productId}/categories")]
    [ApiController]
    public class ProductCategoriesController : ControllerBase
    {
        private readonly IProductCategoryService _productCategoryService;

        public ProductCategoriesController(IProductCategoryService productCategoryService)
        {
            _productCategoryService = productCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int productId)
        {
            var productCategories = await _productCategoryService.GetAllAsync(productId);
            return Ok(productCategories);
        }

        [HttpGet("{categoryId}")]
        public async Task<IActionResult> GetAsync(int productId, int categoryId)
        {
            var productCategory = await _productCategoryService.GetAsync(productId, categoryId);

            if (productCategory != null)
            {
                return Ok(productCategory);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(int productId, ProductCategoryDto productCategory)
        {
            if (this.ModelState.IsValid)
            {
                if (productId != productCategory?.Product?.Id)
                {
                    return BadRequest();
                }

                var added = await _productCategoryService.AddAsync(productCategory);
                return Ok(added);
            }

            return BadRequest(this.ModelState);
        }

        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> DeleteAsync(int productId, int categoryId)
        {
            var deleted = await _productCategoryService.DeleteAsync(productId, categoryId);

            if (deleted != null)
            {
                return Ok(deleted);
            }

            return NotFound();
        }
    }
}
