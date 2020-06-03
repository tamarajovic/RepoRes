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

        private Thread thread;
        private double[] vrPotrosaca = new double[24];


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
        }

        public Form1()
        {

            InitializeComponent();
        }


        public void ListajSate()
        {
            Osvezi();

            while (true)
            {

                double potrosanjaPotrosaca = 0;

                //foreach (Potrosac p in potrosaci)
                //{
                //    potrosanjaPotrosaca += p.Potrosnja;
                //}
                
                foreach (Baterija p in baterije)
                {
                    potrosanjaPotrosaca += p.TrKapacitet;
                }


                vrPotrosaca[vrPotrosaca.Length - 1] = potrosanjaPotrosaca;

                Array.Copy(vrPotrosaca, 1, vrPotrosaca, 0, vrPotrosaca.Length - 1);

                if (PotrosnjaChart.IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate { UpdatePotrosnjaChart(); });
                }
                else
                {

                }


            }


        }

        private void UpdatePotrosnjaChart()
        {
            PotrosnjaChart.Series["Potrosaci"].Points.Clear();

            for(int i=0; i<vrPotrosaca.Length - 1; i++)
            {
                PotrosnjaChart.Series["Potrosaci"].Points.AddY(vrPotrosaca[i]);

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
