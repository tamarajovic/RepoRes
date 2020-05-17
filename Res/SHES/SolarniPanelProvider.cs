using Contracts;
using Klase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHES
{
    public class SolarniPanelProvider : ISolarniPanel
    {

        public bool DodajPanel(SolarniPanel s)
        {
            if (PronadjiPanel(s.Ime) != null)
                return false;

            BazaPodataka.paneli.Add(s);
            return true;
        }

        public bool ObrisiPanel(string ime)
        {
            SolarniPanel s = PronadjiPanel(ime);
            if (s == null)
                return false;

            BazaPodataka.paneli.Remove(s);
            return true;
        }

        public SolarniPanel PronadjiPanel(string ime)
        {
            foreach (SolarniPanel s in BazaPodataka.paneli)
            {
                if (s.Ime == ime)
                    return s;
            }
            return null;
        }


    }
}
