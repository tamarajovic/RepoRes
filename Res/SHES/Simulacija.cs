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

        public static int countDani = 0;
        

        public Simulacija()
        {
            
        }

        public void Simuliraj()
        {

            new Thread(() =>
            {
            while (true)
            {
                double novac = 0;
                for (int i = 1; i <= 1440; i++)
                {
                    if (i % 60 == 0)
                    {

                        if (satnica == 0)
                        {
                            BazaPodataka.istorijaPotrosnje.Add(new PotrosnjaPoDanu());
                        }
                        else if (satnica == 1)
                        {
                        }
                        else if (satnica == 2)
                        {

                        }
                        else if (satnica == 3)
                        {
                            BazaPodataka.distribucija[0].CenaPokWh = 1.5;
                            novac -= PuniBaterije();
                            Console.WriteLine("Puni Baterije");

                        }
                        else if (satnica == 4)
                        {
                            
                            novac -= PuniBaterije();
                        }
                        else if (satnica == 5)
                        {
                            
                            novac -= PuniBaterije();
                            ProcenatSunca = 30;
                        }
                        else if (satnica == 6)
                        {
                            BazaPodataka.distribucija[0].CenaPokWh = 3;
                        }
                        else if (satnica == 7)
                        {
                            
                            ProcenatSunca = 60;
                        }
                        else if (satnica == 8)
                        {
                           
                        }
                        else if (satnica == 9)
                        {
                           
                            ProcenatSunca = 100.0;
                        }
                        else if (satnica == 10)
                        {
                           
                        }
                        else if (satnica == 11)
                        {
                            
                        }
                        else if (satnica == 12)
                        {
                            
                        }
                        else if (satnica == 13)
                        {
                            
                        }
                        else if (satnica == 14)
                        {
                            
                            novac += PrazniBaterije();
                            BazaPodataka.distribucija[0].CenaPokWh = 5;
                        }
                        else if (satnica == 15)
                        {
                            
                            novac += PrazniBaterije();
                        }
                        else if (satnica == 16)
                        {
                            
                            novac += PrazniBaterije();
                        }
                        else if (satnica == 17)
                        {
                            BazaPodataka.distribucija[0].CenaPokWh = 3;

                        }
                        else if (satnica == 18)
                        {
                            
                        }
                        else if (satnica == 19)
                        {
                            
                        }
                        else if (satnica == 20)
                        {
                            
                            ProcenatSunca = 70;
                        }
                        else if (satnica == 21)
                        {
                            
                            ProcenatSunca = 40;
                        }
                        else if (satnica == 22)
                        {
                            
                            ProcenatSunca = 0;
                        }
                        else if (satnica == 23)
                        {
                            
                        }

                        novac += Potroseno();

                        BazaPodataka.istorijaPotrosnje[countDani].EnergijaIzBaterije.Add(EnergijaBaterija);
                        double potrosnjaAktivnih = 0;
                        foreach (Potrosac p in BazaPodataka.potrosaci)
                        {
                            if (p.Aktivan)
                                potrosnjaAktivnih -= p.Potrosnja;
                        }
                        BazaPodataka.istorijaPotrosnje[countDani].PotrosnjaPotrosaca.Add(potrosnjaAktivnih);
                        double proizvodnjaPanela = 0;

                        foreach (SolarniPanel sp in BazaPodataka.paneli)
                        {
                            proizvodnjaPanela += sp.KolicinaGenerisaneEnergije(ProcenatSunca);
                        }
                        BazaPodataka.istorijaPotrosnje[countDani].ProizvodnjaSP.Add(proizvodnjaPanela);
                        BazaPodataka.istorijaPotrosnje[countDani].Uvoz.Add(Kolicina);


                        satnica++;
                        Kolicina = 0;
                        EnergijaBaterija = 0;
                    }

                     Thread.Sleep(Takt);


                }
                countDani++;
                Dani++;
                BazaPodataka.UpisiPotrosnju();
                satnica = 0;
                Console.WriteLine("Prodje dan, potroseno {0}", novac);
                }
            }).Start();
            

        }


        #region Racunanje potrosnje

        public double Potroseno()
        {
            double kolicina = 0;
            kolicina += IzracunajPanele(ProcenatSunca);
            kolicina += IzracunajPotrosace();
            kolicina += IzracunajPunjace();
            return IzracunajBaterije(kolicina);
        }


        public double IzracunajPanele(double procenatSunca)
        {
            double kolicina = 0;
            foreach (SolarniPanel s in BazaPodataka.paneli)
            {
                kolicina += s.KolicinaGenerisaneEnergije(procenatSunca);
            }
            return kolicina; //po satu kolicina
        }

        public double IzracunajPotrosace()
        {
            double kolicina = 0;
            foreach (Potrosac p in BazaPodataka.potrosaci)
            {
                if (p.Aktivan)
                    kolicina -= p.Potrosnja;
            }
            return kolicina; // po satu
        }

        public double IzracunajPunjace()
        {
            double kolicina = 0;
            foreach (PunjacAutomobila pa in BazaPodataka.punjaci)
            {
                if (pa.UtaknutAutomobil)
                {
                    int procenatKojiSeNapuniPoSatuMaks = ((100 * pa.SnagaBaterijePunjaca) / pa.MaksBaterijaAutomobila);
                    if (100 - pa.TrenutnoBaterijaAutomobila >= procenatKojiSeNapuniPoSatuMaks)
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
            return kolicina;
        }

        public double IzracunajBaterije(double kolicina)
        {
            double novac = 0;
            if(kolicina > 0) // pune se baterije
            {
                foreach(Baterija b in BazaPodataka.baterije)
                {
                    if(b.TrKapacitet < b.MaksKapacitet)
                    {
                        if (kolicina >= b.MaxSnaga) // ne moze sve da stane u jednu bateriju tokom jedne iteracije, ili je knap
                        {
                            if (b.TrKapacitet + b.MaxSnaga <= b.MaksKapacitet) // moze pun obim u roku od jednog sata
                            {
                                kolicina -= b.MaxSnaga;
                                b.TrKapacitet += b.MaxSnaga;
                                EnergijaBaterija -= b.MaxSnaga;
                            }
                            else // ne moze pun obim
                            {
                                kolicina -= (b.MaksKapacitet - b.TrKapacitet);
                                b.TrKapacitet = b.MaksKapacitet;
                                EnergijaBaterija -= (b.MaksKapacitet - b.TrKapacitet);
                            }
                        }
                        else
                        {
                            if (b.TrKapacitet + kolicina <= b.MaksKapacitet)
                            {
                                b.TrKapacitet += kolicina;
                                EnergijaBaterija -= kolicina;
                                kolicina = 0;
                            }
                            else
                            {
                                double mestaNaBateriji = b.MaksKapacitet - b.TrKapacitet;
                                if(kolicina <= mestaNaBateriji)
                                {
                                    b.TrKapacitet += kolicina;
                                    EnergijaBaterija -= kolicina;
                                    kolicina = 0;
                                }
                                else
                                {
                                    EnergijaBaterija -= mestaNaBateriji;
                                    b.TrKapacitet += mestaNaBateriji;
                                    kolicina -= mestaNaBateriji;
                                }
                            }
                        }
                    }
                }
                if(kolicina > 0) // kraj proveravanja, odnos sa distribucijom
                {
                    Kolicina -= kolicina;
                    novac = BazaPodataka.distribucija[0].Razlika(kolicina);
                }
            }
            else // prazne se baterije
            {
                kolicina = kolicina * (-1);
                foreach(Baterija b in BazaPodataka.baterije)
                {
                    if(b.TrKapacitet > 0)
                    {
                        if (kolicina >= b.MaxSnaga) // treba joj ili maks ili vise od jedne baterija
                        {
                            if (b.TrKapacitet >= b.MaxSnaga) // ceo kapacitet za jedan sat se skine sa baterije
                            {
                                kolicina -= b.MaxSnaga;
                                b.TrKapacitet -= b.MaxSnaga;
                                EnergijaBaterija += b.MaxSnaga;
                            }
                            else // skida se sa baterije sve
                            {
                                kolicina -= b.TrKapacitet;
                                b.TrKapacitet = 0;
                                EnergijaBaterija += b.TrKapacitet;
                            }
                        }
                        else // treba joj samo jedna baterija
                        {
                            if (b.TrKapacitet >= kolicina) // sve moze sa jedne baterije
                            {
                                b.TrKapacitet -= kolicina;
                                kolicina = 0;
                                EnergijaBaterija += kolicina;
                            }
                            else
                            {
                                EnergijaBaterija += b.TrKapacitet;
                                kolicina -= b.TrKapacitet;
                                b.TrKapacitet = 0;
                            }
                        }
                    }
                }
                if(kolicina > 0)
                {
                    kolicina = kolicina * (-1);
                    Kolicina -= kolicina;
                    novac = BazaPodataka.distribucija[0].Razlika(kolicina);
                }
            }

            return novac;
        }
        #endregion

        #region UpravljanjeBaterijom

        public double PuniBaterije() // vraca kolicinu potrosene energije
        {
            double kolicina = 0;
            foreach(Baterija b in BazaPodataka.baterije)
            {
                if(b.TrKapacitet < b.MaksKapacitet)
                {
                    //double procenatKojiSeNapuniPoSatuMaks = ((100 * b.MaxSnaga) / b.Kapacitet);
                    if (b.TrKapacitet + b.MaxSnaga <= b.MaksKapacitet) // moze pun obim u roku od jednog sata
                    {
                        EnergijaBaterija -= b.MaxSnaga;
                        kolicina += b.MaxSnaga;
                        b.TrKapacitet += b.MaxSnaga;
                    }
                    else // ne moze pun obim
                    {
                        EnergijaBaterija -= b.TrKapacitet;
                        kolicina += b.TrKapacitet;
                        b.TrKapacitet = 0;
                    }
                }
            }
            Kolicina += kolicina;

            return BazaPodataka.distribucija[0].Razlika(-kolicina);
        }

        public double PrazniBaterije()
        {
            double kolicina = 0;
            foreach (Baterija b in BazaPodataka.baterije)
            {
                if (b.TrKapacitet > 0)
                {
                    //double procenatKojiSeIsprazniPoSatuMaks = ((100 * b.MaxSnaga) / b.Kapacitet);
                    if (b.TrKapacitet - b.MaxSnaga >= 0) // ceo kapacitet za jedan sat se skine sa baterije
                    {
                        EnergijaBaterija += b.MaxSnaga;
                        kolicina += b.MaxSnaga;
                        b.TrKapacitet -= b.MaxSnaga;

                    }
                    else // skida se sa baterije sve
                    {
                        EnergijaBaterija += b.TrKapacitet;
                        kolicina += b.TrKapacitet;
                        b.TrKapacitet = 0;
                    }
                }
            }
            Kolicina -= kolicina;

            return BazaPodataka.distribucija[0].Razlika(kolicina);
        }

        #endregion

        public void PromeniOsuncanost(int procenat)
        {
            ProcenatSunca = procenat;
        }

        public void UbrzajVreme(int brojac)
        {
            Takt = brojac;
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




    }
}
