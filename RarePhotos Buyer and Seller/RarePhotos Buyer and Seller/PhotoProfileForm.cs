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
    public partial class PhotoProfileForm : Form
    {
        public MarketPhoto MarketPhoto { get; set; }
        public Photo Photo { get; set; }
        public List<User> Users { get; set; }
        public User LoggedInUser { get; set; }
        public User UserSeller { get; set; }
        public string FilePath { get; set; }
        public DataBaseProxy DataBaseProxy { get; set; }
        public Bitmap m_BitmapPhoto;
        public PhotoProfileForm(DataBaseProxy i_DataBaseProxy)
        {
            InitializeComponent();
            DataBaseProxy = i_DataBaseProxy;
        }
        public void InitForm(MarketPhoto i_MarketPhoto , List<User> i_Users,User i_LoggedInUser)
        {
            Users = i_Users;
            LoggedInUser = i_LoggedInUser;
            MarketPhoto = i_MarketPhoto;
            Photo = DataBaseProxy.GetPhoto(MarketPhoto.photoId);
            UserSeller = Users.Find(x => x.ID == MarketPhoto.userId);

            if (Photo != null)
            {
                if (!File.Exists(Photo.photoId + ".jpg"))
                {
                    downloadPhoto(Photo.URL);
                }
                else // this file is exist.
                {
                    m_BitmapPhoto = new Bitmap(Photo.photoId + ".jpg");
                }
                displayPhoto();
                displayData();
            }
        }
        public void downloadPhoto(string i_URL)
        {
            using (WebClient wc = new WebClient())
            {
                using (Stream s = wc.OpenRead(i_URL))
                {
                    m_BitmapPhoto = new Bitmap(s);
                    m_BitmapPhoto.Save(Photo.photoId + ".jpg");
                }
            }
        }
        public void displayPhoto()
        {
            if(m_BitmapPhoto != null)
            {
                pictureBoxPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                int height = (400 * m_BitmapPhoto.Height) / m_BitmapPhoto.Width;
                pictureBoxPhoto.ClientSize = new Size(400, height);
                pictureBoxPhoto.Image = (Image)m_BitmapPhoto;
            }
        }

        private void PhotoProfileForm_Load(object sender, EventArgs e)
        {
            displayPhoto();
            
        }

        private void displayData()
        {
            if(MarketPhoto != null)
            {
                labelID.Text = MarketPhoto.photoId.ToString();
                labelDescription.Text = MarketPhoto.description;
                labelOwner.Text = UserSeller.Name;
                labelPrice.Text = MarketPhoto.price.ToString() + " $";
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void buttonBuy_Click(object sender, EventArgs e)
        {
            if(LoggedInUser.BankAccount.money >= MarketPhoto.price)
            {
                LoggedInUser.updateBank(LoggedInUser.BankAccount.money - MarketPhoto.price,DataBaseProxy);
                UserSeller.updateBank(UserSeller.BankAccount.money + MarketPhoto.price, DataBaseProxy);

                DataBaseProxy.RemoveMarketPhoto(Photo);
                DataBaseProxy.InsertPhotoToCollection(LoggedInUser.ID, Photo.photoId);


                UpdaterChecker.IsMarketDataHasChanged = true;
                //UpdaterChecker.IsPhotosCollectionHasChanged = true;
                UpdaterChecker.IsBankHasChanged = true;
                this.Hide();
                
            }
            else
            {
                MessageBox.Show("You Dont Have Enough Money..");
            }
        }

        private void PhotoProfileForm_Shown(object sender, EventArgs e)
        {
            displayData();
        }
    }
}
