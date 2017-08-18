using System;
using CoreLogic;
using NUnit.Framework;
using CoreFacade.Repository;
using Moq;
using CoreFacade.Models;
using CoreFacade.Logic;
using System.Linq;
using CoreRepository;

namespace CoreLogicTests
{
    [TestFixture]
    public class LookupLogicTests
    {
        private EnumLookupRepository _enumRepo;
        private ILookupLogic _lookupLogic;
        private Mock<ILookupRepository> _lookupRepo;

        public LookupLogicTests()
        {
            _enumRepo = new EnumLookupRepository();
            _lookupRepo = new Mock<ILookupRepository>();
            _lookupLogic = new LookupLogic(_enumRepo, _lookupRepo.Object);
        }

        [Test]
        public void LookupLogic_GetAllEstablishmentTypes()
        {
            var establishmentTypes = _lookupLogic.GetAllEstablishmentTypes();

            Assert.IsNotNull(establishmentTypes);
            Assert.IsTrue(establishmentTypes.Count == 2);
            Assert.IsTrue(establishmentTypes.First().Code == "Individual");
            Assert.IsTrue(establishmentTypes.First().Id == 1);
            Assert.IsTrue(establishmentTypes.Last().Code == "Institution");
            Assert.IsTrue(establishmentTypes.Last().Id == 2);
        }
    }
}
