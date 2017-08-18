using CoreFacade.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using CoreFacade.Models;
using CoreContext;
using System.Linq;
using AutoMapper;

namespace CoreRepository
{
    public class LookupRepository : ILookupRepository
    {
        private RepoContext _context;
        private IMapper _mapper;

        public LookupRepository(RepoContext context, IMapper mapper) {
            _context = context;
            _mapper = mapper;
        }

        public IList<LookupModel> GetAll<TModel>(int? parentId = null) where TModel : LookupModel
        {
            return _mapper.Map<List<LookupModel>>(_context.Set<TModel>().Where(x => !x.Deleted && (parentId == null || x.ParentId == parentId)).ToList());
        }
    }
}
