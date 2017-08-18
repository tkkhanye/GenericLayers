using CoreConcerns.Security;
using CoreContext;
using CoreFacade.Concerns;
using CoreFacade.Models;
using CoreFacade.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CoreRepository
{
    public abstract class GenericRepository<TModel> : IGenericRepository<TModel>
        where TModel : AuditedBaseModel
    {
        protected DbContext _context;
        protected DbSet<TModel> _dbSet;
        protected IQueryable<TModel> _dbQuery;
        protected IPrincipalSecurityConcern _security;

        protected DbContext Context => _context;
        protected virtual List<string> Includes { get; } = new List<string>();

        public GenericRepository(RepoContext context, IPrincipalSecurityConcern security)
        {
            _context = context;
            _dbSet = context.Set<TModel>();
            _dbQuery = context.Set<TModel>();
            _security = security;
        }

        public virtual IList<TModel> GetAll() => _dbQuery.Where(x => !x.Deleted).ToList();

        public virtual IList<TModel> GetByCreatedUserId(Guid userId) => _dbQuery.Where(x => !x.Deleted && x.CreatedUserId == userId).ToList();

        public virtual TModel GetById(Guid Id) => _dbQuery.FirstOrDefault(x => x.Id == Id);

        public virtual TModel Save(TModel model)
        {
            model.ModifiedTime = DateTime.Now;
            model.ModifiedUserId = _security.LoggedInUserId;

            if (model.Id == Guid.Empty)
            {
                //New entry
                model.CreatedTime = DateTime.Now;
                model.CreatedUserId = _security.LoggedInUserId;

                _dbSet.Add(model);
            }
            else
            {
                _dbSet.Update(model);
                _context.Entry(model).Property(x => x.CreatedTime).IsModified = false;
                _context.Entry(model).Property(x => x.CreatedUserId).IsModified = false;
            }

            _context.SaveChanges();

            return model;
        }
    }
}
