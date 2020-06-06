using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grafik
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            NetTcpBinding binding = new NetTcpBinding();

            ServiceHost hostGrafik = new ServiceHost(typeof(Form1));
            string addressgrafik = "net.tcp://localhost:8002/IGrafik";
            hostGrafik.AddServiceEndpoint(typeof(IGrafik), binding, addressgrafik);
            hostGrafik.Open();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
