using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klase
{
    public class Potrosac
    {
        public string Ime { get; set; }
        public double Potrosnja { get; set; }
        public bool Aktivan { get; set; } = false;

        public Potrosac(string ime, double potrosnja)
        {
            Ime = ime;
            Potrosnja = potrosnja;
        }

        public Potrosac()
        {

        }

    }
}
