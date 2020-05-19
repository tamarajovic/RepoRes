using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klase
{
    public class PunjacAutomobila
    {
        public string Naziv { get; set; }

        public int TrenutnoBaterijaAutomobila { get; set; }//koliko ima kad se utakne
        public int SnagaBaterijePunjaca { get; set; } //koliko moze da puni punjac
        public int BaterijaAutomobila { get; set; }// dokle se puni

        public bool ZelimPunjenje { get; set; } = false;

        public bool UtaknutAutomobil { get; set; } = false;

        public PunjacAutomobila()
        {

        }

        public PunjacAutomobila(string naziv, int snagaBaterije)
        {
            Naziv = naziv;
            SnagaBaterijePunjaca = snagaBaterije;
        }

    }
}
