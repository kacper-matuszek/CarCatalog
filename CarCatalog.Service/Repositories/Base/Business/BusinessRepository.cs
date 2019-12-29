using AutoMapper;
using CarCatalog.Database.Base;
using CarCatalog.Service.Messages.Base;
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
    public abstract class BusinessRepository<C, Rp, Rq> : IBusinessRepository<Rp, Rq> where Rp : BusinessObject where Rq : BusinessObject where C : Entity
    {
        private const string CreateObject = "Create";
        private readonly RepositoryBase<C> _repository;
        private readonly IMapper _mapper;
        protected BusinessRepository(RepositoryBase<C> repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public virtual async Task<Rp> Create(Rq request)
        {
            var entity = _mapper.Map<C>(request, opt => opt.Items[CreateObject] = true);
            await _repository.Insert(entity);

            return _mapper.Map<Rp>(entity);
        }

        public virtual async Task Delete(Guid id)
        {
            var entityToDel = await _repository.GetByCondition(c => c.Id == id);
            await _repository.Delete(entityToDel.FirstOrDefault());
        }

        public virtual async Task<IEnumerable<Rp>> Get()
        {
             return await Task.FromResult(MappingFromEntity(await _repository.GetAll()));
        }

        public virtual async Task<Rp> Get(Guid id)
        {
            var entities = await _repository.GetByCondition(e => e.Id == id);

            return await Task.FromResult(_mapper.Map<Rp>(entities.SingleOrDefault()));
        }

        public virtual async Task<IEnumerable<Rp>> Get(Expression<Func<Rq, bool>> expression)
        {
            var entityExpression = _mapper.Map<Expression<Func<C, bool>>>(expression);
            var entities = await _repository.GetByCondition(entityExpression);

            var response = _mapper.Map<IEnumerable<Rp>>(entities);

            return response;
        }

        public virtual async Task Update(Rq request)
        {
            var entity = _mapper.Map<C>(request);
            await _repository.Update(entity);
        }

        private IEnumerable<Rp> MappingFromEntity(IEnumerable<C> entities)
        {
            var response = new List<Rp>();
            entities.ToList().ForEach(e =>
            {
                response.Add(_mapper.Map<Rp>(e));
            });

            return response;
        }
    }
}
