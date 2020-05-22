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
        public int MaxSnaga { get; set; }
        public double KapacitetUSatima { get; set; } 
        public double Kapacitet { get; set; } 
        public double TrProcenat { get; set; } = 100;

        public Baterija() { }

        public Baterija(string ime, int maxSnaga, double kapacitet)
        {
            Ime = ime;
            MaxSnaga = maxSnaga;
            KapacitetUSatima = kapacitet;
            Kapacitet = MaxSnaga / KapacitetUSatima;
        }

        public void PromeniKapacitet(bool puniSe)
        {
            if (puniSe)
            {
                KapacitetUSatima += (1 / 60);
                Kapacitet = MaxSnaga / KapacitetUSatima;
            }
            else
            {
                KapacitetUSatima -= (1 / 60);
                Kapacitet = MaxSnaga / KapacitetUSatima;
            }
        }
        
    }
}
