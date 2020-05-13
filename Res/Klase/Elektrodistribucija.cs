using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klase
{
    public class Elektrodistribucija
    {

        public int CenaPokWh { get; set; }

        //Snaga Razmene
        public bool Trosi { get; set; }

        public Elektrodistribucija()
        {

        }

        // ne postavljam Trosi posto se proverava tek kad krene sa radom app
        // pa ce se onda postavljati

        public Elektrodistribucija(int cenaPokWh)
        {
            CenaPokWh = cenaPokWh;
        }

        public int Razlika(int kolicina)
        {
            if (Trosi)
            {
                return CenaPokWh * kolicina;
            }
            else
            {
                return -CenaPokWh * kolicina;
            }
        }


    }
}
