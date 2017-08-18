using CoreFacade.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFacade.Logic
{
    public interface IGenericLogic<TModel>
        where TModel : AuditedBaseModel
    {
        TModel GetById(Guid Id);
        IList<TModel> GetAll();
        IList<TModel> GetByCreatedUserId(Guid userId);
        TModel Save(TModel model);
    }
}
