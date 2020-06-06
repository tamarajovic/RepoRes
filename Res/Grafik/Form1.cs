using Contracts;
using Klase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Grafik
{
    public partial class Form1 : Form , IGrafik
    {

        static string PotrosnjaPoDanuPath = @"C:\Users\Nikola\source\repos\tamarajovic\RepoRes\Res\SHES\Baza\IstorijaPotrosnje.xml";
        public static int RedniDan = 0;
        public static List<PotrosnjaPoDanu> potrosnje = new List<PotrosnjaPoDanu>();

        public bool Tacno = false;

        public static void Osvezi()
        {
            if (File.Exists(PotrosnjaPoDanuPath))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<PotrosnjaPoDanu>));
                using (StreamReader sr = new StreamReader(PotrosnjaPoDanuPath))
                {
                    potrosnje = (List<PotrosnjaPoDanu>)xmlSerializer.Deserialize(sr);
                }
            }
        }

        public void IspisiGraf (string ZeljeniDan)
        {
            Osvezi();
            int count = 0;
            foreach(PotrosnjaPoDanu dan in potrosnje)
            {

                if(dan.Datum == ZeljeniDan)
                {
                    RedniDan = count;

                    break;
                }
                count++;
            }
        }

        private void UpdateChart()
        {



            for (int i = 0; i < 24; i++)
            {
                chart1.Series["potrosaci"].Points.AddXY(i, potrosnje[RedniDan].PotrosnjaPotrosaca[i]);
                chart1.Series["paneli"].Points.AddXY(i, potrosnje[RedniDan].ProizvodnjaSP[i]);
                chart1.Series["distribucija"].Points.AddXY(i, potrosnje[RedniDan].Uvoz[i]);
                chart1.Series["baterije"].Points.AddXY(i, potrosnje[RedniDan].EnergijaIzBaterije[i]);
            }
        }

        public void ProslediDatum(string Datum)
        {
            IspisiGraf(Datum);
        }



        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateChart();
        }
    }
}
