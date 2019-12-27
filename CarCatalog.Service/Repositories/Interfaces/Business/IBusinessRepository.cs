using CarCatalog.Service.Repositories.Base.Business.Helpers;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarCatalog.Service.Repositories.Interfaces.Business
{
    public interface IBusinessRepository<T, U>
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(Guid id);
        Task<Guid> Create(U request);
        Task Update(U request);
        Task Delete(Guid id);
    }
}
