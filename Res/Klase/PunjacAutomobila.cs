using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klase
{
    public class PunjacAutomobila
    {

        public int TrenutnoBaterija { get; set; }
        public int SnagaBaterije { get; set; }

        public bool ZelimPunjenje { get; set; } = false;

        public bool UtaknutAutomobil { get; set; } = false;

        public PunjacAutomobila()
        {

        }

        public PunjacAutomobila(int snagaBaterije)
        {

            SnagaBaterije = snagaBaterije;
        }

    }
}
