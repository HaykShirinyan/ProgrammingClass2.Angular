using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgrammingClass2.Angular.Data;
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
        public IActionResult Index()
        {
            var currencies = _currencyRepository.GetAll();
            return Ok(currencies);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Currency = _currencyRepository.Get(id);

            if (Currency != null)
            {
                return Ok(Currency);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Create(Currency currency)
        {
            if (ModelState.IsValid)
            {
                var created = _currencyRepository.Create(currency);

                return Ok(created);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Currency currency)
        {
            if (ModelState.IsValid)
            {
                if (id != currency.Id)
                {
                    return BadRequest();
                }

                var updated = _currencyRepository.Update(currency);

                return Ok(updated);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _currencyRepository.Delete(id);

            if (deleted != null)
            {
                return Ok(deleted);
            }

            return NotFound();
        }
    }
}

