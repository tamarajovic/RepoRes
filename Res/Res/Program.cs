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
            Elektrodistribucija ditribucija = new Elektrodistribucija(1000);


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

                    Console.WriteLine("1 --> Dodajte novi uredjaj");
                    Console.WriteLine("2 --> Ukljucite potrosaca");
                    Console.WriteLine("3 --> Iskljucite potrosaca");
                    Console.WriteLine("4 --> Promenite osvetljenost sunca");
                    Console.WriteLine("123 --> Izlaz iz sistema");

                    Console.WriteLine("Vas odgovor: ");
                    komanda = int.Parse(Console.ReadLine());

                    switch (komanda)
                    {
                        case 1:
                            MeniZaDodaju();
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


        public static void MeniZaDodaju()
        {



        }


    }

}
