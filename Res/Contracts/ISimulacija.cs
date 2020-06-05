using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    [ServiceContract]
    public interface ISimulacija
    {
        [OperationContract]
        void PromeniOsuncanost(int procenat);

        [OperationContract]
        void UbrzajVreme(int brojac);

        [OperationContract]
        double VratiKolicinu();

        [OperationContract]
        double VratiOsuncanost();

        [OperationContract]
        double VratiEnergijeBaterije();

        [OperationContract]
        bool ProveriSatnicu();

        [OperationContract]
        int VratiSatnicu();
    }
}
