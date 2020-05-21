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
        public int Kapacitet { get; set; }
        public double TrProcenat { get; set; } = 100;

        public Baterija() { }

        public Baterija(string ime, int maxSnaga, int kapacitet)
        {
            Ime = ime;
            MaxSnaga = maxSnaga;
            Kapacitet = kapacitet;
        }

        
    }
}
