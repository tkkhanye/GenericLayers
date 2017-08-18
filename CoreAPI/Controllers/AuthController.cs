using System;
using Microsoft.AspNetCore.Mvc;
using CoreFacade.Logic;
using CoreFacade.Models;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using CoreAPI.DTOs;
using CoreFacade.Concerns;

namespace CoreAPI.Controllers
{
    [Route("auth")]
    [Produces("application/json")]
    public class AuthController : Controller
    {
        private IAuthLogic _logic;
        private IMapper _mapper;
        private IPrincipalSecurityConcern _security;

        public AuthController(IMapper mapper, IAuthLogic logic, IPrincipalSecurityConcern security)
        {
            _logic = logic;
            _mapper = mapper;
            _security = security;
        }

        [AllowAnonymous]
        [HttpPost("signup")]
        public UserToken SignUp([FromBody] UserDto user) => _logic.SignUp(_mapper.Map<User>(user));

        [AllowAnonymous]
        [HttpPost("signin")]
        public UserToken SignIn([FromBody] UserDto user) => _logic.SignIn(user.UserName, user.Password);

        [HttpGet("me")]
        public UserDto Get()
        {

            if (_security.LoggedInUserId != Guid.Empty && _security.LoggedInUserId != null)
                return _mapper.Map<UserDto>(_logic.GetUser(_security.LoggedInUserId));

            throw new NotSupportedException();
        }

        [HttpPost("me")]
        public User Post([FromBody]UserDto user)
        {
            return _logic.SaveUser(_mapper.Map<User>(user));
        }

        [AllowAnonymous]
        [HttpGet("signout")]
        public void SignOut()
        {
            if (_security.LoggedInUserId != Guid.Empty)
                _logic.SignOut(_security.LoggedInUserId);
        }
    }
}