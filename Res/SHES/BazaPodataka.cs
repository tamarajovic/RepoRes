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
    public class BazaPodataka : ISolarniPanel, IPotrosac
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

        //solarne panele

        public bool DodajPanel(SolarniPanel s)
        {
            if (PronadjiPanel(s.Ime) != null)
                return false;

            paneli.Add(s);
            return true;
        }

        public bool ObrisiPanel(string ime)
        {
            SolarniPanel s = PronadjiPanel(ime);
            if (s == null)
                return false;

            paneli.Remove(s);
            return true;
        }

        public SolarniPanel PronadjiPanel(string ime)
        {
            foreach (SolarniPanel s in paneli)
            {
                if (s.Ime == ime)
                    return s;
            }
            return null;
        }

        //Potrosaci

        public bool DodajPotrosaca(Potrosac p)
        {
            if (PronadjiPotrosaca(p.Ime) == null)
                return false;

            potrosaci.Add(p);
            return true;
        }

        public bool ObrisiPotrosaca(string ime)
        {
            Potrosac p = PronadjiPotrosaca(ime);
            if (p == null)
                return false;

            potrosaci.Remove(p);
            return true;
        }

        public Potrosac PronadjiPotrosaca(string ime)
        {
            foreach(Potrosac p in potrosaci)
            {
                if (p.Ime == ime)
                    return p;
            }
            return null;
        }
    }
}
