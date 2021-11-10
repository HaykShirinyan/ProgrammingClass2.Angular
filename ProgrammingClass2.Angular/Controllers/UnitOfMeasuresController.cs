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
    [Route("api/unit-of-measures")]
    [ApiController]
    public class UnitOfMeasuresController : ControllerBase
    {
        private readonly IUnitOfMeasureRepository _unitOfMeasureRepository;

        public UnitOfMeasuresController(IUnitOfMeasureRepository unitOfMeasureRepository)
        {
            _unitOfMeasureRepository = unitOfMeasureRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var unitOfMeasures = _unitOfMeasureRepository.GetAllUnitOfMeasures();
            return Ok(unitOfMeasures);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var unitOfMeasures = _unitOfMeasureRepository.Get(id);

            if (unitOfMeasures != null)
            {
                return Ok(unitOfMeasures);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Create(UnitOfMeasure unitOfMeasure)
        {
            if (this.ModelState.IsValid)
            {
                var created = _unitOfMeasureRepository.Create(unitOfMeasure);
                return Ok(created);
            }

            return BadRequest(this.ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UnitOfMeasure unitOfMeasure)
        {
            if (this.ModelState.IsValid)
            {
                if (id != unitOfMeasure.Id)
                {
                    return BadRequest();
                }

                var updated = _unitOfMeasureRepository.Update(unitOfMeasure);
                return Ok(updated);
            }

            return BadRequest(this.ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _unitOfMeasureRepository.Delete(id);

            if (deleted != null)
            {
                return Ok(deleted);
            }

            return NotFound();
        }
    }
}
