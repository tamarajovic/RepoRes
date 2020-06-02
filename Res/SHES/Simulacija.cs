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
        public int Takt { get; set; } = 417; //ucita se iz xml-a ceo dan zza 10 min 

        public static int Dani { get; set; }

        public int ProcenatSunca { get; set; }

        public Simulacija()
        {
            Dani = 0;
            ProcenatSunca = 0;
            Simuliraj(Takt, ProcenatSunca);
        }

        public void Simuliraj(int brojac, int ProcenatSunca)
        {
            bool puniBateriju = false;
            bool prazniBateriju = false;

            new Thread(() =>
            {
                while (true)
                {
                    int satnica = 0;
                    double novac = 0;
                    for (int i = 1; i <= 1440; i++)
                    {
                        if (puniBateriju)
                        {
                            novac += PuniBaterije();
                        }
                        if (prazniBateriju)
                        {
                            novac -= PrazniBaterije();
                        }
                        if (i % 60 == 0)
                        {
                            novac += Potroseno();
                            satnica++;

                            if (satnica == 3)
                            {
                                puniBateriju = true;
                                Console.WriteLine("Puni Baterije");
                            }
                            if (satnica == 5)
                                ProcenatSunca = 30;
                            if (satnica == 6)
                            {
                                puniBateriju = false;
                                Console.WriteLine("Ne puni vise baterije");
                            }
                            if (satnica == 7)
                                ProcenatSunca = 60;
                            if (satnica == 9)
                                ProcenatSunca = 100;
                            if (satnica == 14)
                            {
                                prazniBateriju = true;
                                Console.WriteLine("Prazni baterije");
                            }
                            if (satnica == 17)
                            {
                                prazniBateriju = false;
                                Console.WriteLine("Ne prazni vise baterije");
                            }
                            if (satnica == 20)
                                ProcenatSunca = 70;
                            if (satnica == 21)
                                ProcenatSunca = 40;
                            if (satnica == 22)
                                ProcenatSunca = 0;

                        }

                        Thread.Sleep(brojac);


                    }
                    Dani++;
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


        public double IzracunajPanele(int procenatSunca)
        {
            double kolicina = 0;
            foreach (SolarniPanel s in BazaPodataka.paneli)
            {
                kolicina += s.KolicinaGenerisaneEnergije(procenatSunca);
            }
            return kolicina;
        }

        public double IzracunajPotrosace()
        {
            double kolicina = 0;
            foreach (Potrosac p in BazaPodataka.potrosaci)
            {
                if (p.Aktivan)
                    kolicina -= p.Potrosnja;
            }
            return kolicina;
        }

        public double IzracunajPunjace()
        {
            double kolicina = 0;
            foreach (PunjacAutomobila pa in BazaPodataka.punjaci)
            {
                if (pa.UtaknutAutomobil)
                {
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
            return kolicina;
        }

        public double IzracunajBaterije(double kolicina)
        {
            double novac = 0;
            if(kolicina > 0) // pune se baterije
            {
                foreach(Baterija b in BazaPodataka.baterije)
                {
                    if(b.TrProcenat < 100)
                    {
                        if (kolicina >= b.MaxSnaga) // ne moze sve da stane u jednu bateriju tokom jedne iteracije, ili je knap
                        {
                            double procenatKojiSeNapuniPoSatuMaks = ((100 * b.MaxSnaga) / b.Kapacitet);
                            if (100 - b.TrProcenat >= procenatKojiSeNapuniPoSatuMaks) // moze pun obim u roku od jednog sata
                            {
                                kolicina -= b.MaxSnaga;
                                b.TrProcenat += procenatKojiSeNapuniPoSatuMaks;
                                b.PromeniKapacitet(true);
                            }
                            else // ne moze pun obim
                            {
                                double procenatPrazneBaterije = 100 - b.TrProcenat;
                                kolicina -= ((b.MaxSnaga * procenatPrazneBaterije) / 100);
                                b.TrProcenat = 100;
                                b.PromeniKapacitet(true);
                            }
                        }
                        else // sve moze u jednu bateriju 
                        {
                            double kolikoProcenataMozeDaSeDopuni = ((100 * kolicina) / b.Kapacitet);
                            if (100 - b.TrProcenat >= kolikoProcenataMozeDaSeDopuni)
                            {
                                kolicina = 0;
                                b.TrProcenat += kolikoProcenataMozeDaSeDopuni;
                                b.PromeniKapacitet(true);
                            }
                            else
                            {
                                double procenatPrazneBaterije = 100 - b.TrProcenat;
                                kolicina -= ((b.MaxSnaga * procenatPrazneBaterije) / 100);
                                b.TrProcenat = 100;
                                b.PromeniKapacitet(true);
                            }
                        }
                    }
                }
                if(kolicina > 0) // kraj proveravanja, odnos sa distribucijom
                {
                    BazaPodataka.distribucija[0].Trosi = false;
                    novac = (int)BazaPodataka.distribucija[0].Razlika(kolicina);
                }
            }
            else // prazne se baterije
            {
                foreach(Baterija b in BazaPodataka.baterije)
                {
                    if(b.TrProcenat > 0)
                    {
                        if (kolicina >= b.MaxSnaga) // treba joj ili maks ili vise od jedne baterija
                        {
                            double procenatKojiSeIsprazniPoSatuMaks = ((100 * b.MaxSnaga) / b.Kapacitet);
                            if (b.TrProcenat - procenatKojiSeIsprazniPoSatuMaks >= 0) // ceo kapacitet za jedan sat se skine sa baterije
                            {
                                kolicina += b.MaxSnaga;
                                b.TrProcenat -= procenatKojiSeIsprazniPoSatuMaks;
                                b.PromeniKapacitet(false);
                            }
                            else // skida se sa baterije sve
                            {
                                kolicina += ((b.MaxSnaga * b.TrProcenat) / 100);
                                b.TrProcenat = 0;
                                b.PromeniKapacitet(false);
                            }
                        }
                        else // treba joj samo jedna baterija
                        {
                            double procenatKojiCeSkinutiKolicina = ((100 * kolicina) / b.Kapacitet);
                            if (b.TrProcenat - procenatKojiCeSkinutiKolicina >= 0) // sve moze sa jedne baterije
                            {
                                kolicina = 0;
                                b.TrProcenat -= procenatKojiCeSkinutiKolicina;
                                b.PromeniKapacitet(false);
                            }
                            else
                            {
                                kolicina -= ((b.MaxSnaga * b.TrProcenat) / 100);
                                b.TrProcenat = 0;
                                b.PromeniKapacitet(false);
                            }
                        }
                    }
                }
                if(kolicina < 0)
                {
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
                if(b.TrProcenat < 100)
                {
                    double procenatKojiSeNapuniPoSatuMaks = ((100 * b.MaxSnaga) / b.Kapacitet);
                    if (100 - b.TrProcenat >= procenatKojiSeNapuniPoSatuMaks) // moze pun obim u roku od jednog sata
                    {
                        kolicina += b.MaxSnaga;
                        b.TrProcenat += procenatKojiSeNapuniPoSatuMaks;
                        b.PromeniKapacitet(true);
                    }
                    else // ne moze pun obim
                    {
                        double procenatPrazneBaterije = 100 - b.TrProcenat;
                        kolicina += ((b.MaxSnaga * procenatPrazneBaterije) / 100);
                        b.TrProcenat = 100;
                        b.PromeniKapacitet(true);
                    }
                }
            }
            return kolicina;
        }

        public double PrazniBaterije()
        {
            double kolicina = 0;
            foreach (Baterija b in BazaPodataka.baterije)
            {
                if (b.TrProcenat > 0)
                {
                    double procenatKojiSeIsprazniPoSatuMaks = ((100 * b.MaxSnaga) / b.Kapacitet);
                    if (b.TrProcenat - procenatKojiSeIsprazniPoSatuMaks >= 0) // ceo kapacitet za jedan sat se skine sa baterije
                    {
                        kolicina += b.MaxSnaga;
                        b.TrProcenat -= procenatKojiSeIsprazniPoSatuMaks;
                        b.PromeniKapacitet(false);
                    }
                    else // skida se sa baterije sve
                    {
                        kolicina += ((b.MaxSnaga * b.TrProcenat) / 100);
                        b.TrProcenat = 0;
                        b.PromeniKapacitet(false);
                    }
                }
            }
            return kolicina;
        }


        public void PromeniOsuncanost(int procenat)
        {
            ProcenatSunca = procenat;
        }

        public void UbrzajVreme(int brojac)
        {
            Takt = brojac;
        }

        public void SnimiIzvestaj()
        {
            FileStream fs = new FileStream("dnevniIzvestaji.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            string izvestaj = "";
            //sta se sve pise u izvestaj
            sw.WriteLine(izvestaj);
            sw.Close();
            fs.Close();
        }
    }
}
