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
    class SimulacijaTest
    {
        private Simulacija s = new Simulacija();

        [Test]
        [TestCase(-5)]
        [TestCase(115)]
        public void IzracunajPaneleLosiParametri(double procenat) 
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                s.IzracunajPanele(procenat);
            });
        }

    }
}
