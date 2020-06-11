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
            if (punjac == null)
            {
                throw new ArgumentNullException("Punjac automobila je null");
            }

            if (BazaPodataka.punjaci.Contains(punjac))
                return false;
            else
            {
                BazaPodataka.punjaci.Add(punjac);
                return true;
            }
        }

        public void Iskljuci(PunjacAutomobila pa)
        {
            if (pa == null)
            {
                throw new ArgumentNullException("Punjac je null");

            }
            else
            {
                pa.UtaknutAutomobil = false;
            }
        }

        public bool ObrisiPunjac(string ime)
        {
            if (ime == null)
            {
                throw new ArgumentException("Naziv punjaca je null");
            }

            if (ime.Trim().Equals(""))
            {
                throw new ArgumentException("Naziv punjaca je prazan string");
            }

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
            if (ime == null)
            {
                throw new ArgumentException("Naziv punjaca je null");
            }

            if (ime.Trim().Equals(""))
            {
                throw new ArgumentException("Naziv punjaca je prazan string");
            }

            foreach (var p in BazaPodataka.punjaci)
            {
                if (p.Naziv.ToLower().Equals(ime.ToLower()))
                {
                    return p;
                }
            }
            return null;
        }

        public void Ukljuci(PunjacAutomobila pa)
        {
            if (pa == null)
            {
                throw new ArgumentNullException("Punjac je null");

            }
            else
            {
                pa.UtaknutAutomobil = true;
            }
        }

        public List<PunjacAutomobila> VratiPunjace()
        {
            return BazaPodataka.punjaci;
        }
    }
}
