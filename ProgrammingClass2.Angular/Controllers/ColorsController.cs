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
    [Route("api/colors")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly IColorRepository _colorRepository;

        public ColorsController(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var colors = await _colorRepository.GetAllAsync();

            return Ok(colors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var color = await _colorRepository.GetAsync(id);
            if (color == null)
            {
                return NotFound();
            }
            return Ok(color);
        }

        [HttpPost]

        public async Task<IActionResult> AddAsync(Color color)
        {
            if (this.ModelState.IsValid)
            {
                var added = await _colorRepository.AddAsync(color);
                return Ok(added);
            }
            return BadRequest(this.ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, Color color)
        {
            if (this.ModelState.IsValid) {
                if (id != color?.Id)
                {
                    return BadRequest();
                }
                var updated = await _colorRepository.UpdateAsync(color);
                return Ok(updated);
            }
            return BadRequest(this.ModelState);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteAsync (int id)
        {
            var deleted = _colorRepository.DeleteAsync(id);

            if (deleted == null)
            {
                return NotFound();
            }
            return Ok(deleted);
        }
    }
}
