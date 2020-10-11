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
        public Photo m_Photo { get; set; }
        public string FilePath { get; set; }
        public Bitmap m_BitmapPhoto;
        public PhotoProfileForm()
        {
            InitializeComponent();
        }
        public void downloadPhoto(string i_URL)
        {
            using (WebClient wc = new WebClient())
            {
                using (Stream s = wc.OpenRead("https://static.boredpanda.com/blog/wp-content/uploads/2017/11/My-most-popular-pic-since-I-started-dog-photography-5a0b38cbd5e1e__880.jpg"))
                {
                    m_BitmapPhoto = new Bitmap(s);
                    //using (m_BitmapPhoto = new Bitmap(s))
                    //{
                        m_BitmapPhoto.Save("C:\\temp\\octopus.jpg");
                    //}
                }
            }
        }
        public void displayPhoto()
        {
            if (FilePath == null)
            {
                return;
            }
            //if (m_BitmapPhoto != null)
            //{
            //    m_BitmapPhoto.Dispose();
            //}
            pictureBoxPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
            //m_BitmapPhoto = new Bitmap(FilePath);
            int height = (400 * m_BitmapPhoto.Height) / m_BitmapPhoto.Width;
            pictureBoxPhoto.ClientSize = new Size(400,height);
            pictureBoxPhoto.Image = (Image)m_BitmapPhoto;
        }

        private void PhotoProfileForm_Load(object sender, EventArgs e)
        {
            downloadPhoto(" ");
            displayPhoto();
        }
    }
}
