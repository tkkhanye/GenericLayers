using CoreFacade.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFacade.Logic
{
    public interface ILookupLogic
    {
        IList<LookupModel> GetAllEstablishmentTypes();
    }
}
