using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreFacade.Models;
using CoreAPI.DTOs;
using AutoMapper;
using CoreFacade.Logic;

namespace CoreAPI.Controllers
{
    public abstract class BaseUserDtoController<TModel, TDto> : BaseDtoController<TModel, TDto>
        where TModel : AuditedBaseModel
        where TDto : BaseDto
    {
        protected Guid LoggedInUserId => Guid.Parse(HttpContext?.User?.Claims?.Where(x => x.Subject is System.Security.Claims.ClaimsIdentity)?.FirstOrDefault()?.Value);

        public BaseUserDtoController(IMapper mapper, IGenericLogic<TModel> logic) : base(mapper, logic)
        {
        }

        public override IEnumerable<TDto> Get()=>_mapper.Map<List<TDto>>(_logic.GetByCreatedUserId(LoggedInUserId));
        
    }
}