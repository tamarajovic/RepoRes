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

        public int TrenutnoBaterijaAutomobila { get; set; }//procenat punosti
        public int SnagaBaterijePunjaca { get; set; } //koliko moze da puni punjac po satu
        public int MaksBaterijaAutomobila { get; set; }// dokle se puni

        public bool UtaknutAutomobil { get; set; } = false;

        public PunjacAutomobila()
        {

        }

        public PunjacAutomobila(string naziv, int snagaBaterije, int procenatBaterije, int maksSnagabaterijeAuta)
        {
            Naziv = naziv;
            SnagaBaterijePunjaca = snagaBaterije;
            MaksBaterijaAutomobila = maksSnagabaterijeAuta;
            TrenutnoBaterijaAutomobila = procenatBaterije;
        }

    }
}
