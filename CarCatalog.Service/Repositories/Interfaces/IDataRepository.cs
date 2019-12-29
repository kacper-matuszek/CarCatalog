using CarCatalog.Database.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarCatalog.Service.Repositories.Interfaces
{
   public interface IDataRepository<T> where T : Entity
    {
        Task<IEnumerable<T>> Get();
        Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> expression);
        Task<T> Insert(T value);
        Task Update(T value);
        Task Delete(Guid id);
    }
}
