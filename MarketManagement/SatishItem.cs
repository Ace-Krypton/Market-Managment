using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement
{
    class SatishItem
    {
        public Product Product { get; set; }
        public int Count { get; set; }

        public SatishItem(Product product, int count)
        {
            Product = product;
            Count = count;
        }
    }
}
