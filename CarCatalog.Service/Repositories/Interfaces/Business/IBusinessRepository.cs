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
        Task<IEnumerable<T>> Get(Expression<Func<U, bool>> expression);
        Task<T> Create(U request);
        Task Update(U request);
        Task Delete(Guid id);
    }
}
