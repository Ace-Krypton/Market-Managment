using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement
{
    public enum Category { Shirniyyat = 1, Meyve_Terevez, Ichki, Et, Meishet };

    class Product
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public Category Category { get; set; }

        public override string ToString()
        {
            return $"Kod: {Code} | Ad: {Name} | Qiymet: {Price} | Say: {Count} | Kateqoriya: {Category}";
        }
    }
}
