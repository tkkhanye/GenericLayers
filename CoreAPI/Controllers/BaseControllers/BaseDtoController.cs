using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreFacade.Models;
using CoreAPI.DTOs;
using CoreFacade.Logic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;

namespace CoreAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    public abstract class BaseDtoController<TModel, TDto> : Controller
        where TModel : AuditedBaseModel
        where TDto : BaseDto
    {
        protected IMapper _mapper;
        protected IGenericLogic<TModel> _logic;

        public BaseDtoController(IMapper mapper, IGenericLogic<TModel> logic){
            _mapper = mapper;
            _logic = logic;
        }

        [HttpGet()]
        public virtual IEnumerable<TDto> Get() => _mapper.Map<List<TDto>>(_logic.GetAll());
        [HttpGet("{id}")]
        public virtual TDto Get(Guid Id) => _mapper.Map<TDto>(_logic.GetById(Id));
        [HttpPost]
        public virtual TDto Post([FromBody]TDto model) => _mapper.Map<TDto>( _logic.Save(_mapper.Map<TModel>(model)));
    }
}