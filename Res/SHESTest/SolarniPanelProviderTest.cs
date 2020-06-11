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
    class SolarniPanelProviderTest
    {
        private SolarniPanelProvider sp;
            
        [SetUp]
        public void Pocetak()
        {
            Mock<SolarniPanelProvider> mock = new Mock<SolarniPanelProvider>();
            sp = mock.Object;
        }

        [Test]
        [TestCase(null)]
        public void DodajPanelLosiParametri(SolarniPanel s)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                sp.DodajPanel(s);
            });
        }


        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void ObrisiPanelLosiParametri(string ime)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                sp.ObrisiPanel(ime);
            });
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void PronadjiPanelLosiParametri(string ime)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                sp.PronadjiPanel(ime);
            });
        }
    }
}
