﻿using NUnit.Framework;
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
        private Simulacija s;

        [SetUp]
        public void Pokreni()
        {
            Assert.DoesNotThrow(() => s.Simuliraj());
        }

    }
}