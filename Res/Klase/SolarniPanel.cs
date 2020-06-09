using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klase
{
    public class SolarniPanel
    {

        public string Ime { get; set; }
        public double MaksSnaga { get; set; } //po satu
        public double SnagaUMinuti { get; set; }

        public SolarniPanel(string ime, double maksSnaga)
        {
            if(ime == null)
            {
                throw new ArgumentNullException("Ime ne sme biti null");
            }
            if(ime.Trim() == "")
            {
                throw new ArgumentException("Ime mora imati karaktere");
            }
            if(maksSnaga <= 0)
            {
                throw new ArgumentOutOfRangeException("Snaga panela mora biti pozitivan broj");
            }

            Ime = ime.Trim();
            MaksSnaga = maksSnaga;
            SnagaUMinuti = MaksSnaga / 60;
        }

        public SolarniPanel()
        {

        }

        public double KolicinaGenerisaneEnergije(double procenatSunca)
        {
            if(procenatSunca < 0 || procenatSunca > 100)
            {
                throw new ArgumentOutOfRangeException("Procenat sunca je u granicama od 0 do 100");
            }

            return procenatSunca * SnagaUMinuti / 100;
        }


    }
}
