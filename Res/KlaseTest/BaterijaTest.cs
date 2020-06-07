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
    class BaterijaTest
    {
        [Test]
        [TestCase("baterija1", 1, 5)]
        [TestCase("baterija2", 1, 5.5)]
        [TestCase("baterija3", 1, 6.5)]
        public void BaterijaKonstruktorDobriParametri(string ime, int maxSnaga, double kapacitet)
        {
            Baterija baterija = new Baterija(ime, maxSnaga, kapacitet);

            Assert.AreEqual(baterija.Ime, ime);
            Assert.AreEqual(baterija.MaxSnaga, maxSnaga);
            Assert.AreEqual(baterija.KapacitetUSatima, kapacitet);
            Assert.AreEqual(baterija.TrKapacitet, maxSnaga * kapacitet);
            Assert.AreEqual(baterija.MaksKapacitet, maxSnaga * kapacitet);

        }

        [Test]
        [TestCase("baterija1", -1, -5)]
        [TestCase("  ", -10, 0)]
        [TestCase("   ", 8, 9)]
        [TestCase(null, 0, 10)]
        [TestCase("baterija4", 0, 0)]
        public void BaterijaKonstruktorLosiParametri(string ime, int maxSnaga, double kapacitet)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Baterija baterija = new Baterija(ime, maxSnaga, kapacitet);
            });
        }


    }
}
