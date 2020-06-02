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


            string addressSimulacija = "net.tcp://localhost:8000/ISimulacija";
            ChannelFactory<ISimulacija> channelSimulacija = new ChannelFactory<ISimulacija>(binding, addressSimulacija);
            ISimulacija proxySimulacija = channelSimulacija.CreateChannel();
            #endregion

            Meni(proxyPunjac, proxyBaterija, proxyPanel, proxyPotrosac, proxySimulacija);


        }

        public static void Meni(IPunjac ppunjac, IBaterija pbaterija, ISolarniPanel ppanel, IPotrosac ppotrosac, ISimulacija psimulacija)
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
                    Console.WriteLine("4 --> Ukljucite automobil na punjac");
                    Console.WriteLine("5 --> Iskljucite automobil sa punjaca");
                    Console.WriteLine("6 --> Obrisite elemenat iz sistema");
                    Console.WriteLine("7 --> Menjajte brzinu prolaska vremena");
                    Console.WriteLine("8 --> Promenite osuncanost");
                    Console.WriteLine("9 --> Izlaz iz sistema");

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
                                            double potrosnja = double.Parse(Console.ReadLine());
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
                                            int snaga = int.Parse(Console.ReadLine());
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
                                            Console.WriteLine("Snaga punjaca: ");
                                            int snaga = int.Parse(Console.ReadLine());
                                            Console.WriteLine("Unesite koliko vas automobil ima trenutno procenata baterije: ");
                                            int kolicinaBaterije = int.Parse(Console.ReadLine());
                                            Console.WriteLine("Unesite koliko je kapacitet baterije vaseg automobila: ");
                                            int maksKoliicinabaterije = int.Parse(Console.ReadLine());
                                            PunjacAutomobila pauto = new PunjacAutomobila(ime, snaga, kolicinaBaterije, maksKoliicinabaterije);
                                            if (ppunjac.DodajPunjac(pauto))
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
                            string potrosac1 = Console.ReadLine();
                            Potrosac p1 = ppotrosac.PronadjiPotrosaca(potrosac1);
                            if (p1 == null)
                            {
                                Console.WriteLine("Ne postoji potrosac sa imenom {0}", potrosac1);
                                break;
                            }
                            else
                            {
                                if (p1.Aktivan)
                                {
                                    Console.WriteLine("Potrosac je vec pokrenut");
                                    break;
                                }
                                ppotrosac.Ukljuci(potrosac1);
                                Console.WriteLine("Potrosac {0} ukljucen", potrosac1);
                            }
                            

                            break;
                        case 3:
                            Console.WriteLine("Unesite ime potrosaca: ");
                            string potrosac2 = Console.ReadLine();
                            Potrosac p2 = ppotrosac.PronadjiPotrosaca(potrosac2);
                            if (p2 == null)
                            {
                                Console.WriteLine("Ne postoji potrosac sa imenom {0}", potrosac2);
                                break;
                            }
                            else
                            {
                                if (!p2.Aktivan)
                                {
                                    Console.WriteLine("Potrosac nije bio aktivan");
                                    break;
                                }
                                ppotrosac.Iskljuci(potrosac2);
                                Console.WriteLine("Potrosac {0} iskljucen", potrosac2);
                            }
                            break;
                        case 4:
                            Console.WriteLine("Unesite naziv punjaca: ");
                            string naziv = Console.ReadLine();
                            PunjacAutomobila pa = ppunjac.PronadjiPunjac(naziv);
                            if (pa == null)
                            {
                                Console.WriteLine("Ne postoji punjac {0}", naziv);
                            }
                            else if (pa.UtaknutAutomobil == true)
                            {
                                Console.WriteLine("Vec je utaknut drugi automobil");
                            }
                            else
                            {

                                if (pa.MaksBaterijaAutomobila > pa.TrenutnoBaterijaAutomobila)
                                {
                                    ppunjac.Ukljuci(naziv);
                                    Console.WriteLine("Automobil je ukljucen na punjac {0}", naziv);
                                }
                                else
                                {
                                    ppunjac.Ukljuci(naziv);
                                    Console.WriteLine("Vas auto je vec pun");
                                    break;
                                }

                            }
                            break;

                        case 5:
                            Console.WriteLine("Unesite naziv punjaca: ");
                            string nazivZaBrisanje = Console.ReadLine();
                            PunjacAutomobila pa2 = ppunjac.PronadjiPunjac(nazivZaBrisanje);
                            if (pa2 == null)
                            {
                                Console.WriteLine("Ne postoji punjac {0}", nazivZaBrisanje);
                                break;
                            }
                            else
                            {
                                if (!pa2.UtaknutAutomobil)
                                {
                                    Console.WriteLine("Nema utaknutog automobila na punjac");
                                    break;
                                }
                                else
                                {
                                    ppunjac.Iskljuci(nazivZaBrisanje);
                                    Console.WriteLine("Automobil je istaknut sa punjaca {0}", pa2.Naziv);
                                }
                            }
                            break;

                        case 6:
                            int obrisi;
                            do
                            {

                                Console.WriteLine("Odaberite sta zelite da dodate");
                                Console.WriteLine("1 --> Potrosac");
                                Console.WriteLine("2 --> Solarni Panel");
                                Console.WriteLine("3 --> Baterija");
                                Console.WriteLine("4 --> Punjac za automobil");
                                Console.WriteLine("5 --> Nazad");
                                Console.WriteLine("Vas odgovor: ");
                                obrisi = int.Parse(Console.ReadLine());

                                switch (obrisi)
                                {
                                    case 1:
                                        Console.WriteLine("Unestie ime potrosaca: ");
                                        string imep = Console.ReadLine();
                                        if (ppotrosac.ObrisiPotrosaca(imep))
                                            Console.WriteLine("Uspesno obrisan potrosac {0}", imep);
                                        Console.WriteLine("Ne postoji potrosac sa imenom {0}", imep);
                                        break;

                                    case 2:
                                        Console.WriteLine("Unesite ime Solarnog panela: ");
                                        string imes = Console.ReadLine();
                                        if(ppanel.ObrisiPanel(imes))
                                            Console.WriteLine("Uspesno obrisan panel {0}", imes);
                                        Console.WriteLine("Ne postoji panel sa imenom {0}", imes);
                                        break;

                                    case 3:
                                        Console.WriteLine("Unesite ime baterije: ");
                                        string imeb = Console.ReadLine();
                                        if(pbaterija.ObrisiBateriju(imeb))
                                            Console.WriteLine("Uspesno obrisana baterija {0}", imeb);
                                        Console.WriteLine("Ne postoji baterija sa imenom {0}", imeb);
                                        break;

                                    case 4:
                                        Console.WriteLine("Unesite ime punjaca: ");
                                        string imepa = Console.ReadLine();
                                        if(ppunjac.ObrisiPunjac(imepa))
                                            Console.WriteLine("Uspeno obrisan punjac {0}", imepa);
                                        Console.WriteLine("Ne postoji punjac sa imenom {0}", imepa);
                                        break;
                                    default:
                                        Console.WriteLine("Unesite neki od ponudjenih brojeva");
                                        break;
                                }

                            }
                            while (obrisi != 5);
                            break;
                        case 7:
                            Console.WriteLine("Unesite broj za koliko puta zelite da ubrzate prolazak vremena: ");
                            int broj = int.Parse(Console.ReadLine());
                            psimulacija.UbrzajVreme(broj);
                            break;
                        case 8:
                            Console.WriteLine("Unesite procenat osuncanosti: ");
                            int procenat = int.Parse(Console.ReadLine());
                            psimulacija.PromeniOsuncanost(procenat);
                            break;
                    }


                }
                catch(FormatException ex)
                {
                    Console.WriteLine("Molimo vas da unesete neki od ponudjenih brojeva, dodatne informacije : " + ex.Message);
                }
            }
            while (komanda != 9);


        }


    }

}
