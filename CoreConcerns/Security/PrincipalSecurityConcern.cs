using CoreFacade.Concerns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace CoreConcerns.Security
{
    public class PrincipalSecurityConcern : IPrincipalSecurityConcern
    {
        private ClaimsPrincipal _principal;

        public PrincipalSecurityConcern(IPrincipal principal)
        {
            _principal = principal as ClaimsPrincipal;
        }

        private string _loggedInUserId => _principal?.Claims?.Where(x => x.Subject is System.Security.Claims.ClaimsIdentity)?.FirstOrDefault()?.Value;

        //    SecurityConcern.InitLoggedInUserId(((Microsoft.AspNetCore.Http.DefaultHttpContext)context)?.User?.Claims?.Where(x => x.Subject is System.Security.Claims.ClaimsIdentity)?.FirstOrDefault()?.Value);
        public Guid LoggedInUserId => string.IsNullOrEmpty(_loggedInUserId) ? Guid.Empty : Guid.Parse(_loggedInUserId);
    }
}
