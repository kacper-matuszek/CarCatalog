using CarCatalog.Service.Messages.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarCatalog.Service.Repositories.Interfaces.Business
{
    public interface IBusinessRepository<T, U>
        where T : BusinessObject
        where U : BusinessObject
    {
        Task<IEnumerable<T>> Get();
        Task<T> Get(Guid id);
        Task<IEnumerable<T>> Get(Expression<Func<U, bool>> expression);
        Task<T> Insert(U request);
        Task Update(U request);
        Task Delete(Guid id);
    }
}
