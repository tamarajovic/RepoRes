using Klase;
using Moq;
using NUnit.Framework;
using SHES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHESTest
{
    [TestFixture]
    class PunjacProviderTest
    {
        private PunjacProvider pp;

        [SetUp]
        public void Pocetak()
        {
            Mock<PunjacProvider> mock = new Mock<PunjacProvider>();
            pp = mock.Object;
        }


        [Test]
        [TestCase(null)]
        public void DodajPunjacLosiParametri(PunjacAutomobila p)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                pp.DodajPunjac(p);
            });
        }


        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void ObrisiPunjacLosiParametri(string ime)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                pp.ObrisiPunjac(ime);
            });
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void PronadjiPunjacLosiParametri(string ime)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                pp.PronadjiPunjac(ime);
            });
        }

        [Test]
        [TestCase(null)]
        public void UkljuciLosiParametri(PunjacAutomobila p)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                pp.Ukljuci(p);
            });
        }

        [Test]
        [TestCase(null)]
        public void IskljuciLosiParametri(PunjacAutomobila p)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                pp.Iskljuci(p);
            });
        }

        [TearDown]
        public void Kraj()
        {
            pp = null;
        }

    }
}
