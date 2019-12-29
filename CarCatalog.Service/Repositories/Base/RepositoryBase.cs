using CarCatalog.Database;
using CarCatalog.Database.Base;
using CarCatalog.Service.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarCatalog.Service.Repositories.Base
{
    public abstract class RepositoryBase<T,Context> : IDataRepository<T> 
        where T : Entity
        where Context : DbContext
    {
        private readonly Context _repositoryContext;
        protected Context Repository { get => _repositoryContext; }
        protected RepositoryBase(Context repositoryContext)
        {
            _repositoryContext = repositoryContext ?? throw new ArgumentNullException(nameof(repositoryContext));
        }

        public virtual async Task Delete(Guid id) 
        {
            var entity = await _repositoryContext.Set<T>().FindAsync(id);

            if (entity != null)
            {
                _repositoryContext.Set<T>().Remove(entity);
                await _repositoryContext.SaveChangesAsync();
            }
        }

        public virtual async Task<IEnumerable<T>> Get()
        {
            return await _repositoryContext.Set<T>().Where(x => !x.IsDeleted).ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return await _repositoryContext.Set<T>()
                                           .Where(e => !e.IsDeleted)
                                           .Where(expression)
                                           .ToListAsync();
        }

        public virtual async Task<T> Insert(T value)
        {
            _repositoryContext.Set<T>().Add(value);
            await _repositoryContext.SaveChangesAsync();

            return value;
        }

        public virtual async Task Update(T value)
        {
            _repositoryContext.Set<T>().Update(value);
            await _repositoryContext.SaveChangesAsync();
        }
    }
}
