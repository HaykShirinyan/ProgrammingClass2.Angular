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
    [Route("api/product/{productId}/colors")]
    [ApiController]
    public class ProductColorsController : ControllerBase
    {
        private readonly IProductColorRepository _productColorRepository;

        public ProductColorsController(IProductColorRepository productColorRepository)
        {
            _productColorRepository = productColorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int productId)
        {
            var productColors = await _productColorRepository.GetAllAsync(productId);
            return Ok(productColors);
        }

        [HttpGet("colorId")]
        public async Task<IActionResult> GetAsycn(int productId, int colorId)
        {
            var productColor = await _productColorRepository.GetAsync(productId, colorId);

            if (productColor != null)
            {
                return Ok(productColor);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(int productId, ProductColor productColor)
        {
            if (this.ModelState.IsValid)
            {
                if (productId != productColor?.ProductId)
                {
                    return BadRequest();
                }
                var added = await _productColorRepository.AddAsync(productColor);
                return Ok(added);
            }
            return BadRequest(this.ModelState);
        }

        [HttpDelete("ColorId")]
        public async Task<IActionResult> DeleteAsync (int productId, int colorId)
        {
            var deleted = await _productColorRepository.DeleteAsync(productId, colorId);
            if (deleted != null)
            {
                return Ok(deleted);
            }
            return NotFound();
        }
    }
}
