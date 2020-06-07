using Contracts;
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
        private Potrosac potrosac;
        private List<Potrosac> testBaza;
        private static int kolicina;

        [SetUp]
        public void Pocetak()
        {
            potrosac = new Potrosac();
            testBaza = new List<Potrosac>();
            kolicina = 0;
        }

        [Test]
        public void DodajPotrosacaTest()
        {
            kolicina = testBaza.Count;
            testBaza.Add(potrosac);
            Assert.AreEqual(kolicina + 1, testBaza.Count);
        }


        //nisam sig kako drugacije da proverim
        [Test]
        [TestCase("frizider")]
        public void ObrisiPotrosacaTest(string ime)
        {
            testBaza.Add(new Potrosac("frizider", 2));
            kolicina = testBaza.Count;
            for(int i = 0; i < kolicina; i++)
            {
                if(testBaza[i].Ime == ime)
                {
                    testBaza.RemoveAt(i);
                    Assert.AreEqual(kolicina - 1, testBaza.Count);
                }
            }
        }


        [TearDown]
        public void Kraj()
        {
            potrosac = null;
            testBaza = null;
            kolicina = 0;
        }

    }
}
