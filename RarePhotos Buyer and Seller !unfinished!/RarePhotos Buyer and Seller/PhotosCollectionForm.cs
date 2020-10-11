using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RarePhotos_Buyer_and_Seller
{
    public partial class PhotosCollectionForm : Form
    {
        public User LogggedInUser { get; set; }
        public PhotosCollectionForm(User i_LogggedInUser)
        {
            InitializeComponent();
            LogggedInUser = i_LogggedInUser;
            doSomethingWithThis();
        }

        private void doSomethingWithThis()
        {
            return;
        }
    }
}
