using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarCatalog.Database.Base;
using CarCatalog.Service.Messages;
using CarCatalog.Service.Messages.Base;
using CarCatalog.Service.Repositories.Base.Business;
using CarCatalog.Service.Repositories.Interfaces.Business;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarCatalog.WebAPI.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BusinessBaseController<C, Repository, Rp, Rq> : ControllerBase 
        where C : Entity
        where Repository : IBusinessRepository<Rp, Rq>
        where Rp : BusinessObject
        where Rq : BusinessObject
    {
        private readonly IBusinessRepository<Rp, Rq> _repository;

        protected BusinessBaseController(IBusinessRepository<Rp, Rq> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public virtual async Task<ActionResult<IEnumerable<Rp>>> Get()
        {
            var businessObjects = await _repository.Get();

            if (businessObjects == null)
                return NotFound();

            return Ok(businessObjects.ToList());
        }

        [HttpGet("details/{id:guid}")]
        public virtual async Task<ActionResult<Rp>> Get(Guid id)
        {
            var businessObject = await _repository.Get(id);

            if (businessObject == null)
                return NotFound();

            return businessObject;
        }

        [HttpPost]
        public virtual async Task<ActionResult<IDictionary<string, Guid>>> Post([CustomizeValidator(Interceptor = typeof(PostMessageInterceptor))][FromBody] Rq categoryRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                //TODO Refactor
                var bussinessObject = await _repository.Insert(categoryRequest);
                var responseProperties = bussinessObject.GetType()
                    .GetProperties()
                    .Where(x => x.PropertyType.IsSubclassOf(typeof(BusinessObject)) == true)
                    .Select(x => (BusinessObject)x.GetValue(bussinessObject));

                var responseBusiness = responseProperties.Select(x => new KeyValuePair<string, Guid>(x.GetType().Name.Replace("Response", "Id"), x.Id));

                var response = new Dictionary<string, Guid>
                {
                    { bussinessObject.GetType().Name.Replace("Response", "Id"), bussinessObject.Id }
                };

                responseBusiness.ToList().ForEach(x => response.Add(x.Key, x.Value));

                return Ok(response);

            }
            catch (Exception)
            {
                return NotFound();
            }

        }

        [HttpPut]
        public virtual async Task<ActionResult> Put([FromBody] Rq categoryRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                await _repository.Update(categoryRequest);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("remove/{id:guid}")]
        public virtual async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var toRemove = await _repository.Get(id);

                if (toRemove == null)
                    return NotFound();

                await _repository.Delete(id);

                return Ok();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}