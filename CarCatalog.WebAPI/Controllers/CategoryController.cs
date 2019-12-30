using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarCatalog.Database.Entities;
using CarCatalog.Service.Messages;
using CarCatalog.Service.Messages.Request;
using CarCatalog.Service.Messages.Response;
using CarCatalog.Service.Repositories.Base.Business;
using CarCatalog.Service.Repositories.Models;
using CarCatalog.WebAPI.Controllers.Base;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;

namespace CarCatalog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : BusinessBaseController<Category, CategoryRepository, CategoryResponse, CategoryRequest>
    {
        private readonly CategoryRepository _repository;
        public CategoryController(CategoryRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        [HttpGet("details/")]
        public async Task<ActionResult<CategoryResponse>> GetByName(string name)
        {
            try
            {
                var categories = await _repository.Get(x => x.Name == name);

                if (categories != null)
                    return Ok(categories.SingleOrDefault());

                return NotFound();
            }
            catch(InvalidOperationException)
            {
                return BadRequest();
            }
            catch(Exception)
            {
                return NotFound();
            }
        }
    }
}