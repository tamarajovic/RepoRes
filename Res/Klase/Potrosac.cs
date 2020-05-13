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
        public int Potrosnja { get; set; }

        public bool Aktivan { get; set; } = false;

        public Potrosac(string ime, int potrosnja)
        {
            Ime = ime;
            Potrosnja = potrosnja;
        }

        public Potrosac()
        {

        }

        public void PokreniPotrosnju()
        {
            Aktivan = true;
        }

        public void ZaustaviPotrosnju()
        {
            Aktivan = false;
        }

        //za neko vreme iz neke baterije trosi kolicinu Potrosnja
        //po nekoj vremenskoj jedinici samo se pozove Potrosac.Potrosnja
        // i skine ta kolicina iz baterija ili iz elektroditribicuje
        // if(aktivan) obracunaj potrosnju

    }
}
