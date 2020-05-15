using Klase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Res
{

    class Program
    {

        static void Main(string[] args)
        {
            

            
            Meni();
            
            

        }

        public static void Meni()
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
                    Console.WriteLine("123 --> Izlaz iz sistema");

                    Console.WriteLine("Vas odgovor: ");
                    komanda = int.Parse(Console.ReadLine());

                    switch (komanda)
                    {
                        case 1:
                            int dodajNovi;
                            Console.WriteLine("Odaberite sta zelite da dodate");
                            Console.WriteLine("1 --> Potrosac");
                            Console.WriteLine("2 --> Solarni Panel");
                            Console.WriteLine("3 --> Baterija");
                            Console.WriteLine("4 --> Punjac za automobil");
                            Console.WriteLine("Vas odgovor: ");
                            dodajNovi = int.Parse(Console.ReadLine());

                            switch (dodajNovi)
                            {
                                case 1:

                                    break;





                            }

                            break;
                        case 2:
                            
                            break;
                    }


                }
                catch(FormatException ex)
                {
                    Console.WriteLine("Molimo vas da unesete neki od ponudjenih brojeva, dodatne informacije : " + ex.Message);
                }
            }
            while (true);


        }


    }

}
