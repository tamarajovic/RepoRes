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
    class BaterijaProviderTest
    {
        private BaterijaProvider bp;

        [SetUp]
        public void Pocetak()
        {
            Mock<BaterijaProvider> mock = new Mock<BaterijaProvider>();
            bp = mock.Object;
        }

        [Test]
        [TestCase(null)]
        public void DodajBaterijuLosiParametri(Baterija b)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                bp.DodajBateriju(b);
            });
        }


        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void ObrisiBaterijuLosiParametri(string ime)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                bp.ObrisiBateriju(ime);
            });
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void PronadjiBaterijuLosiParametri(string ime)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                bp.PronadjiBateriju(ime);
            });
        }
    }
}
