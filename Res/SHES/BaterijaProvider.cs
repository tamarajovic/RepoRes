﻿using Contracts;
using Klase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHES
{
    public class BaterijaProvider : IBaterija
    {
        public bool DodajBateriju(Baterija baterija)
        {
            if (BazaPodataka.baterije.Contains(baterija))
                return false;
            else
            {
                BazaPodataka.baterije.Add(baterija);
                return true;
            }
        }

        public bool ObrisiBateriju(string ime)
        {
            Baterija b = PronadjiBateriju(ime);
            if (b != null)
            {
                BazaPodataka.baterije.Remove(b);
                return true;
            }
            else
                return false;
        }

        public Baterija PronadjiBateriju(string ime)
        {
            foreach (var b in BazaPodataka.baterije)
            {
                if (b.Ime.ToLower().Equals(ime.ToLower()))
                {
                    return b;
                }
            }
            return null;
        }

        public List<Baterija> VratiBaterije()
        {
            return BazaPodataka.baterije;
        }
    }
}
