using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarCatalog.Database.Entities;
using CarCatalog.Service.Messages.Request;
using CarCatalog.Service.Messages.Response;
using CarCatalog.Service.Repositories.Base.Business;
using CarCatalog.Service.Repositories.Base.Business.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace CarCatalog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly BusinessRepository<Category, CategoryResponse, CategoryRequest> _repository;

        public CategoryController(BusinessRepository<Category, CategoryResponse, CategoryRequest> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryResponse>>> Get()
        {
            var category = await _repository.Get();

            if (category == null)
                return NotFound();

            return category.ToList();
        }

        [HttpGet("details/{id:guid}")]
        public async Task<ActionResult<CategoryResponse>> Get(Guid id)
        {
            var category = await _repository.Get(id);

            if (category == null)
                return NotFound();

            return category;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Post([FromBody] CategoryRequest categoryRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(categoryRequest);

            try
            {
                var result = await _repository.Create(categoryRequest);
                return Ok(result);

            }
            catch(Exception)
            {
                return NotFound();
            }

        }

        [HttpDelete("remove/{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                await _repository.Delete(id);

                return Ok();
            }
            catch(Exception)
            {
                return NotFound();
            }
        }
    }
}