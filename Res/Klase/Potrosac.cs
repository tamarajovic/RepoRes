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
            if (String.IsNullOrEmpty(ime))
            {
                throw new ArgumentOutOfRangeException("Naziv baterije ne moze biti prazan");
            }

            if (ime.Trim() == "")
            {
                throw new ArgumentOutOfRangeException("Naziv baterije ne moze biti prazan");
            }

            if (potrosnja <= 0)
            {
                throw new ArgumentOutOfRangeException("Potrosnja mora biti broj veci od 0");
            }

            Ime = ime;
            Potrosnja = potrosnja;
        }

        public Potrosac()
        {

        }

    }
}
