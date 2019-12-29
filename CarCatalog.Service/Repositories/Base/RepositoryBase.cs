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
    public abstract class RepositoryBase<T> : IDataRepository<T> where T : Entity
    {
        private readonly DbContext _repositoryContext;
        protected DbContext RepositoryContext { get => _repositoryContext; }
        protected RepositoryBase(DbContext repositoryContext)
        {
            _repositoryContext = repositoryContext ?? throw new ArgumentNullException(nameof(repositoryContext));
        }

        public async Task Delete(T value) 
        {
            _repositoryContext.Set<T>().Remove(value);
            await _repositoryContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _repositoryContext.Set<T>().Where(x => !x.IsDeleted).ToListAsync();
        }

        public async Task<IEnumerable<T>> GetByCondition(Expression<Func<T, bool>> expression)
        {
            return await _repositoryContext.Set<T>()
                                           .Where(e => !e.IsDeleted)
                                           .Where(expression)
                                           .ToListAsync();
        }

        public async Task<Guid> Insert(T value)
        {
            _repositoryContext.Set<T>().Add(value);
            await _repositoryContext.SaveChangesAsync();

            return value.Id;
        }

        public async Task Update(T value)
        {
            _repositoryContext.Set<T>().Update(value);
            await _repositoryContext.SaveChangesAsync();
        }
    }
}
