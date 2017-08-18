using CoreFacade.Logic;
using CoreFacade.Models;
using CoreFacade.Repository;
using System;
using System.Collections.Generic;

namespace CoreLogic
{
    public abstract class GenericLogic<TModel> : IGenericLogic<TModel>
        where TModel : AuditedBaseModel
    {
        private IGenericRepository<TModel> _repository;

        public GenericLogic(IGenericRepository<TModel> repository)
        {
            _repository = repository;
        }

        public IList<TModel> GetByCreatedUserId(Guid userId) => _repository.GetByCreatedUserId(userId);
        public IList<TModel> GetAll() => _repository.GetAll();
        public TModel GetById(Guid Id) => _repository.GetById(Id);

        public TModel Save(TModel model) => _repository.Save(model);
    }
}
