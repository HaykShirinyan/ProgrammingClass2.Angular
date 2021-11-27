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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ColorsController : ControllerBase
    {
        private readonly IColorRepository _colorRepository;
        public ColorsController(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            var colors = _colorRepository.GetAll();
            return Ok(colors);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Color = _colorRepository.Get(id);

            if (Color != null)
            {
                return Ok(Color);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Create(Collor color)
        {
            if (ModelState.IsValid)
            {
                var created = _colorRepository.Create(color);

                return Ok(created);
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Collor color)
        {
            if (ModelState.IsValid)
            {
                if (id != color.Id)
                {
                    return BadRequest();
                }

                var updated = _colorRepository.Update(color);

                return Ok(updated);
            }

            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _colorRepository.Delete(id);

            if (deleted != null)
            {
                return Ok(deleted);
            }

            return NotFound();
        }
    }
}

