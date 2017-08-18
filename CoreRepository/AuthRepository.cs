using CoreFacade.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using CoreFacade.Models;
using CoreContext;
using System.Linq;

namespace CoreRepository
{
    public class AuthRepository : IAuthRepository
    {
        private RepoContext _context;

        public AuthRepository(RepoContext context)
        {
            _context = context;
        }

        public User GetUser(string userName) => DisconnectUser(_context.User.Where(x => x.UserName == userName).FirstOrDefault());
        public User GetUser(Guid userId) => DisconnectUser(_context.User.Where(x => x.Id == userId).FirstOrDefault());

        public UserToken GetUserToken(string token) => _context.UserToken.Where(x => x.Token == token).FirstOrDefault();

        public void ResetExistingUserTokens(Guid userId)
        {
            var userTokens = _context.UserToken.Where(x => x.UserId == userId && x.Expiry > DateTime.Now).ToList();
            userTokens.ForEach(x => x.Expiry = DateTime.Now);
            _context.SaveChanges();
        }

        public User SaveUser(User user)
        {
            if (user.Id == Guid.Empty)
            {
                _context.User.Add(user);
            }
            else
            {
                _context.User.Update(user);
            }
            _context.SaveChanges();
            return user;
        }

        public UserToken SaveUserToken(UserToken userToken)
        {
            var existingUserToken = GetUserToken(userToken.Token);

            if (existingUserToken == null)
            {
                _context.UserToken.Add(userToken);
            }
            else
            {
                _context.UserToken.Update(userToken);
            }
            _context.SaveChanges();

            return userToken;
        }

        #region [ Private Methods ]
        private User DisconnectUser(User user)
        {
            if (user != null)
                _context.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            return user;
        }
        #endregion
    }
}
