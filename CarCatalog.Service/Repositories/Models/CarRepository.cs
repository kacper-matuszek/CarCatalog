using AutoMapper;
using CarCatalog.Database.Entities;
using CarCatalog.Service.Messages.Request;
using CarCatalog.Service.Messages.Response;
using CarCatalog.Service.Repositories.Base;
using CarCatalog.Service.Repositories.Base.Business;

namespace CarCatalog.Service.Repositories.Models
{
    public class CarRepository : BusinessRepository<Car, CarResponse, CarRequest>
    {
        public CarRepository(RepositoryBase<Car> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
