using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement
{
    class Satish
    {
        public DateTime Tarix { get; set; }
        public double Mebleg { get; set; }
        
        public List<SatishItem> siyahi = new List<SatishItem>();

        private static int _id;
        public readonly int ID;

        public Satish()
        {
            ID = ++_id;
            Mebleg = 0;
        }

        public override string ToString()
        {
            return $"Satish Nomresi: {ID} | Tarix: {Tarix.ToString("MM/dd/yyyy")} | Mehsul sayi: {siyahi.Count} | Yekun Mebleg: {Mebleg}";
        }
    }
}
