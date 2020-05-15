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
    public interface IBaterija
    {
        [OperationContract]
        bool DodajBateriju(Baterija baterija);

        [OperationContract]
        bool ObrisiBateriju(string ime);

        [OperationContract]
        Baterija PronadjiBateriju(string ime);
    }
}
