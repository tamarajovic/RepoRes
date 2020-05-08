using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entiteti
{
    public class SolarniPanel
    {
        
        public string Ime { get; set; }
        public int MaksSnaga { get; set; }


        public SolarniPanel(string ime, int maksSnaga)
        {
            Ime = ime;
            MaksSnaga = maksSnaga;
        }

        public int KolicinaGenerisaneEnergije(int ProcenatSunca)
        {
            return ProcenatSunca * MaksSnaga / 100;
        }


    }
}
