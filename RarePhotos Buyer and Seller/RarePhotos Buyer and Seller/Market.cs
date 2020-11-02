using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RarePhotos_Buyer_and_Seller
{
    public class Market
    {
        public List<MarketPhoto> MarketPhotos { get; set; }
        public DataBaseProxy DataBaseProxy { get; set; }
        public Market(DataBaseProxy i_DataBaseProxy)
        {
            DataBaseProxy = i_DataBaseProxy;
            fetchListFromDataBase();
        }
        public void fetchListFromDataBase()
        {
            MarketPhotos = DataBaseProxy.GetMarketPhotos();
        }
    }
}
