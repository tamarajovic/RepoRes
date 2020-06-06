﻿using Contracts;
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
        public static bool PromenaSatnice { get; set; } = false;
        public static int satnica { get; set; } = 0;

        public static PotrosnjaPoDanu potrosnjaPoDanu;

        public Simulacija()
        {
            potrosnjaPoDanu = new PotrosnjaPoDanu();
        }

        public void Simuliraj()
        {
            bool puniBateriju = false;
            bool prazniBateriju = false;

            new Thread(() =>
            {
                while (true)
                {
                    double novac = 0;
                    for (int i = 1; i <= 1440; i++)
                    {
 
                        if (puniBateriju)
                        {
                            novac -= PuniBaterije();
                            puniBateriju = false;
                        }
                        if (prazniBateriju)
                        {
                            novac += PrazniBaterije();
                            prazniBateriju = false;
                        }
                        if (i % 60 == 0)
                        {
                            PromenaSatnice = false;
                            
                            if(satnica == 0)
                            {
                                PromenaSatnice = true;
                            }
                            else if (satnica == 1)
                            {
                                PromenaSatnice = true;
                            }
                            else if (satnica == 2)
                            {
                                PromenaSatnice = true;
                            }
                            else if (satnica == 3)
                            {
                                PromenaSatnice = true;
                                puniBateriju = true;
                                Console.WriteLine("Puni Baterije");
                                foreach (Baterija b in BazaPodataka.baterije)
                                {
                                    Console.WriteLine("{0} -- {1}", b.Ime, b.TrKapacitet);
                                }
                            }
                            else if (satnica == 4)
                            {
                                PromenaSatnice = true;
                                puniBateriju = true;
                                foreach (Baterija b in BazaPodataka.baterije)
                                {
                                    Console.WriteLine("{0} -- {1}", b.Ime, b.TrKapacitet);
                                }
                            }
                            else if (satnica == 5)
                            {
                                PromenaSatnice = true;
                                puniBateriju = true;
                                ProcenatSunca = 30;
                                foreach (Baterija b in BazaPodataka.baterije)
                                {
                                    Console.WriteLine("{0} -- {1}", b.Ime, b.TrKapacitet);
                                }
                            }
                            else if (satnica == 6)
                            {
                                PromenaSatnice = true;
                                puniBateriju = false;
                                Console.WriteLine("Ne puni vise baterije");
                                foreach (Baterija b in BazaPodataka.baterije)
                                {
                                    Console.WriteLine("{0} -- {1}", b.Ime, b.TrKapacitet);
                                }
                                BazaPodataka.potrosaci[3].Aktivan = true;
                            }
                            else if (satnica == 7)
                            {
                                PromenaSatnice = true;
                                ProcenatSunca = 60;
                            }
                            else if (satnica == 8)
                            {
                                PromenaSatnice = true;
                            }
                            else if (satnica == 9)
                            {
                                PromenaSatnice = true;
                                ProcenatSunca = 100.0;
                            }
                            else if (satnica == 10)
                            {
                                PromenaSatnice = true;
                            }
                            else if (satnica == 11)
                            {
                                PromenaSatnice = true;
                            }
                            else if (satnica == 12)
                            {
                                PromenaSatnice = true;
                            }
                            else if (satnica == 13)
                            {
                                PromenaSatnice = true;
                            }
                            else if (satnica == 14)
                            {
                                PromenaSatnice = true;
                                prazniBateriju = true;
                                Console.WriteLine("Prazni baterije");
                                foreach (Baterija b in BazaPodataka.baterije)
                                {
                                    Console.WriteLine("{0} -- {1}", b.Ime, b.TrKapacitet);
                                }
                            }
                            else if (satnica == 15)
                            {
                                PromenaSatnice = true;
                                prazniBateriju = true;
                            }
                            else if (satnica == 16)
                            {
                                PromenaSatnice = true;
                                prazniBateriju = true;
                            }
                            else if (satnica == 17)
                            {
                                PromenaSatnice = true;
                                Console.WriteLine("Ne prazni vise baterije");
                                foreach (Baterija b in BazaPodataka.baterije)
                                {
                                    Console.WriteLine("{0} -- {1}", b.Ime, b.TrKapacitet);
                                }
                            }
                            else if (satnica == 18)
                            {
                                PromenaSatnice = true;
                            }
                            else if (satnica == 19)
                            {
                                PromenaSatnice = true;
                            }
                            else if (satnica == 20)
                            {
                                PromenaSatnice = true;
                                ProcenatSunca = 70;
                            }
                            else if (satnica == 21)
                            {
                                PromenaSatnice = true;
                                ProcenatSunca = 40;
                            }
                            else if (satnica == 22)
                            {
                                PromenaSatnice = true;
                                ProcenatSunca = 0;
                            }
                            else if (satnica == 23)
                            {
                                PromenaSatnice = true;
                            }

                            novac += Potroseno();

                            potrosnjaPoDanu.EnergijaIzBaterije.Add(EnergijaBaterija);
                            //dodati uvoz, paneli i potrosaci


                            satnica++;
                            Kolicina = 0;
                            EnergijaBaterija = 0;
                        }

                        Thread.Sleep(Takt);


                    }
                    Dani++;
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
                    BazaPodataka.distribucija[0].Trosi = false;
                    Kolicina += kolicina;
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
                            if (b.MaksKapacitet - b.TrKapacitet >= b.MaxSnaga) // ceo kapacitet za jedan sat se skine sa baterije
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
                if(kolicina < 0)
                {
                    kolicina = kolicina * (-1);
                    Kolicina += kolicina;
                    BazaPodataka.distribucija[0].Trosi = true;
                    novac = BazaPodataka.distribucija[0].Razlika(kolicina);
                }
            }

            return novac;
        }
        #endregion

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
            Kolicina -= kolicina;

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
            Kolicina += kolicina;

            return BazaPodataka.distribucija[0].Razlika(kolicina);
        }


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

        public bool ProveriSatnicu()
        {
            return PromenaSatnice;
        }

        public int VratiSatnicu()
        {
            return satnica;
        }

        //potrosnja za grafik
        public PotrosnjaPoDanu VratiPotrosnju(DateTime datum)
        {
            PotrosnjaPoDanu potrosnja = new PotrosnjaPoDanu();

            foreach (var p in BazaPodataka.istorijaPotrosnje)
            {
                if (p.Datum.Equals(datum))
                {
                    return p;
                }
                    
            }

            return potrosnja;
        }



    }
}
