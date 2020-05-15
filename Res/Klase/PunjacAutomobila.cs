using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klase
{
    public class PunjacAutomobila
    {

        public int TrenutnoBaterijaAutomobila { get; set; }//koliko ima kad se utakne
        public int SnagaBaterijePunjaca { get; set; } //koliko moze dapuni punjac
        public int BaterijaAutomobila { get; set; }// dokle se puni
        public bool ZelimPunjenje { get; set; } = false;

        public bool UtaknutAutomobil { get; set; } = false;

        public PunjacAutomobila()
        {

        }

        public PunjacAutomobila(int snagaBaterije)
        {

            SnagaBaterijePunjaca = snagaBaterije;
        }

    }
}
