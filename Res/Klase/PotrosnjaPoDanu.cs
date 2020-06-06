using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Klase
{
    [Serializable]
    [XmlRoot("ArrayofPotrosnjaPoDanu")]
    public class PotrosnjaPoDanu
    {
        [XmlArray("ArrayofProizvodnja")]
        public List<double> ProizvodnjaSP { get; set; }
        [XmlArray("ArrayofEneBaterija")]
        public List<double> EnergijaIzBaterije { get; set; }
        [XmlArray("ArrayofUvoz")]
        public List<double> Uvoz { get; set; }
        [XmlArray("ArrayofPotrosnja")]
        public List<double> PotrosnjaPotrosaca { get; set; }

        public DateTime Datum { get; set; }


        public PotrosnjaPoDanu()
        {
            ProizvodnjaSP = new List<double>();
            EnergijaIzBaterije = new List<double>();
            Uvoz = new List<double>();
            PotrosnjaPotrosaca = new List<double>();
            Datum = DateTime.Now; //simulacija???
        }

    }
}
