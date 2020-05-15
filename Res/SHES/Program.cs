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

            ServiceHost hostB = new ServiceHost(typeof(BaterijaProvider));
            string addressB = "net.tcp://localhost:8000/IBaterija";
            hostB.AddServiceEndpoint(typeof(IBaterija), binding, addressB);
            hostB.Open();

            ServiceHost hostP = new ServiceHost(typeof(PunjacProvider));
            string addressP = "net.tcp://localhost:8000/IPunjac";
            hostP.AddServiceEndpoint(typeof(IPunjac), binding, addressP);
            hostP.Open();
            #endregion

            Console.WriteLine("servis pokrenut");
            Console.ReadKey();
            hostP.Close();
            hostB.Close();
        }

    }
}
