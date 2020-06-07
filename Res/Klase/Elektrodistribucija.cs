using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klase
{
    public class Elektrodistribucija
    {

        public double CenaPokWh { get; set; }

        public Elektrodistribucija()
        {

        }

        public Elektrodistribucija(double cenaPokWh)
        {
            if(cenaPokWh <= 0)
            {
                throw new ArgumentOutOfRangeException("Cena mora biti pozitivan broj");
            }

            CenaPokWh = cenaPokWh;
        }

        public double Razlika(double kolicina)
        {
            return CenaPokWh * kolicina;
        }


    }
}
