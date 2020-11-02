using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RarePhotos_Buyer_and_Seller
{
    public partial class PhotosCollectionForm : Form
    {
        public User LogggedInUser { get; set; }
        public DataBaseProxy DataBaseProxy { get; set; }
        private int SelectedPhotoID { get; set; }
        public PhotosCollectionForm(User i_LogggedInUser,DataBaseProxy i_DataBaseProxy)
        {
            InitializeComponent();
            LogggedInUser = i_LogggedInUser;
            DataBaseProxy = i_DataBaseProxy;
            InitPhotosCollection();
            performDownloads();
        }

        private void performDownloads()
        {
            foreach (Photo photo in LogggedInUser.PhotosCollection.ListOfPhotos)
            {
                using (WebClient wc = new WebClient())
                {
                    using (Stream s = wc.OpenRead(photo.URL))
                    {
                        var bitmap = new Bitmap(s);
                        //using (m_BitmapPhoto = new Bitmap(s))
                        //{
                        bitmap.Save(photo.photoId + ".jpg");
                        //}
                    }
                }
            }
        }

        public void InsertPhotosToImageListView()
        {
            foreach(Photo photo in LogggedInUser.PhotosCollection.ListOfPhotos)
            {
                var imageListViewItem = new Manina.Windows.Forms.ImageListViewItem();
                imageListViewItem.FileName = photo.photoId + ".jpg"; // we assume that the file has been downloaded, with that name.
                imageListViewItem.Tag = photo.photoId;
                imageListViewItem.Text = photo.photoTag;
                imageListView1.Items.Add(imageListViewItem);
            }
        }

        private void InitPhotosCollection()
        {
            LogggedInUser.InitPhotosCollection(DataBaseProxy);
        }

        private void imageListView1_ItemClick(object sender, Manina.Windows.Forms.ItemClickEventArgs e)
        {
            //var str = imageListView1.SelectedItems[0].FileName;
            SelectedPhotoID = (int)imageListView1.SelectedItems[0].Tag;
            labelPhotoID.Text = SelectedPhotoID.ToString();
            panel1.Visible = true;
        }

        private void PhotosCollectionForm_Load(object sender, EventArgs e)
        {
            InsertPhotosToImageListView();
            panel1.Visible = false;
        }

        private void PhotosCollectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
        }

        private void buttonSell_Click(object sender, EventArgs e)
        {
            int price;
            bool boolResult = int.TryParse(textBoxPrice.Text,out price);
            if(imageListView1.SelectedItems[0] != null && boolResult)
            {
                Photo selectedPhotoForSell = LogggedInUser.PhotosCollection.ListOfPhotos.Find(x => x.photoId == (int)imageListView1.SelectedItems[0].Tag);
                MarketPhoto marketPhoto = new MarketPhoto() {userId = LogggedInUser.ID,photoId = selectedPhotoForSell.photoId,price = price,description = textBoxDescription.Text,Date = DateTime.Now.ToString() };
                DataBaseProxy.InsertNewMarketPhoto(marketPhoto);
                LogggedInUser.PhotosCollection.deletePhoto(selectedPhotoForSell);
                imageListView1.Items.Remove(imageListView1.SelectedItems[0]);
                UpdaterChecker.IsMarketDataHasChanged = true;
            }
            panel1.Visible = false;
            textBoxPrice.Clear();
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void buttonDeletePhoto_Click(object sender, EventArgs e)
        {
            if (imageListView1.SelectedItems[0] != null)
            {
                Photo selectedPhotoForSell = LogggedInUser.PhotosCollection.ListOfPhotos.Find(x => x.photoId == (int)imageListView1.SelectedItems[0].Tag);
                LogggedInUser.PhotosCollection.deletePhoto(selectedPhotoForSell);
                imageListView1.Items.Remove(imageListView1.SelectedItems[0]);
            }
            panel1.Visible = false;
            textBoxPrice.Clear();
        }
    }
}
