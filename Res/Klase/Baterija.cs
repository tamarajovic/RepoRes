using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klase
{
    public class Baterija
    {
        public string Ime { get; set; }
        public double MaxSnaga { get; set; }  // po satu koliko moze da isporuci
        public double KapacitetUSatima { get; set; } //koliko sati rada ima u sebi 
        public double TrKapacitetUMinutima { get; set; }  // odnos ova dva iznad
        public double MaksKapacitetUMinutima { get; set; } // ne menja se
        public double KolicinaKojuMozeDaIsporuciUMinuti { get; set; }

        public Baterija() { }

        public Baterija(string ime, double maxSnaga, double kapacitet)
        {
            if (String.IsNullOrEmpty(ime))
            {
                throw new ArgumentOutOfRangeException("Naziv baterije ne moze biti prazan");
            }

            if (ime.Trim() == "") {
                throw new ArgumentOutOfRangeException("Naziv baterije ne moze biti prazan");
            }

            if (maxSnaga <= 0)
            {
                throw new ArgumentOutOfRangeException("Maksimalna snaga mora biti pozitivan broj");
            }

            if (kapacitet <= 0)
            {
                throw new ArgumentOutOfRangeException("Kapacitet mora biti pozitivan broj");
            }

            Ime = ime;
            MaxSnaga = maxSnaga;
            KapacitetUSatima = kapacitet;
            TrKapacitetUMinutima = 60 * KapacitetUSatima;
            MaksKapacitetUMinutima = 60 * KapacitetUSatima;
            KolicinaKojuMozeDaIsporuciUMinuti = MaxSnaga / 60;
        }

        
    }
}
