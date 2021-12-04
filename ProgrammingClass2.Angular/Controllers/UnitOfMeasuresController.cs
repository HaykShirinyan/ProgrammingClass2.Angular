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
    [Route("api/unit-of-measures")]
    [ApiController]
    [Authorize]
    public class UnitOfMeasuresController : ControllerBase
    {
        private readonly IUnitOfMeasureService _unitOfMeasureService;

        public UnitOfMeasuresController(IUnitOfMeasureService unitOfMeasureService)
        {
            _unitOfMeasureService = unitOfMeasureService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var unitOfMeasures = await _unitOfMeasureService.GetAllAsync();
            return Ok(unitOfMeasures);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var unitOfMeasure = await _unitOfMeasureService.GetAsync(id);

            if (unitOfMeasure != null)
            {
                return Ok(unitOfMeasure);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(UnitOfMeasureDto unitOfMeasure)
        {
            if (this.ModelState.IsValid)
            {
                var created = await _unitOfMeasureService.CreateAsync(unitOfMeasure);

                return Ok(created);
            }

            return BadRequest(this.ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, UnitOfMeasureDto unitOfMeasure)
        {
            if (this.ModelState.IsValid)
            {
                if (id != unitOfMeasure.Id)
                {
                    return BadRequest();
                }

                var updated = await _unitOfMeasureService.UpdateAsync(unitOfMeasure);

                return Ok(updated);
            }

            return BadRequest(this.ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var deleted = await _unitOfMeasureService.DeleteAsync(id);

            if (deleted != null)
            {
                return Ok(deleted);
            }

            return NotFound();
        }
    }
}
