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
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var category = await _categoryRepository.GetAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(Category category)
        {
            if (this.ModelState.IsValid)
            {
                var added = await _categoryRepository.AddAsync(category);
                return Ok(added);
            }

            return BadRequest(this.ModelState);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, Category category)
        {
            if (this.ModelState.IsValid)
            {
                if (id != category?.Id)
                {
                    return BadRequest();
                }

                var updated = await _categoryRepository.UpdateAsync(category);
                return Ok(updated);
            }

            return BadRequest(this.ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var deleted = await _categoryRepository.DeleteAsync(id);

            if (deleted == null)
            {
                return NotFound();
            }

            return Ok(deleted);
        }
    }
}
