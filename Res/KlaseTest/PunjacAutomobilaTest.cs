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
    class PunjacAutomobilaTest
    {
        [Test]
        [TestCase("punjac1", 100, 50, 400)]
        [TestCase("punjac2", 90, 35, 350)]
        [TestCase("punjac3", 110, 0, 560)]
        public void PunjacAutomobilaKonstruktorDobriParametri(string naziv, int snagaBaterije, int procenatBaterije, int maksSnagabaterijeAuta)
        {
            PunjacAutomobila punjac = new PunjacAutomobila(naziv, snagaBaterije, procenatBaterije, maksSnagabaterijeAuta);

            Assert.AreEqual(punjac.Naziv, naziv);
            Assert.AreEqual(punjac.SnagaBaterijePunjaca, snagaBaterije);
            Assert.AreEqual(punjac.MaksBaterijaAutomobila, maksSnagabaterijeAuta);
            Assert.AreEqual(punjac.TrenutnoBaterijaAutomobila, procenatBaterije);
        }

        [Test]
        [TestCase("   ", 0, 0, 0)]
        [TestCase(" ", -300, 90, 80)]
        [TestCase("", 400, 190, 600)]
        [TestCase(null, 400, 190, -600)]
        [TestCase("punjac4", 500, -90, 0), ]
        public void PunjacAutomobilaKonstruktorLosiParametri(string naziv, int snagaBaterije, int procenatBaterije, int maksSnagabaterijeAuta)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                PunjacAutomobila punjac = new PunjacAutomobila(naziv, snagaBaterije, procenatBaterije, maksSnagabaterijeAuta);
            });
        }
    }
}
