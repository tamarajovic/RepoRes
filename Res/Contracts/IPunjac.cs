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
    public interface IPunjac
    {
        [OperationContract]
        List<PunjacAutomobila> VratiPunjace();

        [OperationContract]
        bool DodajPunjac(PunjacAutomobila punjac);

        [OperationContract]
        bool ObrisiPunjac(string ime);

        [OperationContract]
        PunjacAutomobila PronadjiPunjac(string ime);

        [OperationContract]
        void Ukljuci(string ime, int maksKolicina, int kolicina);

        [OperationContract]
        void Iskljuci(string ime);
    }
}
