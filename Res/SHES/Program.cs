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
            #endregion
            
            Console.WriteLine("servis pokrenut");

            BazaPodataka b = new BazaPodataka();
            BazaPodataka.Run();

            Console.ReadKey();
            hostPunjac.Close();
            hostBaterija.Close();
            hostPanel.Close();
            hostPotrosac.Close();
        }

    }
}
