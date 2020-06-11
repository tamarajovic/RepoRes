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
using System.Web.Hosting;
using System.Xml;

namespace SHES
{
    public class BazaPodataka
    {
        static string PotrosaciPath = @"C:\Users\User\Source\Repos\RepoRes\Res\SHES\Baza\Potrosaci.xml";
        static string BaterijePath = @"C:\Users\User\Source\Repos\RepoRes\Res\SHES\Baza\Baterije.xml";
        static string PaneliPath = @"C:\Users\User\Source\Repos\RepoRes\Res\SHES\Baza\Paneli.xml";
        static string PunjaciPath = @"C:\Users\User\Source\Repos\RepoRes\Res\SHES\Baza\Punjaci.xml";
        static string DistribucijaPath = @"C:\Users\User\Source\Repos\RepoRes\Res\SHES\Baza\Distribucija.xml";
        static string IstorijaPotrosnjePath = @"C:\Users\User\Source\Repos\RepoRes\Res\SHES\Baza\IstorijaPotrosnje.xml";

        //daje null, mozda nisam dobar path stavila???
        //static string PotrosaciPath = HostingEnvironment.MapPath("~/Baza/Potrosaci.xml");
        //static string BaterijePath = HostingEnvironment.MapPath("~/Baza/Baterije.xml");
        //static string PaneliPath = HostingEnvironment.MapPath("~/Baza/Paneli.xml");
        //static string PunjaciPath = HostingEnvironment.MapPath("~/Baza/Punjaci.xml");
        //static string DistribucijaPath = HostingEnvironment.MapPath("~/Baza/Distribucija.xml");

        //static string PotrosaciPath = @"C:\Users\Nikola\source\repos\tamarajovic\RepoRes\Res\SHES\Baza\Potrosaci.xml";
        //static string BaterijePath = @"C:\Users\Nikola\source\repos\tamarajovic\RepoRes\Res\SHES\Baza\Baterije.xml";
        //static string PaneliPath = @"C:\Users\Nikola\source\repos\tamarajovic\RepoRes\Res\SHES\Baza\Paneli.xml";
        //static string PunjaciPath = @"C:\Users\Nikola\source\repos\tamarajovic\RepoRes\Res\SHES\Baza\Punjaci.xml";
        //static string DistribucijaPath = @"C:\Users\Nikola\source\repos\tamarajovic\RepoRes\Res\SHES\Baza\Distribucija.xml";
        //static string IstorijaPotrosnjePath = @"C:\Users\Nikola\source\repos\tamarajovic\RepoRes\Res\SHES\Baza\IstorijaPotrosnje.xml";

        public static List<Potrosac> potrosaci = new List<Potrosac>();
        public static List<Baterija> baterije = new List<Baterija>();
        public static List<SolarniPanel> paneli = new List<SolarniPanel>();
        public static List<PunjacAutomobila> punjaci = new List<PunjacAutomobila>();
        public static List<Elektrodistribucija> distribucija = new List<Elektrodistribucija>();
        public static List<PotrosnjaPoDanu> istorijaPotrosnje = new List<PotrosnjaPoDanu>();

        public List<Potrosac> potrosaciZaTest = new List<Potrosac>();
        public List<Baterija> baterijeZaTest = new List<Baterija>();
        public List<SolarniPanel> paneliZaTest = new List<SolarniPanel>();
        public List<PunjacAutomobila> punjaciZaTest = new List<PunjacAutomobila>();
        public List<Elektrodistribucija> distribucijaZaTest = new List<Elektrodistribucija>();
        public List<PotrosnjaPoDanu> istorijaPotrosnjeZaTest = new List<PotrosnjaPoDanu>();

