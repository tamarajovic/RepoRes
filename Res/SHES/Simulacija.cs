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

        public int ProcenatSunca { get; set; }

        public Simulacija()
        {
            Dani = 0;
            ProcenatSunca = 0;
            Simuliraj(Takt, ProcenatSunca);
        }

        public static void Simuliraj(int brojac, int ProcenatSunca)
        {
            while (true) {
                int satnica = 0;
                for (int i = 1; i <= 1440; i++)
                {

                    if (i % 60 == 0)
                    {
                        Proveri(ProcenatSunca);
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
                //upisi u fajl
            }

        }

        public static void Proveri(int procenatSunca)
        {
            double kolicina = 0;
            double novac;

            foreach(Potrosac p in BazaPodataka.potrosaci)
            {
                if (p.Aktivan)
                    kolicina -= p.Potrosnja;
            }
            foreach(PunjacAutomobila pa in BazaPodataka.punjaci)
            {
                if (pa.UtaknutAutomobil) {
                    int procenatKojiSeNapuniPoSatuMaks = ((100 * pa.SnagaBaterijePunjaca) / pa.MaksBaterijaAutomobila);
                    if (100 - pa.TrenutnoBaterijaAutomobila <= procenatKojiSeNapuniPoSatuMaks)
                    {
                        kolicina -= pa.SnagaBaterijePunjaca;
                        pa.TrenutnoBaterijaAutomobila += procenatKojiSeNapuniPoSatuMaks;
                    }
                    else
                    {
                        int procenatPraznogAuta = 100 - pa.TrenutnoBaterijaAutomobila;
                        kolicina -= ((pa.MaksBaterijaAutomobila * procenatPraznogAuta) / 100);
                        pa.TrenutnoBaterijaAutomobila = 100;
                    }
                }
            }
            foreach(SolarniPanel s in BazaPodataka.paneli)
            {
                kolicina += s.KolicinaGenerisaneEnergije(procenatSunca);
            }
            if(kolicina > 0)
            {
                foreach(Baterija b in BazaPodataka.baterije)
                {
                    if(b.TrProcenat < 100)
                    {
                        int procenatKojiSeNapuniPoSatuMaks = ((100 * b.MaxSnaga) / b.Kapacitet);
                        if(100 - b.TrProcenat <= procenatKojiSeNapuniPoSatuMaks)
                        {
                            kolicina -= b.MaxSnaga;
                            b.TrProcenat += procenatKojiSeNapuniPoSatuMaks;
                        }
                        else
                        {
                            int procenatPrazneBaterije = 100 - b.TrProcenat;
                            kolicina -= ((b.MaxSnaga * procenatPrazneBaterije) / 100);
                            b.TrProcenat = 100;
                        }

                    }
                }
                if(kolicina > 0)
                {
                    BazaPodataka.distribucija[0].Trosi = false;
                    novac = BazaPodataka.distribucija[0].Razlika(kolicina);
                }
            }
            else
            {
                foreach(Baterija b in BazaPodataka.baterije)
                {
                    if(b.TrProcenat > 0)
                    {
                        int procenatKojiSeIsprazniPoSatuMaks = ((100 * b.MaxSnaga) / b.Kapacitet);
                        if(b.TrProcenat - procenatKojiSeIsprazniPoSatuMaks >= 0)
                        {
                            kolicina += b.MaxSnaga;
                            b.TrProcenat -= procenatKojiSeIsprazniPoSatuMaks;
                        }
                        else
                        {
                            kolicina += ((b.MaxSnaga * b.TrProcenat) / 100);
                            b.TrProcenat = 0;
                        }

                    }
                }
                if(kolicina < 0)
                {
                    BazaPodataka.distribucija[0].Trosi = true;
                    novac = BazaPodataka.distribucija[0].Razlika(kolicina);
                }
            }


        }

        public void PromeniOsuncanost(int procenat)
        {
            ProcenatSunca = procenat;
        }

        public void UbrzajVreme(int brojac)
        {
            Takt = brojac;
        }
    }
}
