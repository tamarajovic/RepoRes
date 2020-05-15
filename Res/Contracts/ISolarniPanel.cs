using Klase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    [ServiceContract]
    public interface ISolarniPanel
    {
        [OperationContract]
        bool DodajPanel(SolarniPanel s);

        [OperationContract]
        bool ObrisiPanel(string ime);

        [OperationContract]
        SolarniPanel PronadjiPanel(string ime);

    }
}
