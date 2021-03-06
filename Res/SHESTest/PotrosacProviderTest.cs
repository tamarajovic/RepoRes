﻿using Contracts;
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
    class PotrosacProviderTest
    {
        private PotrosacProvider pp;

        [SetUp]
        public void Pocetak()
        {
            Mock<PotrosacProvider> mock = new Mock<PotrosacProvider>();
            pp = mock.Object;
        }

        [Test]
        [TestCase(null)]
        public void DodajPotrosacaLosiParametri(Potrosac p)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                pp.DodajPotrosaca(p);
            });
        }


        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void ObrisiPotrosacaLosiParametri(string ime)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                pp.ObrisiPotrosaca(ime);
            });
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase("  ")]
        public void PronadjiPotrosacaLosiParametri(string ime)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                pp.PronadjiPotrosaca(ime);
            });
        }

        [Test]
        [TestCase(null)]
        public void UkljuciLosiParametri(Potrosac p)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                pp.Ukljuci(p);
            });
        }

        [Test]
        [TestCase(null)]
        public void IskljuciLosiParametri(Potrosac p)
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
