using Contracts;
using Klase;
using SHES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Graf
{
    public partial class Form1 : Form
    {

        public static List<Potrosac> potrosaci = new List<Potrosac>();
        public static List<Baterija> baterije = new List<Baterija>();
        public static List<SolarniPanel> paneli = new List<SolarniPanel>();
        public static List<PunjacAutomobila> punjaci = new List<PunjacAutomobila>();
        public static double Potroseno;
        public static double Osuncanost;
        public static double EnergijaBaterija;
        //public static bool PromenaSata = true;
        public static int TrSati;

        private Thread thread;
        private double[] vrDistribucije = new double[24];
        private double[] vrPotrosaca = new double[24];
        private double[] vrPanela = new double[24];
        private double[] vrBaterija = new double[24];

        public static void Osvezi()
        {
            #region Connection
            NetTcpBinding binding = new NetTcpBinding();

            string addressBaterija = "net.tcp://localhost:8001/IBaterija";
            ChannelFactory<IBaterija> channelBaterija = new ChannelFactory<IBaterija>(binding, addressBaterija);
            IBaterija proxyBaterija = channelBaterija.CreateChannel();

            string addressPunjac = "net.tcp://localhost:8001/IPunjac";
            ChannelFactory<IPunjac> channelPunjac = new ChannelFactory<IPunjac>(binding, addressPunjac);
            IPunjac proxyPunjac = channelPunjac.CreateChannel();

            string addressPotrosac = "net.tcp://localhost:8001/IPotrosac";
            ChannelFactory<IPotrosac> channelPotrosac = new ChannelFactory<IPotrosac>(binding, addressPotrosac);
            IPotrosac proxyPotrosac = channelPotrosac.CreateChannel();

            string addressPanel = "net.tcp://localhost:8001/ISolarniPanel";
            ChannelFactory<ISolarniPanel> channelPanel = new ChannelFactory<ISolarniPanel>(binding, addressPanel);
            ISolarniPanel proxyPanel = channelPanel.CreateChannel();

            string addressSimulacija = "net.tcp://localhost:8001/ISimulacija";
            ChannelFactory<ISimulacija> channelSimulacija = new ChannelFactory<ISimulacija>(binding, addressSimulacija);
            ISimulacija proxySimulacija = channelSimulacija.CreateChannel();



            #endregion

            potrosaci = proxyPotrosac.VratiPotrosace();
            baterije = proxyBaterija.VratiBaterije();
            paneli = proxyPanel.VratiPanele();
            //punjaci = proxyPunjac.VratiPunjace();
            Potroseno = proxySimulacija.VratiKolicinu();
            EnergijaBaterija = proxySimulacija.VratiEnergijeBaterije();
            Osuncanost = proxySimulacija.VratiOsuncanost();
            TrSati = proxySimulacija.VratiSatnicu();
            //PromenaSata = proxySimulacija.ProveriSatnicu();
        }

        public Form1()
        {

            InitializeComponent();
        }


        public void ListajSate()
        {

            while (true)
            {

                //if (PromenaSata)
                {
                    Osvezi();

                    double potrosanjaPotrosaca = 0;
                    double proizvodnjaPanela = 0;

                    foreach (SolarniPanel sp in paneli)
                    {
                        proizvodnjaPanela += sp.KolicinaGenerisaneEnergije(Osuncanost);
                    }

                    foreach (Potrosac p in potrosaci)
                    {
                        if (p.Aktivan)
                            potrosanjaPotrosaca -= p.Potrosnja;
                    }

                    vrDistribucije[vrDistribucije.Length - 1] = Potroseno;
                    vrBaterija[vrBaterija.Length - 1] = EnergijaBaterija;
                    vrPanela[vrPanela.Length - 1] = proizvodnjaPanela;
                    vrPotrosaca[vrPotrosaca.Length - 1] = potrosanjaPotrosaca;

                    Array.Copy(vrDistribucije, 1, vrDistribucije, 0, vrDistribucije.Length - 1);
                    Array.Copy(vrBaterija, 1, vrBaterija, 0, vrBaterija.Length - 1);
                    Array.Copy(vrPanela, 1, vrPanela, 0, vrPanela.Length - 1);
                    Array.Copy(vrPotrosaca, 1, vrPotrosaca, 0, vrPotrosaca.Length - 1);

                }
                
                


                if (PotrosnjaChart.IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate { UpdatePotrosnjaChart(); });
                }
                else
                {

                }

                Thread.Sleep(1000);
            }


        }

        private void UpdatePotrosnjaChart()
        {
            PotrosnjaChart.Series["Distribucija"].Points.Clear();
            PotrosnjaChart.Series["Baterije"].Points.Clear();
            PotrosnjaChart.Series["Paneli"].Points.Clear();
            PotrosnjaChart.Series["Potrosaci"].Points.Clear();

            for(int i=0; i<vrPotrosaca.Length - 1; i++)
            {
                PotrosnjaChart.Series["Distribucija"].Points.AddY(vrDistribucije[i]);
                PotrosnjaChart.Series["Baterije"].Points.AddY(vrBaterija[i]);
                PotrosnjaChart.Series["Potrosaci"].Points.AddY(vrPotrosaca[i]);
                PotrosnjaChart.Series["Paneli"].Points.AddY(vrPanela[i]);
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            thread = new Thread(new ThreadStart(this.ListajSate));
            thread.IsBackground = true;
            thread.Start();
        }

        private void PotrosnjaChart_Click(object sender, EventArgs e)
        {

        }
    }
}
