using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RarePhotos_Buyer_and_Seller
{
    public class Photo
    {
        public double ID { get; set; }
        public string Tag { get; set; }
        public User Owner { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string Date { get; set; }
    }
}
