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
    [Route("api/products/{productId}/currencies")]
    [ApiController]
    public class ProductCurrenciesController : ControllerBase
    {
        private readonly IProductCurrencyRepository _productCurrencyRepository;

        public ProductCurrenciesController(IProductCurrencyRepository productCurrencyRepository)
        {
            _productCurrencyRepository = productCurrencyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int productId)
        {
            var productCurrencies = await _productCurrencyRepository.GetAllAsync(productId);
            return Ok(productCurrencies);
        }

        [HttpGet("{currencyId}")]
        public async Task<IActionResult> GetAsync(int productId, int currencyId)
        {
            var productCurrency = await _productCurrencyRepository.GetAsync(productId, currencyId);

            if (productCurrency != null)
            {
                return Ok(productCurrency);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(int productId, ProductCurrency productCurrency)
        {
            if (this.ModelState.IsValid)
            {
                if (productId != productCurrency?.ProductId)
                {
                    return BadRequest();
                }
                var added = await _productCurrencyRepository.AddAsync(productCurrency);
                return Ok(added);
            }
            return BadRequest(this.ModelState);
        }

        [HttpDelete("{currencyId}")]
        public async Task<IActionResult> DeleteAsync(int productId, int currencyId)
        {
            var deleted = await _productCurrencyRepository.DeleteAsync(productId, currencyId);

            if (deleted != null)
            {
                return Ok(deleted);
            }
            return NotFound();
        }
    }
}
