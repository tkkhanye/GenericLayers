using CoreFacade.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFacade.Repository
{
    public interface ILookupRepository
    {
        IList<LookupModel> GetAll<TModel>(int? parentId = null) where TModel : LookupModel;
    }
}