        public BazaPodataka()
        {
            XmlDocument doc1 = new XmlDocument();
            doc1.Load(IstorijaPotrosnjePath);
            doc1.DocumentElement.RemoveAll();
            doc1.Save(IstorijaPotrosnjePath);

            XmlDocument doc2 = new XmlDocument();
            doc2.Load(BaterijePath);
            doc2.DocumentElement.RemoveAll();
            doc2.Save(BaterijePath);

            XmlDocument doc3 = new XmlDocument();
            doc3.Load(PotrosaciPath);
            doc3.DocumentElement.RemoveAll();
            doc3.Save(PotrosaciPath);

            XmlDocument doc4 = new XmlDocument();
            doc4.Load(PaneliPath);
            doc4.DocumentElement.RemoveAll();
            doc4.Save(PaneliPath);

            XmlDocument doc5 = new XmlDocument();
            doc5.Load(PunjaciPath);
            doc5.DocumentElement.RemoveAll();
            doc5.Save(PunjaciPath);

            if (File.Exists(PotrosaciPath))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Potrosac>));
                using(StreamReader sr = new StreamReader(PotrosaciPath))
                {
                    potrosaci = (List<Potrosac>)xmlSerializer.Deserialize(sr);
                }
                if(potrosaci.Count == 0)
                {
                    potrosaci.Add(new Potrosac("Frizider", 0.3));
                    potrosaci.Add(new Potrosac("Rerna", 2));
                    potrosaci.Add(new Potrosac("Klima", 1));
                    potrosaci.Add(new Potrosac("Ves masina", 1.5));
                    potrosaci.Add(new Potrosac("Toster", 0.01));
                    potrosaci.Add(new Potrosac("Bojler", 2));
                    potrosaci.Add(new Potrosac("Osvetljenje", 1.5));
                    potrosaci.Add(new Potrosac("Pegla", 1.8));
                    potrosaci.Add(new Potrosac("Televizija", 0.08));
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
                    baterije.Add(new Baterija("b1", 1, 5));
                    baterije.Add(new Baterija("b2", 2, 6));
                    baterije.Add(new Baterija("b3", 0.5, 4));
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
                    paneli.Add(new SolarniPanel("p1", 3));
                    paneli.Add(new SolarniPanel("p2", 2));
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
                    punjaci.Add(new PunjacAutomobila("pa1", 2, 30, 8));
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
                    distribucija.Add(new Elektrodistribucija(5));
                }
            }

            //if (File.Exists(IstorijaPotrosnjePath))
            //{
            //    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<PotrosnjaPoDanu>));
            //    using (StreamWriter sw = new StreamWriter(IstorijaPotrosnjePath))
            //    {
            //        xmlSerializer.Serialize(sw, )
            //    }
            //}

        }

        static public void Run()
        {
            new Thread(() =>
            {
                while (true)
                {

                    XmlSerializer xmlSerializerPotrosac = new XmlSerializer(typeof(List<Potrosac>));
                    using (StreamWriter sw = new StreamWriter(PotrosaciPath))
                    {
                        xmlSerializerPotrosac.Serialize(sw, potrosaci);
                    }


                    XmlSerializer xmlSerializerBaterija = new XmlSerializer(typeof(List<Baterija>));
                    using (StreamWriter sw = new StreamWriter(BaterijePath))
                    {
                        xmlSerializerBaterija.Serialize(sw, baterije);
                    }

                    XmlSerializer xmlSerializerPaneli = new XmlSerializer(typeof(List<SolarniPanel>));
                    using (StreamWriter sw = new StreamWriter(PaneliPath))
                    {
                        xmlSerializerPaneli.Serialize(sw, paneli);
                    }

                    XmlSerializer xmlSerializerPunjac = new XmlSerializer(typeof(List<PunjacAutomobila>));
                    using (StreamWriter sw = new StreamWriter(PunjaciPath))
                    {
                        xmlSerializerPunjac.Serialize(sw, punjaci);
                    }

                    XmlSerializer xmlSerializerDistribucija = new XmlSerializer(typeof(List<Elektrodistribucija>));
                    using (StreamWriter sw = new StreamWriter(DistribucijaPath))
                    {
                        xmlSerializerDistribucija.Serialize(sw, distribucija);
                    }
                    Thread.Sleep(1000);

                }
                
                



            }).Start();
        }


        public static void UpisiPotrosnju()
        {
            XmlSerializer xmlSerializerPotrosac = new XmlSerializer(typeof(List<PotrosnjaPoDanu>));
            using (StreamWriter sw = new StreamWriter(IstorijaPotrosnjePath))
            {
                xmlSerializerPotrosac.Serialize(sw, istorijaPotrosnje);
            }
        }

    }
}
