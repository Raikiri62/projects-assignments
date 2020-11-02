using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RarePhotos_Buyer_and_Seller
{
    public class PhotosCollection
    {
        private User UserOwner;
        private CloudinaryProxy CloudinaryProxy;
        private DataBaseProxy DataBaseProxy;
        private List<CollectionPhotoSQL> SQLPhotos { get; set; }
        public List<Photo> ListOfPhotos { get; set; }
        public void InitializeCollection(User i_User, DataBaseProxy i_DataBaseProxy)
        {
            UserOwner = i_User;
            DataBaseProxy = i_DataBaseProxy;
            InitListOfPhotosFromProxies();
        }
        public void InitListOfPhotosFromProxies()
        {
            GetCollectionPhotosFromSQL();
            if(SQLPhotos != null && SQLPhotos.Count() > 0)
            {
                GetListOfPhotos();
            }
            else
            {
                ListOfPhotos = new List<Photo>(); // an empty list
            }
        }
        private void GetListOfPhotos()
        {
            ListOfPhotos = new List<Photo>();
            foreach (CollectionPhotoSQL SQLPhoto in SQLPhotos)
            {
                ListOfPhotos.Add(DataBaseProxy.GetPhoto(SQLPhoto.photoId));
            }
        }
        private void GetCollectionPhotosFromSQL()
        {
            SQLPhotos = DataBaseProxy.GetCollectionPhotos(UserOwner.ID);
        }
        public void deletePhoto(Photo i_Photo)
        {
            if(DataBaseProxy != null)
            {
                ListOfPhotos.Remove(i_Photo);
                DataBaseProxy.RemovePhoto(i_Photo);
            }
        }

    }
    public class CollectionPhotoSQL
    {
        public int userId { get; set; }
        public int photoId { get; set; }
    }
}
