using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RarePhotos_Buyer_and_Seller
{
    public class MarketPhoto
    {
        public int userId { get; set; }
        public int photoId { get; set; }
        public int price { get; set; }
        public string description { get; set; }
        public string Date { get; set; }
    }
}
