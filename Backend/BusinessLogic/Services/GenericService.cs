using AutoMapper;
using BusinessLogic.Interfaces;
using BusinessLogic.Validation;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public abstract class GenericService<TEntity, TModel> : ICrud<TModel>
          where TEntity : BaseEntity
          where TModel : class
    {
        protected abstract IRepository<TEntity> _repository { get; }
        protected readonly IUnitOfWork _uof;
        protected readonly IMapper _mapper;

        protected GenericService(IUnitOfWork uof, IMapper mapper)
        {
            _uof = uof;
            _mapper = mapper;
        }
        public virtual async Task AddAsync(TModel model)
        {
            Validate(model);
            await _repository.AddAsync(_mapper.Map<TEntity>(model))
            .ContinueWith(async t => await _uof.SaveAsync());
        }

        protected void Validate(object model)
        {
            if (model is null)
                throw new RailwaysException("Model is null", new NullReferenceException());
            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(model, context, results, true))
            {
                var message = new StringBuilder();
                message.AppendLine($"Validation error. Can`t validate {model.GetType().Name}. Validation problems:");
                foreach (var error in results)
                {
                    message.AppendLine(error.ErrorMessage);
                }
                throw new RailwaysException(message.ToString(), new ValidationException());
            }

        }

        public virtual async Task DeleteAsync(int modelId)
        {
            await _repository.DeleteByIdAsync(modelId)
                .ContinueWith(async t => await _uof.SaveAsync());
        }

        public  virtual async Task<IEnumerable<TModel>> GetAllAsync()
        {
            var a = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TModel>>(a);
        }

        public  virtual async  Task<TModel> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id)
                .ContinueWith(t => _mapper.Map<TModel>(t.Result));
        }

        public virtual async Task UpdateAsync(TModel model)
        {
            Validate(model);
            var entity = _mapper.Map<TEntity>(model);
            _repository.UpdateAsync(entity);
            await _uof.SaveAsync();
        }
    }
}
