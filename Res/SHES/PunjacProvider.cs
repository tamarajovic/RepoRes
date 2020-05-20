using Contracts;
using Klase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHES
{
    public class PunjacProvider : IPunjac
    {
        public bool DodajPunjac(PunjacAutomobila punjac)
        {
            if (BazaPodataka.punjaci.Contains(punjac))
                return false;
            else
            {
                BazaPodataka.punjaci.Add(punjac);
                return true;
            }
        }

        public void Iskljuci(string ime)
        {
            foreach (PunjacAutomobila p in BazaPodataka.punjaci)
            {
                if (p.Naziv == ime)
                {
                    p.UtaknutAutomobil = false;
                    p.TrenutnoBaterijaAutomobila = 0;
                    p.BaterijaAutomobila = 0;
                    break;
                }
            }
        }

        public bool ObrisiPunjac(string ime)
        {
            PunjacAutomobila p = PronadjiPunjac(ime);
            if (p != null)
            {
                BazaPodataka.punjaci.Remove(p);
                return true;
            }else
                return false;
        }

        public PunjacAutomobila PronadjiPunjac(string ime)
        {
            foreach (var p in BazaPodataka.punjaci)
            {
                if (p.Naziv.ToLower().Equals(ime.ToLower()))
                {
                    return p;
                }
            }
            return null;
        }

        public void Ukljuci(string ime, int maksKolicina, int kolicina)
        {
            foreach (PunjacAutomobila p in BazaPodataka.punjaci)
            {
                if (p.Naziv == ime)
                {
                    p.UtaknutAutomobil = true;
                    p.BaterijaAutomobila = maksKolicina;
                    p.TrenutnoBaterijaAutomobila = kolicina;
                    break;
                }
            }
        }

        public List<PunjacAutomobila> VratiPunjace()
        {
            return BazaPodataka.punjaci;
        }
    }
}
