using Contracts;
using Klase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SHES
{

    public class Simulacija : ISimulacija
    {
        public static double Kolicina { get; set; } = 0;
        public int Takt { get; set; } = 41; //ucita se iz xml-a ceo dan zza 10 min  417 bilo za 10 min rada
        public int Dani { get; set; } = 0;
        public static double ProcenatSunca { get; set; } = 0;
        public static double EnergijaBaterija { get; set; } = 0;
        public static int satnica { get; set; } = 0;
        PotrosacProvider PotrosaciUpravljac = new PotrosacProvider();
        PunjacProvider PunjacUpravljac = new PunjacProvider();

        public static Dictionary<string, double> PotrosnjaPoDanima = new Dictionary<string, double>();
        public static int countDani = 0;
        

        public Simulacija()
        {

        }

        public void Simuliraj()
        {

            new Thread(() =>
            {
                bool puniBaterije = false;
                bool prazniBaterije = false;
                while (true)
                {
                    double novac = 0;
                    for (int i = 1; i <= 1440; i++)
                    {

                        if(i == 1)
                            BazaPodataka.istorijaPotrosnje.Add(new PotrosnjaPoDanu());

                        if (i % 60 == 0)
                        {
                            satnica++;

                            if (satnica == 1)
                            {
                                BazaPodataka.distribucija[0].CenaPokWh = 1.5;

                                PunjacAutomobila temp = PunjacUpravljac.PronadjiPunjac("pa1");
                                PunjacUpravljac.Ukljuci(temp);
                            }
                            else if (satnica == 2)
                            {
                                Potrosac temp = PotrosaciUpravljac.PronadjiPotrosaca("Bojler");
                                PotrosaciUpravljac.Ukljuci(temp);
                            }
                            else if (satnica == 3)
                            {
                                puniBaterije = true;
                            }
                            else if (satnica == 4)
                            {
                                
                            }
                            else if (satnica == 5)
                            {
                                
                                ProcenatSunca = 10;
                                Potrosac temp = PotrosaciUpravljac.PronadjiPotrosaca("Bojler");
                                PotrosaciUpravljac.Iskljuci(temp);
                                }
                            else if (satnica == 6)
                            {
                                ProcenatSunca = 30;
                                puniBaterije = false;
                            }
                            else if (satnica == 7)
                            {
                                Potrosac temp = PotrosaciUpravljac.PronadjiPotrosaca("Bojler");
                                PotrosaciUpravljac.Iskljuci(temp);
                                ProcenatSunca = 40;
                            }
                            else if (satnica == 8)
                            {
                                BazaPodataka.distribucija[0].CenaPokWh = 6;
                                ProcenatSunca = 60;
                            }
                            else if (satnica == 9)
                            {
                                ProcenatSunca = 80;
                            }
                            else if (satnica == 10)
                            {
                                ProcenatSunca = 90;
                            }
                            else if (satnica == 11)
                            {
                                ProcenatSunca = 100;
                            }
                            else if (satnica == 12)
                            {
                            
                            }
                            else if (satnica == 13)
                            {
                            
                            }
                            else if (satnica == 14)
                            {
                                prazniBaterije = true;
                                Potrosac temp = PotrosaciUpravljac.PronadjiPotrosaca("Klima");
                                PotrosaciUpravljac.Ukljuci(temp);
                            }
                            else if (satnica == 15)
                            {
                                
                            }
                            else if (satnica == 16)
                            {
                                
                                Potrosac temp = PotrosaciUpravljac.PronadjiPotrosaca("Klima");
                                PotrosaciUpravljac.Iskljuci(temp);
                                }
                            else if (satnica == 17)
                            {
                                prazniBaterije = false;
                            }
                            else if (satnica == 18)
                            {
                                Potrosac temp = PotrosaciUpravljac.PronadjiPotrosaca("Osvetljenje");
                                PotrosaciUpravljac.Ukljuci(temp);
                                ProcenatSunca = 80;
                            }
                            else if (satnica == 19)
                            {
                                ProcenatSunca = 60;
                            }
                            else if (satnica == 20)
                            {
                                ProcenatSunca = 40;
                            }
                            else if (satnica == 21)
                            {
                                ProcenatSunca = 10;
                            }
                            else if (satnica == 22)
                            {
                                ProcenatSunca = 0;
                            }
                            else if (satnica == 23)
                            {
                                Potrosac temp = PotrosaciUpravljac.PronadjiPotrosaca("Osvetljenje");
                                PotrosaciUpravljac.Iskljuci(temp);
                            }
                            else if (satnica == 24)
                            {

                            }
                            
                        }
                        novac += Potroseno();

                        if (puniBaterije)
                        {
                            novac += PuniBaterije();
                        }
                        if (prazniBaterije)
                        {
                            novac += PrazniBaterije();
                        }



                        Thread.Sleep(Takt);


                        EnergijaBaterija = 0;
                        Kolicina = 0;


                    }
                    Dani++;
                    DateTime danas = DateTime.Now;
                    string DanasnjiDan = ((danas.Day + countDani).ToString() + '/' + danas.Month + '/' + danas.Year);
                    PotrosnjaPoDanima.Add(DanasnjiDan, novac);
                    countDani++;
                    BazaPodataka.UpisiPotrosnju();
                    satnica = 0;
                    if(novac >= 0)
                    {
                        Console.WriteLine("Zaradjeno : {0}", novac);
                    }
                    else
                    {
                        Console.WriteLine("Potroseno : {0}", novac);
                    }
                }
            }).Start();
            

        }


        #region Racunanje potrosnje

        public double Potroseno()
        {
            double kolicinaPanela = IzracunajPanele(ProcenatSunca);
            BazaPodataka.istorijaPotrosnje[countDani].ProizvodnjaSP.Add(kolicinaPanela);
            double kolicinaPotrosaca = IzracunajPotrosace();
            BazaPodataka.istorijaPotrosnje[countDani].PotrosnjaPotrosaca.Add(kolicinaPotrosaca);
            double kolicinaPunjaca = IzracunajPunjace();
            double res = IzracunajBaterije(kolicinaPanela + kolicinaPotrosaca + kolicinaPunjaca);
            BazaPodataka.istorijaPotrosnje[countDani].EnergijaIzBaterije.Add(EnergijaBaterija);
            BazaPodataka.istorijaPotrosnje[countDani].Uvoz.Add(Kolicina);

            return res;
        }


        public double IzracunajPanele(double procenatSunca)
        {
            double kolicina = 0;
            foreach (SolarniPanel s in BazaPodataka.paneli)
            {
                kolicina += s.KolicinaGenerisaneEnergije(procenatSunca);
            }
            return kolicina; //po minutu kolicina
        }

        public double IzracunajPotrosace()
        {
            double kolicina = 0;
            foreach (Potrosac p in BazaPodataka.potrosaci)
            {
                if (p.Aktivan)
                    kolicina -= p.PotrosnjaUMinutu;
            }
            return kolicina; // po minutu
        }

        public double IzracunajPunjace()
        {
            double kolicina = 0;
            foreach (PunjacAutomobila pa in BazaPodataka.punjaci)
            {
                if (pa.UtaknutAutomobil)
                {
                    double procenatKojiSeNapuniPoMinutuMaks = ((100 * pa.SnagaUMinuti) / pa.MaksBaterijaAutomobila);
                    if (100 - pa.TrenutnoBaterijaAutomobila >= procenatKojiSeNapuniPoMinutuMaks)
                    {
                        kolicina -= pa.SnagaUMinuti;
                        pa.TrenutnoBaterijaAutomobila += procenatKojiSeNapuniPoMinutuMaks;
                    }
                    else
                    {
                        double procenatPraznogAuta = 100 - pa.TrenutnoBaterijaAutomobila;
                        kolicina -= ((pa.MaksBaterijaAutomobila * procenatPraznogAuta) / 100);
                        pa.TrenutnoBaterijaAutomobila = 100;
                    }
                }
            }
            return kolicina;
        }

        public double IzracunajBaterije(double kolicina)
        {
            double novac = 0;
            if(kolicina > 0) // pune se baterije
            {
                foreach(Baterija b in BazaPodataka.baterije)
                {
                    if (b.TrKapacitetUMinutima + 1 <= b.MaksKapacitetUMinutima) // moze pun obim u roku od jednog sata
                    {
                        kolicina -= b.KolicinaKojuMozeDaIsporuciUMinuti;
                        b.TrKapacitetUMinutima++;
                        EnergijaBaterija -= b.KolicinaKojuMozeDaIsporuciUMinuti;
                    }
                }
                if(kolicina > 0) // kraj proveravanja, odnos sa distribucijom
                {
                    Kolicina -= kolicina;
                    novac = BazaPodataka.distribucija[0].Razlika(kolicina);
                }
            }
            else if(kolicina < 0)
            {
                foreach(Baterija b in BazaPodataka.baterije)
                {
                   if(b.TrKapacitetUMinutima > 0)
                    {
                        b.TrKapacitetUMinutima--;
                        Kolicina += b.KolicinaKojuMozeDaIsporuciUMinuti;
                        EnergijaBaterija += b.KolicinaKojuMozeDaIsporuciUMinuti;
                    }
                }
                if(kolicina < 0)
                {
                    Kolicina -= kolicina; // ide minus da bi bio plus posto je kolicina sama negativna
                    novac = BazaPodataka.distribucija[0].Razlika(kolicina);
                }
            }

            return novac;
        }
        #endregion

        #region UpravljanjeBaterijom

        public double PuniBaterije() 
        {
            double kolicina = 0;
            foreach(Baterija b in BazaPodataka.baterije)
            {
                if(b.TrKapacitetUMinutima < b.MaksKapacitetUMinutima)
                {
                    b.TrKapacitetUMinutima++;
                    kolicina -= b.KolicinaKojuMozeDaIsporuciUMinuti;
                    EnergijaBaterija -= b.KolicinaKojuMozeDaIsporuciUMinuti;
                }
            }
            Kolicina -= kolicina; //  ide minus da bi bio plus posto je kolicina sama negativna


            return BazaPodataka.distribucija[0].Razlika(kolicina);
        }

        public double PrazniBaterije()
        {
            double kolicina = 0;
            foreach (Baterija b in BazaPodataka.baterije)
            {
               if(b.TrKapacitetUMinutima > 0)
                {
                    b.TrKapacitetUMinutima--;
                    kolicina += b.KolicinaKojuMozeDaIsporuciUMinuti;
                    EnergijaBaterija += b.KolicinaKojuMozeDaIsporuciUMinuti;
                }
            }
            Kolicina -= kolicina;


            return BazaPodataka.distribucija[0].Razlika(kolicina);
        }

        #endregion

        #region Funkcije za WCF

        public void PromeniOsuncanost(int procenat)
        {
            ProcenatSunca = procenat;
        }

        public void UbrzajVreme(int brojac)
        {
            Takt = Takt / brojac;
        }

        public double VratiKolicinu()
        {
            return Kolicina;
        }

        public double VratiOsuncanost()
        {
            return ProcenatSunca;
        }

        public double VratiEnergijeBaterije()
        {
            return EnergijaBaterija;
        }

        public int VratiSatnicu()
        {
            return satnica;
        }

        public double VratiNovac(string datum)
        {
            if (PotrosnjaPoDanima.ContainsKey(datum))
            {
                return PotrosnjaPoDanima[datum];
            }
            else
            {
                return 0;
            }
        }

        #endregion


    }
}
