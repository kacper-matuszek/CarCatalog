using AutoMapper;
using CarCatalog.Database.Base;
using CarCatalog.Service.Messages.Base;
using CarCatalog.Service.Repositories.Interfaces.Business;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarCatalog.Service.Repositories.Base.Business
{
    public abstract class BusinessRepository<C,Context, Rp, Rq> : IBusinessRepository<Rp, Rq> 
        where Rp : BusinessObject 
        where Rq : BusinessObject 
        where C : Entity
        where Context : DbContext
    {
        private const string CreateObject = "Create";
        private IServiceProvider _serviceProvider;
        private RepositoryBase<C, Context> _repository;
        private readonly IMapper _mapper;
        
        protected BusinessRepository(Context context)
        {
            _repository = (CommonRepository<C, Context>)_serviceProvider.GetService(typeof(CommonRepository<C, Context>));
        }

        public virtual async Task<Rp> Insert(Rq request)
        {
            var entity = _mapper.Map<C>(request, opt => opt.Items[CreateObject] = true);
            await _repository.Insert(entity);

            return _mapper.Map<Rp>(entity);
        }

        public virtual async Task Delete(Guid id)
        {
            await _repository.Delete(id);
        }

        public virtual async Task<IEnumerable<Rp>> Get()
        {
            var businessObjects = _mapper.Map<IEnumerable<Rp>>(await _repository.Get());
             return await Task.FromResult(businessObjects);
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
    }
}
