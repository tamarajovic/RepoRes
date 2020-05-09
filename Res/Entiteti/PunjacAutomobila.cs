using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entiteti
{
    public class PunjacAutomobila
    {

        public int TrenutnoBaterija { get; set; } = 100;
        public int SnagaBaterije { get; set; }

        public bool ZelimPunjenje { get; set; } = false;

        public PunjacAutomobila()
        {

        }

        public PunjacAutomobila(int snagaBaterije)
        {

            SnagaBaterije = snagaBaterije;
        }

    }
}
