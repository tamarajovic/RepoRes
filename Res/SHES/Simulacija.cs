using Contracts;
using Klase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SHES
{

    public class Simulacija : ISimulacija
    {
        public int Takt { get; set; } = 417; //ucita se iz xml-a ceo dan zza 10 min 

        public static int Dani { get; set; }

        public double ProcenatSunca { get; set; }

        public Simulacija()
        {
            Dani = 0;
            ProcenatSunca = 0;
            Simuliraj(Takt, ProcenatSunca);
        }

        public static void Simuliraj(int brojac, double ProcenatSunca)
        {
            while (true) {
                int satnica = 0;
                for (int i = 1; i <= 1440; i++)
                {

                    if (i % 60 == 0)
                    {
                        //Proveri();
                        satnica++;
                        if (satnica == 5)
                            ProcenatSunca = 30;
                        if (satnica == 7)
                            ProcenatSunca = 60;
                        if (satnica == 9)
                            ProcenatSunca = 100;
                        if (satnica == 20)
                            ProcenatSunca = 70;
                        if (satnica == 21)
                            ProcenatSunca = 40;
                        if (satnica == 22)
                            ProcenatSunca = 0;

                    }



                    //Neka funkcija koja proverava jel se nesto desilo u Res projektu tj da vidi jel klijent nes promenio

                    Thread.Sleep(brojac);
                   
               
                }
                Dani++;
                //upisi podatke u bazu
            }

        }

        public static void Proveri()
        {
            int kolicina = 0;

            foreach(Baterija b in BazaPodataka.baterije)
            {
                foreach(Potrosac p in BazaPodataka.potrosaci)
                {
                    if (p.Aktivan)
                        kolicina -= p.Potrosnja;
                }
                foreach(PunjacAutomobila pa in BazaPodataka.punjaci)
                {
                    if (pa.UtaknutAutomobil)
                    {
                        kolicina -= pa.SnagaBaterijePunjaca;
                    }
                }

                //... 
                // pokusaj neki
            }


        }

        public void PromeniOsuncanost(double procenat)
        {
            ProcenatSunca = procenat;
        }

        public void UbrzajVreme(int brojac)
        {
            Takt = brojac;
        }
    }
}
