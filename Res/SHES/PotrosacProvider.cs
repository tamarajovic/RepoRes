using Contracts;
using Klase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHES
{
    public class PotrosacProvider : IPotrosac
    {
        public List<Potrosac> VratiPotrosace()
        {
            return BazaPodataka.potrosaci;
        }

        public bool DodajPotrosaca(Potrosac p)
        {
            if(p == null)
            {
                throw new ArgumentNullException("Primljeni potrosac je null");
            }

            if (PronadjiPotrosaca(p.Ime) != null)
                return false;
            
            BazaPodataka.potrosaci.Add(p);
            return true;
        }

        public bool ObrisiPotrosaca(string ime)
        {
            if(ime == null)
            {
                throw new ArgumentException("Naziv potrosaca je null");
            }

            if (ime.Trim().Equals(""))
            {
                throw new ArgumentException("Naziv potrosaca je prazan string");
            }

            Potrosac p = PronadjiPotrosaca(ime);
            if (p == null)
                return false;

            BazaPodataka.potrosaci.Remove(p);
            return true;
        }

        public Potrosac PronadjiPotrosaca(string ime)
        {
            if (ime == null)
            {
                throw new ArgumentException("Naziv potrosaca je null");
            }

            if (ime.Trim().Equals(""))
            {
                throw new ArgumentException("Naziv potrosaca je prazan string");
            }

            foreach (Potrosac p in BazaPodataka.potrosaci)
            {
                if (p.Ime == ime)
                    return p;
            }
            return null;
        }

        public void Ukljuci(Potrosac p)
        {
            if (p == null)
            {
                throw new ArgumentNullException("Potrosac je null");

            }
            else
            {
                p.Aktivan = true;
            }
        }

        public void Iskljuci(Potrosac p)
        {
            if (p == null)
            {
                throw new ArgumentNullException("Potrosac je null");

            }
            else
            {
                p.Aktivan = false;
            }
            
        }

    }
}
