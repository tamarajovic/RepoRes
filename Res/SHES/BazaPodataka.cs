using Contracts;
using Klase;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Serialization;
using System.IO;

namespace SHES
{
    public class BazaPodataka
    {
        static string PotrosaciPath = @"C:\Users\Nikola\source\repos\tamarajovic\RepoRes\Res\SHES\Baza\Potrosaci.xml";
        static string BaterijePath = @"C:\Users\Nikola\source\repos\tamarajovic\RepoRes\Res\SHES\Baza\Baterije.xml";
        static string PaneliPath = @"C:\Users\Nikola\source\repos\tamarajovic\RepoRes\Res\SHES\Baza\Paneli.xml";
        static string PunjaciPath = @"C:\Users\Nikola\source\repos\tamarajovic\RepoRes\Res\SHES\Baza\Punjaci.xml";
        static string DistribucijaPath = @"C:\Users\Nikola\source\repos\tamarajovic\RepoRes\Res\SHES\Baza\Distribucija.xml";


        public static List<Potrosac> potrosaci = new List<Potrosac>();
        public static List<Baterija> baterije = new List<Baterija>();
        public static List<SolarniPanel> paneli = new List<SolarniPanel>();
        public static List<PunjacAutomobila> punjaci = new List<PunjacAutomobila>();
        public static List<Elektrodistribucija> distribucija = new List<Elektrodistribucija>();

        public BazaPodataka()
        {

            if (File.Exists(PotrosaciPath))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Potrosac>));
                using(StreamReader sr = new StreamReader(PotrosaciPath))
                {
                    potrosaci = (List<Potrosac>)xmlSerializer.Deserialize(sr);
                }
                if(potrosaci.Count == 0)
                {
                    potrosaci.Add(new Potrosac("Frizider", 300));
                    potrosaci.Add(new Potrosac("Rerna", 200));
                    potrosaci.Add(new Potrosac("Klima", 150));
                    potrosaci.Add(new Potrosac("Ves masina", 140));
                    potrosaci.Add(new Potrosac("Toster", 20));
                }
            }
            if (File.Exists(BaterijePath))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Baterija>));
                using (StreamReader sr = new StreamReader(BaterijePath))
                {
                    baterije = (List<Baterija>)xmlSerializer.Deserialize(sr);
                }
                if(baterije.Count == 0)
                {
                    baterije.Add(new Baterija("b1", 500, 140));
                }
            }
            if (File.Exists(PaneliPath))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<SolarniPanel>));
                using (StreamReader sr = new StreamReader(PaneliPath))
                {
                    paneli = (List<SolarniPanel>)xmlSerializer.Deserialize(sr);
                }
                if(paneli.Count == 0)
                {
                    paneli.Add(new SolarniPanel("p1", 300));
                }
            }
            if (File.Exists(PunjaciPath))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<PunjacAutomobila>));
                using (StreamReader sr = new StreamReader(PunjaciPath))
                {
                    punjaci = (List<PunjacAutomobila>)xmlSerializer.Deserialize(sr);
                }
                if(punjaci.Count == 0)
                {
                    punjaci.Add(new PunjacAutomobila("pa1", 100, 50, 400));
                }
            }
            if (File.Exists(DistribucijaPath))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Elektrodistribucija>));
                using (StreamReader sr = new StreamReader(DistribucijaPath))
                {
                    distribucija = (List<Elektrodistribucija>)xmlSerializer.Deserialize(sr);
                }
                if(distribucija.Count == 0)
                {
                    distribucija.Add(new Elektrodistribucija(500));
                }
            }



        }

        static public void Run()
        {
            new Thread(() =>
            {
                while (true)
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Potrosac>));
                    using(StreamWriter sw = new StreamWriter(PotrosaciPath))
                    {
                        xmlSerializer.Serialize(sw, potrosaci);
                    }
                    Thread.Sleep(5000);
                }



            }).Start();
        }

       
    }
}
