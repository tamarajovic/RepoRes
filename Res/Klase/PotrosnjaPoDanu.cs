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
        public static int countDana = 0;

        [XmlArray("ArrayofProizvodnja")]
        public List<double> ProizvodnjaSP { get; set; }
        [XmlArray("ArrayofEneBaterija")]
        public List<double> EnergijaIzBaterije { get; set; }
        [XmlArray("ArrayofUvoz")]
        public List<double> Uvoz { get; set; }
        [XmlArray("ArrayofPotrosnja")]
        public List<double> PotrosnjaPotrosaca { get; set; }
        public string Datum { get; set; }

        public PotrosnjaPoDanu()
        {
            
            ProizvodnjaSP = new List<double>();
            EnergijaIzBaterije = new List<double>();
            Uvoz = new List<double>();
            PotrosnjaPotrosaca = new List<double>();
            string vremeSad = DateTime.Now.ToString();
            string[] tokeni = vremeSad.Split('/');
            string Mesec = tokeni[0];
            string Dan = tokeni[1];
            string Godina = tokeni[2].Split(' ')[0];
            int DanBroj = int.Parse(Dan);
            DanBroj += countDana;
            countDana++;
            Dan = DanBroj.ToString();
            Datum = Dan + '/' + Mesec + '/' + Godina;
        }



    }
}
