using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgrammingClass2.Angular.DataTransferObjects;
using ProgrammingClass2.Angular.Models;
using ProgrammingClass2.Angular.Services.Definitions;
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
        private readonly IProductTypeService _productTypeService;

        public ProductTypesController(IProductTypeService productTypeService) 
        {
            _productTypeService = productTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var productType = await _productTypeService.GetAllProductTypesAsync();
            return Ok(productType);
        }

        [HttpGet("{id}")] 
        public async Task<IActionResult> GetAsync(int id)
        {
            var productTypes = await _productTypeService.GetAsync(id);

            if (productTypes != null )
            {
                return Ok(productTypes);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(ProductType productType)
        {
            if (this.ModelState.IsValid)
            {
                var created = await _productTypeService.CreateAsync(productType);

                return Ok(created);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, ProductType productType)
        {
            if (this.ModelState.IsValid)
            {
                if (id != productType.Id)
                {
                    return BadRequest();
                }
                var updated = await _productTypeService.UpdateAsync(productType);

                return Ok(updated);
            }
            return BadRequest(ModelState);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var deleted = await _productTypeService.DeleteAsync(id); 

            if (deleted != null)
            {
                return Ok(deleted);
            }

            return NotFound();
        }
    }
}
