using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarCatalog.Service.Repositories.Interfaces
{
   public interface IDataRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> expression);
        Task<Guid> Insert(T value);
        Task Update(T value);
        Task Delete(T value);
    }
}
