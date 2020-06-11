using Klase;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KlaseTest
{
    [TestFixture]
    class ElektrodistribucijaTest
    {
        private Elektrodistribucija Distribucija = new Elektrodistribucija(3.3);

        [Test]
        [TestCase(0.01)]
        [TestCase(5.9)]
        [TestCase(100.1)]
        public void ElektrodistribucijaKonstruktorDobriParametri(double cenaPokWh)
        {
            Elektrodistribucija elektrodistribucija = new Elektrodistribucija(cenaPokWh);

            Assert.AreEqual(elektrodistribucija.CenaPokWh, cenaPokWh);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-5)]
        [TestCase(-30.3)]
        [TestCase(-200.4)]
        public void ElektrodistribucijaKonstruktorLosiParametri(double cenaPokWh)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Elektrodistribucija elektrodistribucija = new Elektrodistribucija(cenaPokWh);
            });
        }

        [Test]
        [TestCase(0)]
        [TestCase(-20.3)]
        [TestCase(1000.41)]
        [TestCase(35.1412)]
        public void RazlikaDobriParametri(double kolicina)
        {
            double resenje = Distribucija.CenaPokWh * kolicina / 60;

            Assert.AreEqual(resenje, Distribucija.Razlika(kolicina));
        }



    }
}
