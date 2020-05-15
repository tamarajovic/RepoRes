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
    public class BazaPodataka : ICommon
    {
        public static List<Potrosac> potrosaci = new List<Potrosac>();
        public static List<Baterija> baterije = new List<Baterija>();

        public static List<SolarniPanel> paneli = new List<SolarniPanel>();
        public static List<PunjacAutomobila> punjaci = new List<PunjacAutomobila>();


        public BazaPodataka()
        {
            Elektrodistribucija elektrodistribucija = new Elektrodistribucija(1000);
            potrosaci.Add(new Potrosac { Ime = "frizider", Potrosnja = 5 });
            baterije.Add(new Baterija { Ime = "b1", MaxSnaga = 500, Kapacitet = 5 });
            paneli.Add(new SolarniPanel { Ime = "s1", MaksSnaga = 600 });
            punjaci.Add(new PunjacAutomobila { SnagaBaterijePunjaca = 400, BaterijaAutomobila = 4000, TrenutnoBaterijaAutomobila = 3000 });

        }

        public void DodajPotrosaca(Potrosac p)
        {
            potrosaci.Add(p);
        }
    }
}
