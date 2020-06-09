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

        public double TrenutnoBaterijaAutomobila { get; set; }//procenat punosti
        public double SnagaBaterijePunjaca { get; set; } //koliko moze da puni punjac po satu
        public double MaksBaterijaAutomobila { get; set; }// dokle se puni
        public double SnagaUMinuti { get; set; }

        public bool UtaknutAutomobil { get; set; } = false;

        public PunjacAutomobila()
        {

        }

        public PunjacAutomobila(string naziv, double snagaBaterije, double procenatBaterije, double maksSnagabaterijeAuta)
        {
            if (String.IsNullOrEmpty(naziv))
            {
                throw new ArgumentOutOfRangeException("Naziv baterije ne moze biti prazan");
            }

            if (naziv.Trim() == "")
            {
                throw new ArgumentOutOfRangeException("Naziv baterije ne moze biti prazan");
            }

            if (snagaBaterije <= 0)
            {
                throw new ArgumentOutOfRangeException("Snaga punjaca mora biti pozitivan broj");
            }

            if (procenatBaterije < 0 || procenatBaterije > 100)
            {
                throw new ArgumentOutOfRangeException("Procenat baterije mora biti pozitivan broj(ne veci od 100)");
            }

            if (maksSnagabaterijeAuta <= 0)
            {
                throw new ArgumentOutOfRangeException("Snaga baterija automobila mora biti pozitivan broj");
            }

            Naziv = naziv;
            SnagaBaterijePunjaca = snagaBaterije;
            MaksBaterijaAutomobila = maksSnagabaterijeAuta;
            TrenutnoBaterijaAutomobila = procenatBaterije;
            SnagaUMinuti = MaksBaterijaAutomobila / 60;
        }

    }
}
