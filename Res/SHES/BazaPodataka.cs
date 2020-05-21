using Contracts;
using Klase;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SHES
{
    public class BazaPodataka
    {
        public static List<Potrosac> potrosaci = new List<Potrosac>();
        public static List<Baterija> baterije = new List<Baterija>();

        public static List<SolarniPanel> paneli = new List<SolarniPanel>();
        public static List<PunjacAutomobila> punjaci = new List<PunjacAutomobila>();

        public static List<Elektrodistribucija> distribucija = new List<Elektrodistribucija>();

        public BazaPodataka()
        {
           
            potrosaci.Add(new Potrosac { Ime = "frizider", Potrosnja = 5 });
            baterije.Add(new Baterija { Ime = "b1", MaxSnaga = 500, Kapacitet = 5 });
            paneli.Add(new SolarniPanel { Ime = "s1", MaksSnaga = 600 });
           
        }

       
    }
}
