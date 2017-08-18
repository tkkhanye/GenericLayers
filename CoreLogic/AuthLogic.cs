using CoreFacade.Logic;
using System;
using System.Collections.Generic;
using System.Text;
using CoreFacade.Models;
using CoreFacade.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using CoreConcerns.Security;

namespace CoreLogic
{
    public class AuthLogic : IAuthLogic
    {
        private IAuthRepository _repo;

        public AuthLogic(IAuthRepository repo)
        {
            _repo = repo;
        }
        public UserToken SignIn(string userName, string password)
        {
            return ProcessLogin(userName, password);
        }    
        public void SignOut(Guid userId)
        {
            _repo.ResetExistingUserTokens(userId);
        }

        public UserToken SignUp(User user)
        {
            var existingUser = _repo.GetUser(user.UserName);

            if (existingUser != null)
            {
                return new UserToken
                {
                    RequestSuccessful = false,
                    ErrorMessage = "Username already exists."
                };
            }
            user.PasswordSalt = GenerateSalt();
            user.Password = HashPassword(user.Password, user.PasswordSalt);
            var newUser = _repo.SaveUser(user);
            var userToken = CreateUserToken(newUser);

            return userToken;
        }

        public UserToken ProcessToken(string token)
        {
            var userToken = _repo.GetUserToken(token);
            var expiryDate = DateTime.Now.AddMonths(1);

            if (userToken.Expiry > DateTime.Now)
            {
                userToken.Expiry = expiryDate;
                userToken = _repo.SaveUserToken(userToken);

            }
            else
            {
                userToken = new UserToken
                {
                    RequestSuccessful = false,
                    ErrorMessage = "Token epired"
                };
            }
            return userToken;
        }

        public User GetUser(Guid userId)
        {
            var user = _repo.GetUser(userId);
            user.Password = "";
            user.PasswordSalt = null;
            return user;
        }

        public User SaveUser(User user)
        {
            if (string.IsNullOrEmpty(user.Password))
            {
                var existingUser = _repo.GetUser(user.Id);
                user.Password = existingUser.Password;
                user.PasswordSalt = existingUser.PasswordSalt;
            }
            else
            {
                user.PasswordSalt = GenerateSalt();
                user.Password = HashPassword(user.Password, user.PasswordSalt);
            }
            return _repo.SaveUser(user);
        }

        #region Private Methods
        private UserToken ProcessLogin(string userName, string password)
        {
            var user = _repo.GetUser(userName);

            if (user == null)
                return InvalidLogin(user);

            if (HashPassword(password, user.PasswordSalt) != user.Password)
                return InvalidLogin(user);

            return CreateUserToken(user);
        }

        private UserToken InvalidLogin(User user)
        {
            if (user != null)
            {
                user.LoginAttempts++;
                _repo.SaveUser(user);
            }

            return new UserToken
            {
                RequestSuccessful = false,
                ErrorMessage = "Invalid email or password!"
            };
        }

        private UserToken CreateUserToken(User user)
        {
            _repo.ResetExistingUserTokens(user.Id);

            var signingCredentials = new SigningCredentials(SecurityConcern.SigningKey, SecurityAlgorithms.HmacSha256);
            var expiryDate = DateTime.Now.AddMonths(1);
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
            };

            var jwt = new JwtSecurityToken(expires: expiryDate, claims: claims, signingCredentials: signingCredentials);
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);

            var userToken = new UserToken
            {
                UserId = user.Id,
                RequestSuccessful = true,
                Expiry = expiryDate,
                Token = token,
                CreateDate = DateTime.Now
            };

            _repo.SaveUserToken(userToken);

            return userToken;
        }

        private byte[] GenerateSalt()
        {
            int SaltSize = 128 / 8; // 128 bits
            byte[] salt = new byte[SaltSize];
            var rng = RandomNumberGenerator.Create();
            rng.GetBytes(salt);
            return salt;
        }

        private string HashPassword(string password, byte[] salt)
        {
            int SaltSize = 128 / 8; // 128 bits
            KeyDerivationPrf Pbkdf2Prf = KeyDerivationPrf.HMACSHA1; // default for Rfc2898DeriveBytes
            int Pbkdf2IterCount = 1000; // default for Rfc2898DeriveBytes
            int Pbkdf2SubkeyLength = 256 / 8; // 256 bits

            // Produce a version 2 (see comment above) text hash.
            byte[] subkey = KeyDerivation.Pbkdf2(password, salt, Pbkdf2Prf, Pbkdf2IterCount, Pbkdf2SubkeyLength);

            var outputBytes = new byte[1 + SaltSize + Pbkdf2SubkeyLength];
            outputBytes[0] = 0x00; // format marker
            Buffer.BlockCopy(salt, 0, outputBytes, 1, SaltSize);
            Buffer.BlockCopy(subkey, 0, outputBytes, 1 + SaltSize, Pbkdf2SubkeyLength);
            return Convert.ToBase64String(outputBytes);

        }
        #endregion
    }
}
