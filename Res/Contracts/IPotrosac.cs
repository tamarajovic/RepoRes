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
    public interface IPotrosac
    {
        [OperationContract]
        List<Potrosac> VratiPotrosace();

        [OperationContract]
        bool DodajPotrosaca(Potrosac p);

        [OperationContract]
        bool ObrisiPotrosaca(string ime);

        [OperationContract]
        Potrosac PronadjiPotrosaca(string ime);

        [OperationContract]
        void Ukljuci(string ime);

        [OperationContract]
        void Iskljuci(string ime);

    }
}
