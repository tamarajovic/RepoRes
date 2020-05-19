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
        void PromeniOsuncanost(double procenat);
        [OperationContract]
        void UbrzajVreme(int brojac);
    }
}
