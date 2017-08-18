using CoreRepository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreRepositoryTests
{
    [TestFixture]
    public class EnumRepositoryTests
    {
        enum ForTest
        {
            first = 1,
            second
        }

        [Test]
        public void GetAll()
        {
            var cls = new EnumLookupRepository();

            var values = cls.GetAll<ForTest>();

            Assert.IsNotNull(values);
            Assert.IsTrue(values.Count == 2);
            Assert.IsTrue(values.First().Code == "first");
            Assert.IsTrue(values.First().Id == 1);
            Assert.IsTrue(values.Last().Code == "second");
            Assert.IsTrue(values.Last().Id == 2);
        }
    }
}
