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
        public int MaxSnaga { get; set; }  // po satu koliko moze da isporuci
        public double KapacitetUSatima { get; set; } //koliko sati rada ima u sebi 
        public double TrKapacitet { get; set; }  // odnos ova dva iznad
        public double MaksKapacitet { get; set; } // ne menja se

        public Baterija() { }

        public Baterija(string ime, int maxSnaga, double kapacitet)
        {
            Ime = ime;
            MaxSnaga = maxSnaga;
            KapacitetUSatima = kapacitet;
            TrKapacitet = MaxSnaga * KapacitetUSatima;
            MaksKapacitet = MaxSnaga * KapacitetUSatima;
        }

        
    }
}
