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
            Potrosac p = PronadjiPotrosaca(ime);
            if (p == null)
                return false;

            BazaPodataka.potrosaci.Remove(p);
            return true;
        }

        public Potrosac PronadjiPotrosaca(string ime)
        {
            foreach (Potrosac p in BazaPodataka.potrosaci)
            {
                if (p.Ime == ime)
                    return p;
            }
            return null;
        }

        public void Ukljuci(Potrosac p)
        {
            if (p != null)
            {
                p.Aktivan = true;
            }
        }

        public void Iskljuci(Potrosac p)
        {
            if(p!= null)
            {
                p.Aktivan = false;
            }
            
        }

    }
}
