using CoreConcerns.Security;
using CoreFacade.Concerns;
using CoreFacade.Logic;
using CoreFacade.Repository;
using CoreLogic;
using CoreRepository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAPI.Configs
{
    public static class DIProfile
    {
        public static void InjectRepositories(this IServiceCollection services)
        {
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<ILookupRepository, LookupRepository>();
            services.AddScoped<IEnumLookupRepository, EnumLookupRepository>();
        }

        public static void InjectBusinessLogic(this IServiceCollection services)
        {
            services.AddScoped<IAuthLogic, AuthLogic>();
            services.AddScoped<ILookupLogic, LookupLogic>();
        }

        public static void InjectCrossCuttingConcerns(this IServiceCollection services)
        {
            services.AddScoped<IPrincipalSecurityConcern, PrincipalSecurityConcern>();
        }
    }
}
