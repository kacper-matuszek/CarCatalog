using AutoMapper;
using CarCatalog.Database.Base;
using CarCatalog.Service.Repositories.Base.Business.Helpers;
using CarCatalog.Service.Repositories.Interfaces.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarCatalog.Service.Repositories.Base.Business
{
    public abstract class BusinessRepository<C, T, U> : IBusinessRepository<T, U> where T : class where U : class where C : Entity
    {
        private readonly RepositoryBase<C> _repository;
        private readonly IMapper _mapper;
        protected BusinessRepository(RepositoryBase<C> repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public virtual async Task<Guid> Create(U request)
        {
            var entity = _mapper.Map<C>(request);
            return await _repository.Insert(entity);
        }

        public virtual async Task Delete(Guid id)
        {
            var entityToDel = await _repository.GetByCondition(c => c.Id == id);
            await _repository.Delete(entityToDel.FirstOrDefault());
        }

        public virtual async Task<IEnumerable<T>> Get()
        {
             return await Task.FromResult(MappingFromEntity(await _repository.GetAll()));
        }

        public virtual async Task<T> Get(Guid id)
        {
            var entities = await _repository.GetByCondition(e => e.Id == id);

            return await Task.FromResult(_mapper.Map<T>(entities.SingleOrDefault()));
        }

        public virtual async Task Update(U request)
        {
            var entity = _mapper.Map<C>(request);
            await _repository.Update(entity);
        }

        private IEnumerable<T> MappingFromEntity(IEnumerable<C> entities)
        {
            var response = new List<T>();
            entities.ToList().ForEach(e =>
            {
                response.Add(_mapper.Map<T>(e));
            });

            return response;
        }
    }
}
