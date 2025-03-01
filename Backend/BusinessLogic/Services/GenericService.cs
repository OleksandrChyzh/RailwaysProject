using AutoMapper;
using BusinessLogic.Interfaces;
using BusinessLogic.Validation;
using DAL.Entities;
using DAL.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLogic.Services
{
    public abstract class GenericService<TEntity, TModel> : ICrud<TModel>
          where TEntity : BaseEntity
          where TModel : class
    {
        protected abstract IRepository<TEntity> _repository { get; set; }
        protected readonly IUnitOfWork _uof;
        protected readonly IMapper _mapper;

        protected GenericService(IUnitOfWork uof, IMapper mapper)
        {
            _uof = uof;
            _repository = uof.GetRepository<TEntity>();
            _mapper = mapper;
        }

        public virtual async Task AddAsync(TModel model)
        {
            Validate(model);
            await _repository.AddAsync(_mapper.Map<TEntity>(model));
            await _uof.SaveAsync();
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
                message.AppendLine($"Validation error. Can't validate {model.GetType().Name}. Problems:");

                foreach (var error in results)
                {
                    message.AppendLine(error.ErrorMessage);
                }

                throw new RailwaysException(message.ToString(), new ValidationException());
            }
        }

        public virtual async Task DeleteAsync(int modelId)
        {
            var entity = await _repository.GetByIdAsync(modelId);
            if (entity is null)
            {
                throw new EntityNotFoundException(typeof(TEntity).Name, modelId);
            }

            await _repository.DeleteByIdAsync(modelId);
            await _uof.SaveAsync();
        }

        public virtual async Task<IEnumerable<TModel>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TModel>>(entities);
        }

        public virtual async Task<TModel> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity is null)
            {
                throw new EntityNotFoundException(typeof(TEntity).Name, id);
            }

            return _mapper.Map<TModel>(entity);
        }

        public virtual async Task UpdateAsync(TModel model)
        {
            Validate(model);
            var entity = _mapper.Map<TEntity>(model);
            await _repository.UpdateAsync(entity);
            await _uof.SaveAsync();
        }
    }
}
