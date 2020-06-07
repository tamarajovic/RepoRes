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
    class PotrosacTest
    {
        [Test]
        [TestCase("potrosac1", 5.6)]
        [TestCase("potrosac2", 4.1)]
        [TestCase("potrosac3", 0.1)]
        public void PotrosacKonstruktorDobriParametri(string ime, double potrosnja)
        {
            Potrosac potrosac = new Potrosac(ime, potrosnja);

            Assert.AreEqual(potrosac.Ime, ime);
            Assert.AreEqual(potrosac.Potrosnja, potrosnja);

        }

        [Test]
        [TestCase("potrosac1", -1)]
        [TestCase("potrosac2", 0)]
        [TestCase("   ", 0.1)]
        [TestCase(null, 0.1)]
        public void PotrosacKonstruktorLosiParametri(string ime, double potrosnja)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Potrosac potrosac = new Potrosac(ime, potrosnja);
            });
        }


    }
}
