using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DVDLibrary.BLL;
using DVDLibrary.Models;
using NUnit.Framework;

namespace DVDLibrary.Tests.MockRepoTests
{
    [TestFixture]
    public class MockRepoTesterClass
    {
        Manager _manager = new Manager();

        [Test]
        public void ListAllDvds()
        {
            var actual = _manager.ListDvds().Count;
            Assert.AreEqual(2, actual);
        }

        [Test]
        public void GetASingleDVD()
        {
            Assert.AreEqual("A Beautiful Mind", _manager.LoadDvd(2).Title);
        }

        [Test]
        public void CanAddDVD()
        {
            var newD = new DVD();
            _manager.AddDvd(newD);
            Assert.AreEqual(3, _manager.ListDvds().Count);
        }

        [Test]
        public void CanRemoveADvd()
        {
            _manager.RemoveDvd(1);
            Assert.AreEqual(1,_manager.ListDvds().Count);
        }

        [Test]
        public void CanEditADVD()
        {
            var newD = _manager.LoadDvd(1);
            newD.Title = "asd";
            _manager.EditDvd(newD);
            Assert.AreEqual("asd", _manager.LoadDvd(1).Title);
        }
    }
}
