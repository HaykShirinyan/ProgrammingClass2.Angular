using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProgrammingClass2.Angular.Data;
using ProgrammingClass2.Angular.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProgrammingClass2.Angular.Controllers
{
    [Route("api/colors")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ColorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // /api/colors
        [HttpGet]
        public IActionResult Index()
        {
            var colors = _context.Colors.ToList();
            return Ok(colors);
        }

        // /api/colors/45
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var color = _context.Colors.Find(id);

            if (color != null)
            {
                return Ok(color);
            }

            return NotFound();
        }

        // /api/colors
        [HttpPost]
        public IActionResult Create(Color color)
        {
            if (ModelState.IsValid)
            {
                _context.Colors.Add(color);
                _context.SaveChanges();

                return Ok(color);
            }

            return BadRequest(ModelState);
        }

        // /api/colors/45
        [HttpPut("{id}")]
        public IActionResult Update(int id, Color color)
        {
            if (ModelState.IsValid)
            {
                if (id != color.Id)
                {
                    return BadRequest();
                }

                _context.Colors.Update(color);
                _context.SaveChanges();

                return Ok(color);
            }

            return BadRequest(ModelState);
        }

        // /api/colors/45
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var color = _context.Colors.Find(id);

            if (color != null)
            {
                _context.Colors.Remove(color);
                _context.SaveChanges();

                return Ok(color);
            }

            return NotFound();
        }
    }
}
