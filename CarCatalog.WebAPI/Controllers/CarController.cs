using CarCatalog.Database.Entities;
using CarCatalog.Service.Messages;
using CarCatalog.Service.Messages.Request;
using CarCatalog.Service.Messages.Response;
using CarCatalog.Service.Repositories.Base.Business;
using CarCatalog.Service.Repositories.Models;
using CarCatalog.WebAPI.Controllers.Base;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarCatalog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : BusinessBaseController<Car, CarRepository, CarResponse, CarRequest>
    {
        private readonly CarRepository _repository;
        public CarController(CarRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        [HttpGet("vin/")]
        public async Task<ActionResult<CarResponse>> GetByVIN(string vin)
        {
            try
            {
                var response = await _repository.Get(c => c.VIN == vin);

                if (response == null)
                    return NotFound();

                return Ok(response);
            }
            catch(Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("type/")]
        public async Task<ActionResult<IEnumerable<CarResponse>>> GetByType(string type)
        {
            try
            {
                var cars = await _repository.Get(x => Enum.GetName(typeof(Database.Entities.Type), x.Type) == type.ToLowerInvariant().First().ToString().ToUpperInvariant());

                if (cars == null)
                    return NotFound();

                return Ok(cars);
            }
            catch(Exception)
            {
                return NotFound();
            }
        }

        [HttpGet("manufacturer/")]
        public async Task<ActionResult<IEnumerable<CarResponse>>> GetByManufacturer(string manufacturer)
        {
            try
            {
                var cars = await _repository.Get(c => c.Manufacturer.ToLowerInvariant() == manufacturer.ToLowerInvariant());

                if (cars == null)
                    return NotFound();

                return Ok(cars);
            }
            catch(Exception)
            {
                return NotFound();
            }
        }
        //TODO
        //[HttpPost("")]
        //public async Task<ActionResult> Post(Guid catalogId, [CustomizeValidator(Interceptor = typeof(PostMessageInterceptor))][FromBody] CarRequest car)
        //{

        //}
    }
}