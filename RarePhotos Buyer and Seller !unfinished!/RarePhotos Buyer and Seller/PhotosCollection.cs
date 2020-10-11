using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RarePhotos_Buyer_and_Seller
{
    public class PhotosCollection
    {
        public User User { get; }
        public CloudinaryProxy CloudinaryProxy { get; }
        public DataBaseProxy DataBaseProxy { get; }
        public List<Photo> ListOfPhotos { get; set; }
        public PhotosCollection(User i_User, CloudinaryProxy i_CloudinaryProxy, DataBaseProxy i_DataBaseProxy)
        {
            // checking that they are not null!!
            User = i_User;
            CloudinaryProxy = i_CloudinaryProxy;
            DataBaseProxy = i_DataBaseProxy;
            InitListOfPhotosFromProxies();
        }
        public void InitListOfPhotosFromProxies()
        {
            ListOfPhotos = new List<Photo>();
            // accessing database & cloudinary:
        }
    }
}
