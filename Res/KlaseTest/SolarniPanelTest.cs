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
    class SolarniPanelTest
    {
        private SolarniPanel Panel = new SolarniPanel("testPanel", 5);

        [Test]
        [TestCase("panel1", 30.1)]
        [TestCase("panelSKLJ", 2.4)]
        [TestCase("OOOOppa", 0.1)]
        public void SolarniPanelKonstruktorDobriParametri(string ime, double maksSnaga)
        {
            SolarniPanel solarniPanel = new SolarniPanel(ime, maksSnaga);

            Assert.AreEqual(solarniPanel.Ime, ime);
            Assert.AreEqual(solarniPanel.MaksSnaga, maksSnaga);
        }

        [Test]
        [TestCase("", 2.3)]
        [TestCase("", 5.6)]
        public void SolarniPanelKonstruktorLosiParametri1(string ime, double maksSnaga)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                SolarniPanel solarniPanel = new SolarniPanel(ime,maksSnaga);

            });
        }

        [Test]
        [TestCase(null, 5.1)]
        [TestCase(null, 0.3)]
        public void SolarniPanelKonstruktorLosiParametri2(string ime, double maksSnaga)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                SolarniPanel solarniPanel = new SolarniPanel(ime, maksSnaga);

            });
        }

        [Test]
        [TestCase("panell", -4.1)]
        [TestCase("nesto", 0)]
        [TestCase("jos nesto", -7.1)]
        public void SolarniPanelKonstruktorLosiParametri3(string ime, double maksSnaga)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                SolarniPanel solarniPanel = new SolarniPanel(ime, maksSnaga);

            });
        }

        [Test]
        [TestCase(40.3)]
        [TestCase(0)]
        [TestCase(78)]
        public void KolicinaGenerisaneEnergijeDobriParametri(double procenatSunca)
        {
            double resenje = Panel.MaksSnaga * procenatSunca / 100;

            Assert.AreEqual(resenje, Panel.KolicinaGenerisaneEnergije(procenatSunca));
        }

        [Test]
        [TestCase(-4.2)]
        [TestCase(100.1)]
        [TestCase(-0.01)]
        [TestCase(230)]
        public void KolicinaGenerisaneEnergijeLosiParametri(double procenatSunca)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                double resenje = Panel.KolicinaGenerisaneEnergije(procenatSunca);
            });
        }


    }
}
