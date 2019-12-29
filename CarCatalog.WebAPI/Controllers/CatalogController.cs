using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarCatalog.Database.Entities;
using CarCatalog.Service.Messages;
using CarCatalog.Service.Messages.Request;
using CarCatalog.Service.Messages.Response;
using CarCatalog.Service.Repositories.Base;
using CarCatalog.Service.Repositories.Base.Business;
using CarCatalog.Service.Repositories.Models;
using CarCatalog.WebAPI.Controllers.Base;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarCatalog.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : BusinessBaseController<Catalog, CatalogResponse, CatalogRequest>
    {
        public CatalogController(BusinessRepository<Catalog, CatalogResponse, CatalogRequest> repository, IServiceProvider provider)
            : base(repository)
        {
        }

        [HttpGet("{userId:guid}")]
        public async Task<ActionResult<IEnumerable<CatalogResponse>>> GetList(Guid userId)
        {
            try
            {
                var catalogs = await _repository.Get(x => x.User.Id == userId);

                if (catalogs == null)
                    return NotFound();

                return Ok(catalogs);
            }
            catch(Exception)
            {
                return NotFound();
            }
        }
    }
}