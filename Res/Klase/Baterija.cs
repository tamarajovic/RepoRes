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
        public double MaxSnaga { get; set; }
        public double Kapacitet { get; set; }
        public int TrProcenat { get; set; } = 100;

        public string RezimRada { get; set; } = "Proizvodjac";
        public Baterija() { }

        public Baterija(string ime, double maxSnaga, double kapacitet)
        {
            Ime = ime;
            MaxSnaga = maxSnaga;
            Kapacitet = kapacitet;
        }

        public void PunjenjePraznjenje(string komanda)
        {
            if (komanda.ToLower().Equals("punjenje"))
            {
                Kapacitet++;
                RezimRada = "potrosac";
                
            }
            else
            {
                Kapacitet--;
                RezimRada = "proizvodjac";
            }
        }

        
    }
}
