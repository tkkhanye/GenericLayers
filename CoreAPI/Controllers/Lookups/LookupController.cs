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
    [Route("api/Lookup")]
    [Authorize]
    public class LookupController : Controller
    {
        private ILookupLogic _logic;

        public LookupController(ILookupLogic logic)
        {
            _logic = logic;
        }

        // GET api/values
        [HttpGet("GetEstablishmentTypes")]
        [AllowAnonymous]
        public virtual IEnumerable<LookupModel> GetEstablishmentTypes() => _logic.GetAllEstablishmentTypes();
    }
}