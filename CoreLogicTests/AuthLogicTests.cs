using CoreFacade.Logic;
using CoreFacade.Models;
using CoreFacade.Repository;
using CoreLogic;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLogicTests
{
    [TestFixture]
    public class AuthLogicTests
    {
        Mock<IAuthRepository> _repo;
        IAuthLogic _logic;

        [SetUp]
        public void SetUp()
        {
            _repo = new Mock<IAuthRepository>();
            _logic = new AuthLogic(_repo.Object);
        }

        [Test]
        public void AuthLogic_SignUp_ExistingUser()
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                UserName = "ShouldExist"
            };

            _repo.Setup(x => x.GetUser(user.UserName)).Returns(user).Verifiable();

            var response =_logic.SignUp(user);

            _repo.Verify();

            Assert.IsNotNull(response);
            Assert.IsFalse(response.RequestSuccessful);
        }
    }
}
