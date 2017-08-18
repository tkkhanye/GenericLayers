using CoreFacade.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreFacade.Repository
{
    public interface IAuthRepository
    {
        User SaveUser(User user);
        User GetUser(string userName);
        User GetUser(Guid userId);

        UserToken SaveUserToken(UserToken userToken);
        UserToken GetUserToken(string token);

        void ResetExistingUserTokens(Guid userId);
    }
}
