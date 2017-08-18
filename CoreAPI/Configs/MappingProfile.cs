using AutoMapper;
using CoreFacade.Models;
using CoreAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Configs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region [Let's hide the Password.. Why not?]
            var maskedPassword = "Hidden Password$$";
            CreateMap<User, UserDto>()
                .ForMember(x => x.Password, x => x.UseValue(maskedPassword));
            CreateMap<UserDto, User>()
                .ForMember(x => x.Password, x => x.ResolveUsing<string>(y => y.Password == maskedPassword ? "" : y.Password));
            #endregion
        }
    }
}
