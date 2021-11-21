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
    [Route("api/currencies")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        private readonly ICurrencyRepository _currencyRepository;

        public CurrenciesController(ICurrencyRepository currencyRepository)
        {
            _currencyRepository = currencyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var currencies = await _currencyRepository.GetAllAsync();
            return Ok(currencies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var currency = await _currencyRepository.GetAsync(id);

            if (currency == null)
            {
                return NotFound();
            }

            return Ok(currency);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(Currency currency)
        {
            if (this.ModelState.IsValid)
            {
                var added = await _currencyRepository.AddAsync(currency);
                return Ok(added);
            }

            return BadRequest(this.ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, Currency currency)
        {
            if (this.ModelState.IsValid)
            {
                if (id != currency?.Id)
                {
                    return BadRequest();
                }

                var updated = await _currencyRepository.UpdateAsync(currency);
                return Ok(updated);
            }

            return BadRequest(this.ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var deleted = await _currencyRepository.DeleteAsync(id);

            if (deleted == null)
            {
                return NotFound();
            }

            return Ok(deleted);
        }
    }
}
