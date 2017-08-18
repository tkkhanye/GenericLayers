using CoreFacade.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFacade.Repository
{
    public interface IEnumLookupRepository
    {
        IList<LookupModel> GetAll<TEnum>();
    }
}
