using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreFacade.Models;
using CoreFacade.Logic;
using Microsoft.AspNetCore.Authorization;
using CoreConcerns.Security;

namespace CoreAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    public abstract class BaseController<TModel> : Controller
        where TModel : AuditedBaseModel
    {
        protected IGenericLogic<TModel> _logic;


        public BaseController(IGenericLogic<TModel> logic)
        {
            _logic = logic;
        }

        [HttpGet("{id}")]
        public virtual TModel Get(Guid Id) => _logic.GetById(Id);

        // GET api/values
        [HttpGet]
        public virtual IEnumerable<TModel> Get() => _logic.GetAll();

        // GET api/values
        [HttpPost]
        public virtual TModel Post([FromBody]TModel model) => _logic.Save(model);
    }
}