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
            int GodinaBroj = int.Parse(Godina);
            int DanBroj = int.Parse(Dan);
            int MesecBroj = int.Parse(Mesec);
            DanBroj += countDana;
            //if (MesecBroj == 1 && DanBroj > 31)
            //{
            //    MesecBroj = 2;
            //    DanBroj = 1;
            //}
            //else if (MesecBroj == 2 && GodinaBroj % 4 == 0 && DanBroj > 29)
            //{
            //    MesecBroj = 3;
            //    DanBroj = 1;
            //}
            //else if (MesecBroj == 2 && GodinaBroj % 4 != 0 && DanBroj > 28)
            //{
            //    MesecBroj = 3;
            //    DanBroj = 1;
            //}
            //else if (MesecBroj == 3 && DanBroj > 31)
            //{
            //    MesecBroj = 4;
            //    DanBroj = 1;
            //}
            //else if (MesecBroj == 4 && DanBroj > 30)
            //{
            //    MesecBroj = 5;
            //    DanBroj = 1;
            //}
            //else if (MesecBroj == 5 && DanBroj > 31)
            //{
            //    MesecBroj = 6;
            //    DanBroj = 1;
            //}
            //else if (MesecBroj == 6 && DanBroj > 30)
            //{
            //    MesecBroj = 7;
            //    DanBroj = 1;
            //}
            //else if(MesecBroj == 7 && DanBroj > 31)
            //{
            //    MesecBroj = 8;
            //    DanBroj = 1;
            //}
            //else if (MesecBroj == 8 && DanBroj > 31)
            //{
            //    MesecBroj = 9;
            //    DanBroj = 1;
            //}
            //else if (MesecBroj == 9 && DanBroj > 30)
            //{
            //    MesecBroj = 10;
            //    DanBroj = 1;
            //}
            //else if (MesecBroj == 10 && DanBroj > 31)
            //{
            //    MesecBroj = 11;
            //    DanBroj = 1;
            //}
            //else if (MesecBroj == 11 && DanBroj > 30)
            //{
            //    MesecBroj = 12;
            //    DanBroj = 1;
            //}
            //else if (MesecBroj == 12 && DanBroj > 31)
            //{
            //    MesecBroj = 1;
            //    DanBroj = 1;
            //    GodinaBroj++;
            //}
           
            countDana++;
            Datum = Dan.ToString() + '/' + Mesec.ToString() + '/' + Godina.ToString();
        }



    }
}
