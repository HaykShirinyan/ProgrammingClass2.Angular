using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProgrammingClass2.Angular.Data;
using ProgrammingClass2.Angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.Angular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrenciesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CurrenciesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var currencies = _context.Currencies.ToList();
            return Ok(currencies);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Currency = _context.Currencies.Find(id);

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
                _context.Currencies.Add(currency);
                _context.SaveChanges();

                return Ok(currency);
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

                _context.Currencies.Update(currency);
                _context.SaveChanges();

                return Ok(currency);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var currency = _context.Currencies.Find(id);

            if (currency != null)
            {
                _context.Remove(currency);
                _context.SaveChanges();

                return Ok(currency);
            }

            return NotFound();
        }
    }
}

