using CoreFacade.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFacade.Logic
{
    public interface IAuthLogic
    {
        UserToken SignUp(User user);
        UserToken SignIn(string userName, string password);
        void SignOut(Guid userId);

        UserToken ProcessToken(string token);

        User GetUser(Guid userId);
        User SaveUser(User user);
    }
}
