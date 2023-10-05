using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA23100505
{
    class Repulogep
    {
        public string Tipus { get; set; }
        public int Ev { get; set; }
        public (int Min, int Max) Utas { get; set; }
        public (int Min, int Max) Szemelyzet { get; set; }
        public int UtazoSebesseg { get; set; }
        public int FelszalloTomeg { get; set; }
        public float Fesztav { get; set; }

        public string SebessegKategoria
        {
            get
            {
                if (UtazoSebesseg < 500) return KategoriaNevek[0];
                else if (UtazoSebesseg < 1000) return KategoriaNevek[1];
                else if (UtazoSebesseg < 1200) return KategoriaNevek[2];
                else return KategoriaNevek[3];
            }
        }

        public static string[] KategoriaNevek = { 
            "Alacsony sebességű",
            "Szubszonikus",
            "Transzszonikus",
            "Szuperszonikus"
        };

        private static (int, int) MinMaxStringConvert(string str)
        {
            if (str.Contains('-'))
            {
                var splts = str.Split('-');
                return (int.Parse(splts[0]), int.Parse(splts[1]));
            }
            else return (int.Parse(str), int.Parse(str));
        }

        public Repulogep(string sor)
        {
            var v = sor.Split(';');
            Tipus = v[0];
            Ev = int.Parse(v[1]);
            Utas = MinMaxStringConvert(v[2]);
            Szemelyzet = MinMaxStringConvert(v[3]);
            UtazoSebesseg = int.Parse(v[4]);
            FelszalloTomeg = int.Parse(v[5]);
            Fesztav = float.Parse(v[6]);
        }
    }
}
