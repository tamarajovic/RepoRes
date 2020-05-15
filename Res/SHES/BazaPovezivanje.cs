using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace SHES
{
    public class BazaPovezivanje
    {
        private String endpointName = "Input";

        public BazaPovezivanje()
        {
            string endPoint = String.Format("http://localhost:10100/{0}", endpointName);
        }

    }
}
