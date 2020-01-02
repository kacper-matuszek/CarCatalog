using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarCatalog.Database.Entities;
using CarCatalog.Service.Messages.Request;
using CarCatalog.Service.Messages.Response;
using CarCatalog.Service.Repositories.Base.Business;
using CarCatalog.Service.Repositories.Models;
using CarCatalog.WebAPI.Controllers.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarCatalog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EngineController : BusinessBaseController<Engine, EngineRepository, EngineResponse, EngineRequest>
    {
        private readonly EngineRepository _repository;
        public EngineController(EngineRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        [HttpGet("fuel/{fuel}")]
        public async Task<ActionResult<IEnumerable<EngineResponse>>> GetByFuel(string fuel)
        {
            try
            {
                var engines = await _repository.Get(e => Enum.GetName(typeof(EngineFuel), e.Fuel) == fuel.ToLowerInvariant().First().ToString().ToUpperInvariant());

                if (engines == null)
                    return NotFound();

                return Ok(engines.ToList());
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("horsepower/{horsepower}")]
        public async Task<ActionResult<IEnumerable<EngineResponse>>> GetByHorsePower(int horsepower,[FromQuery] bool greater = false)
        {
            try
            {
                IEnumerable<EngineResponse> engines;

                if (greater)
                    engines = await _repository.Get(x => x.HorsePower >= horsepower);

                engines = await _repository.Get(e => e.HorsePower <= horsepower);

                if (engines == null)
                    return NotFound();

                return Ok(engines.ToList());
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpGet("code/{code}")]
        public async Task<ActionResult<IEnumerable<EngineResponse>>> GetByCode(string code)
        {
            try
            {
                var engines = await _repository.Get(e => e.Code.ToLowerInvariant() == code.ToLowerInvariant());

                if (engines == null)
                    return NotFound();

                return Ok(engines.ToList());
            }
            catch(Exception e)
            {
                return NotFound(e.Message);
            }
        }
    }
}