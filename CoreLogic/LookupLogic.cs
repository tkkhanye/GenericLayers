using CoreFacade.Enums;
using CoreFacade.Logic;
using CoreFacade.Models;
using CoreFacade.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLogic
{
    public class LookupLogic : ILookupLogic
    {
        private IEnumLookupRepository _enumRepository;
        private ILookupRepository _lookupRepository;

        public LookupLogic(IEnumLookupRepository enumRepository, ILookupRepository lookupRepository)
        {
            _enumRepository = enumRepository;
            _lookupRepository = lookupRepository;
        }

        public IList<LookupModel> GetAllEstablishmentTypes() => _enumRepository.GetAll<EstablishmentType>();
    }
}
