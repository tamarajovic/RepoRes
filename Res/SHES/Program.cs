using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SHES
{
    class Program
    {
        static void Main(string[] args)
        {

            #region connection
            NetTcpBinding binding = new NetTcpBinding();

            ServiceHost hostBaterija = new ServiceHost(typeof(BaterijaProvider));
            string addressBaterija = "net.tcp://localhost:8000/IBaterija";
            hostBaterija.AddServiceEndpoint(typeof(IBaterija), binding, addressBaterija);
            hostBaterija.Open();

            ServiceHost hostPunjac = new ServiceHost(typeof(PunjacProvider));
            string addressPunjac = "net.tcp://localhost:8000/IPunjac";
            hostPunjac.AddServiceEndpoint(typeof(IPunjac), binding, addressPunjac);
            hostPunjac.Open();

            ServiceHost hostPanel = new ServiceHost(typeof(SolarniPanelProvider));
            string addressPanel = "net.tcp://localhost:8000/ISolarnmiPanel";
            hostPanel.AddServiceEndpoint(typeof(ISolarniPanel), binding, addressPanel);
            hostPanel.Open();

            ServiceHost hostPotrosac = new ServiceHost(typeof(PotrosacProvider));
            string addressPotrosac = "net.tcp://localhost:8000/IPotrosac";
            hostPotrosac.AddServiceEndpoint(typeof(IPotrosac), binding, addressPotrosac);
            hostPotrosac.Open();

            ServiceHost hostSimulacija = new ServiceHost(typeof(Simulacija));
            string addressSimulacija= "net.tcp://localhost:8000/ISimulacija";
            hostSimulacija.AddServiceEndpoint(typeof(ISimulacija), binding, addressSimulacija);
            hostSimulacija.Open();


            //drugi deo
            NetTcpBinding binding1 = new NetTcpBinding();

            ServiceHost hostBaterija1 = new ServiceHost(typeof(BaterijaProvider));
            string addressBaterija1 = "net.tcp://localhost:8001/IBaterija";
            hostBaterija1.AddServiceEndpoint(typeof(IBaterija), binding1, addressBaterija1);
            hostBaterija1.Open();

            ServiceHost hostPunjac1 = new ServiceHost(typeof(PunjacProvider));
            string addressPunjac1 = "net.tcp://localhost:8001/IPunjac";
            hostPunjac1.AddServiceEndpoint(typeof(IPunjac), binding1, addressPunjac1);
            hostPunjac1.Open();

            ServiceHost hostPanel1 = new ServiceHost(typeof(SolarniPanelProvider));
            string addressPanel1 = "net.tcp://localhost:8001/ISolarniPanel";
            hostPanel1.AddServiceEndpoint(typeof(ISolarniPanel), binding1, addressPanel1);
            hostPanel1.Open();

            ServiceHost hostPotrosac1 = new ServiceHost(typeof(PotrosacProvider));
            string addressPotrosac1 = "net.tcp://localhost:8001/IPotrosac";
            hostPotrosac1.AddServiceEndpoint(typeof(IPotrosac), binding1, addressPotrosac1);
            hostPotrosac1.Open();

            ServiceHost hostSimulacija1 = new ServiceHost(typeof(Simulacija));
            string addressSimulacija1 = "net.tcp://localhost:8001/ISimulacija";
            hostSimulacija1.AddServiceEndpoint(typeof(ISimulacija), binding1, addressSimulacija1);
            hostSimulacija1.Open();

            #endregion

            BazaPodataka b = new BazaPodataka();
            BazaPodataka.Run();

            Console.WriteLine("servis pokrenut");

            Simulacija s = new Simulacija();
            s.Simuliraj();

            Console.ReadKey();
            hostPunjac.Close();
            hostBaterija.Close();
            hostPanel.Close();
            hostPotrosac.Close();
        }

    }
}
