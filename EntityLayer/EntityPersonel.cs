using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class EntityPersonel
    {
        private int personelid;
        private string personelad;
        private string personelsoyad;
        private string sehir;
        private string gorev;
        private int maas;

        public int Personelid { get => personelid; set => personelid = value; }
        public string Personelad { get => personelad; set => personelad = value; }
        public string Personelsoyad { get => personelsoyad; set => personelsoyad = value; }
        public string Sehir { get => sehir; set => sehir = value; }
        public string Gorev { get => gorev; set => gorev = value; }
        public int Maas { get => maas; set => maas = value; }
    }
}
