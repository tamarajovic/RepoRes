using Contracts;
using Klase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Res
{

    public class Program
    {

        public static void Main(string[] args)
        {


            #region Connection
            NetTcpBinding binding = new NetTcpBinding();

            string addressBaterija = "net.tcp://localhost:8000/IBaterija";
            ChannelFactory<IBaterija> channelBaterija = new ChannelFactory<IBaterija>(binding, addressBaterija);
            IBaterija proxyBaterija = channelBaterija.CreateChannel();

            string addressPunjac = "net.tcp://localhost:8000/IPunjac";
            ChannelFactory<IPunjac> channelPunjac = new ChannelFactory<IPunjac>(binding, addressPunjac);
            IPunjac proxyPunjac = channelPunjac.CreateChannel();

            string addressPotrosac = "net.tcp://localhost:8000/IPotrosac";
            ChannelFactory<IPotrosac> channelPotrosac = new ChannelFactory<IPotrosac>(binding, addressPotrosac);
            IPotrosac proxyPotrosac = channelPotrosac.CreateChannel();

            string addressPanel = "net.tcp://localhost:8000/ISolarniPanel";
            ChannelFactory<ISolarniPanel> channelPanel = new ChannelFactory<ISolarniPanel>(binding, addressPanel);
            ISolarniPanel proxyPanel = channelPanel.CreateChannel();

            //uraditi za panel i potrosac
            #endregion

            Meni(proxyPunjac, proxyBaterija, proxyPanel, proxyPotrosac);


            Baterija b1 = new Baterija("glavnaBaterija", 60, 8000);
            if (proxyBaterija.DodajBateriju(b1))
                Console.WriteLine("baterija uspesno dodata");
            else Console.WriteLine("greska");

        }

        public static void Meni(IPunjac ppunjac, IBaterija pbaterija, ISolarniPanel ppanel, IPotrosac ppotrosac)
        {
            int komanda = 0;

            do
            {
                try
                {
                    Console.WriteLine("Izaberite opciju:");

                    Console.WriteLine("1 --> Dodajte novi element u sistem");
                    Console.WriteLine("2 --> Ukljucite potrosaca");
                    Console.WriteLine("3 --> Iskljucite potrosaca");
                    Console.WriteLine("4 --> Promenite osvetljenost sunca");
                    Console.WriteLine("5 --> Izlaz iz sistema");

                    Console.WriteLine("Vas odgovor: ");
                    komanda = int.Parse(Console.ReadLine());

                    switch (komanda)
                    {
                        case 1:
                            int dodajNovi;
                            do { 
                                
                                Console.WriteLine("Odaberite sta zelite da dodate");
                                Console.WriteLine("1 --> Potrosac");
                                Console.WriteLine("2 --> Solarni Panel");
                                Console.WriteLine("3 --> Baterija");
                                Console.WriteLine("4 --> Punjac za automobil");
                                Console.WriteLine("5 --> Nazad");
                                Console.WriteLine("Vas odgovor: ");
                                dodajNovi = int.Parse(Console.ReadLine());

                                switch (dodajNovi)
                                {
                                    case 1:
                                        {
                                            Console.WriteLine("Ime potrosaca: ");
                                            string ime = Console.ReadLine();
                                            Console.WriteLine("Potrosnja potrosaca: ");
                                            int potrosnja = int.Parse(Console.ReadLine());
                                            Potrosac po = new Potrosac(ime, potrosnja);
                                            if (ppotrosac.DodajPotrosaca(po))
                                                Console.WriteLine("Uspesno dodat novi potrosac");
                                            else
                                                Console.WriteLine("Potrosac sa ovakvim imenom vec postoji");
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.WriteLine("Ime solarnog panela: ");
                                            string ime = Console.ReadLine();
                                            Console.WriteLine("Maksimalna snaga panela: ");
                                            int snaga = int.Parse(Console.ReadLine());
                                            if (ppanel.DodajPanel(new SolarniPanel(ime, snaga)))
                                                Console.WriteLine("Uspesno dodat novi solarni panel");
                                            else
                                                Console.WriteLine("Solarni panel sa ovakvim imenom vec postoji");
                                            break;
                                        }
                                    case 3:
                                        {
                                            Console.WriteLine("Ime baterije: ");
                                            string ime = Console.ReadLine();
                                            Console.WriteLine("Maksimalna snaga baterije: ");
                                            double snaga = double.Parse(Console.ReadLine());
                                            Console.WriteLine("Kapacitet baterije: ");
                                            double kapacitet = double.Parse(Console.ReadLine());
                                            Baterija b = new Baterija(ime, snaga, kapacitet);
                                            if (pbaterija.DodajBateriju(b))
                                                Console.WriteLine("Baterija je uspesno dodata");
                                            else
                                                Console.WriteLine("Greska prilikom dodavanja baterije");
                                            break;
                                        }
                                    case 4:
                                        {
                                            Console.WriteLine("Naziv punjaca za automobil: ");
                                            string ime = Console.ReadLine();
                                            Console.WriteLine("Trenutno stanje baterije: ");
                                            int stanje = int.Parse(Console.ReadLine());
                                            Console.WriteLine("Snaga punjaca: ");
                                            int snaga = int.Parse(Console.ReadLine());
                                            Console.WriteLine("Kapacitet baterije automobila: ");
                                            int kapacitet = int.Parse(Console.ReadLine());
                                            PunjacAutomobila pa = new PunjacAutomobila(ime, snaga, stanje, kapacitet);
                                            if (ppunjac.DodajPunjac(pa))
                                                Console.WriteLine("Punjac automobila je uspesno dodat");
                                            else
                                                Console.WriteLine("Greska prilikom dodavanja punjaca automobila");
                                            break;
                                        }
                                    default:
                                        Console.WriteLine("Molimo vas da unesete neki od ponudjenih odgovora");
                                        break;
                                }

                            } while (dodajNovi != 5);

                            break;
                        case 2:
                            Console.WriteLine("Unesite ime potrosaca: ");
                            string potrosac = Console.ReadLine();
                            Potrosac p = ppotrosac.PronadjiPotrosaca(potrosac);
                            if (p == null)
                            {
                                Console.WriteLine("Ne postoji potrosac sa imenom {0}", potrosac);
                                break;
                            }
                            else
                            {
                                if (p.Aktivan)
                                {
                                    Console.WriteLine("Potrosac je vec pokrenut");
                                    break;
                                }
                                p.PokreniPotrosnju();
                                Console.WriteLine("Potrosac {0} pokrenut", potrosac);
                            }
                            break;
                        case 3:
                            Console.WriteLine("Unesite ime potrosaca: ");
                            potrosac = Console.ReadLine();
                            p = ppotrosac.PronadjiPotrosaca(potrosac);
                            if (p == null)
                            {
                                Console.WriteLine("Ne postoji potrosac sa imenom {0}", potrosac);
                                break;
                            }
                            else
                            {
                                if (!p.Aktivan)
                                {
                                    Console.WriteLine("Potrosac nije bio aktivan");
                                    break;
                                }
                                p.ZaustaviPotrosnju();
                                Console.WriteLine("Potrosac {0} pokrenut", potrosac);
                            }


                            break;

                    }


                }
                catch(FormatException ex)
                {
                    Console.WriteLine("Molimo vas da unesete neki od ponudjenih brojeva, dodatne informacije : " + ex.Message);
                }
            }
            while (komanda != 123);


        }


    }

}
