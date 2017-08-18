using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFacade.Concerns
{
    public interface IPrincipalSecurityConcern
    {
        Guid LoggedInUserId { get; }
    }
}
