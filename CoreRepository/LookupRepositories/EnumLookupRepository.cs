using CoreFacade.Models;
using CoreFacade.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CoreRepository
{
    public class EnumLookupRepository : IEnumLookupRepository
    {
        public IList<LookupModel> GetAll<TEnum>()
        {
            var values = Enum.GetNames(typeof(TEnum));

            return values.Select((x, idx) => new LookupModel
            {
                Id = idx + 1,
                Code = x,
                Deleted = false,
                Description = x,
                Name = x
            }).ToList();
        }
    }
}
