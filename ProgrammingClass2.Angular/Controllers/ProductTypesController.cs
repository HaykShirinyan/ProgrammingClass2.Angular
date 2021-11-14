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
    [Route("api/product-types")]
    [ApiController]
    public class ProductTypesController : ControllerBase
    {
        private readonly IProductTypeRepository _productTypeRepository;

        public ProductTypesController(IProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var productTypes = _productTypeRepository.GetAllProductTypes();
            return Ok(productTypes);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var productTypes = _productTypeRepository.Get(id);

            if (productTypes != null)
            {
                return Ok(productTypes);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Create(ProductType productType)
        {
            if (this.ModelState.IsValid)
            {
                var created = _productTypeRepository.Create(productType);
                return Ok(created);
            }

            return BadRequest(this.ModelState);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ProductType productType)
        {
            if (this.ModelState.IsValid)
            {
                if (id != productType.Id)
                {
                    return BadRequest();
                }

                var updated = _productTypeRepository.Update(productType);
                return Ok(updated);
            }

            return BadRequest(this.ModelState);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _productTypeRepository.Delete(id);

            if (deleted != null)
            {
                return Ok(deleted);
            }

            return NotFound();
        }
    }
}
