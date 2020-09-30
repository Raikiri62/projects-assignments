using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace facebookApp
{
    public partial class FriendForm : Form
    {
        public FriendDetails FriendDetails { get; set; }

        public FriendForm(FriendDetails i_FriendDetails)
        {
            InitializeComponent();
            FriendDetails = i_FriendDetails;
        }

        public void InitContentToLabels()
        {
            if (!string.IsNullOrEmpty(FriendDetails.DetailsDictionary["Name"]))
            {
                this.Text = FriendDetails.DetailsDictionary["Name"];
            }
            else
            {
                this.Text = "friends details";
            }

            friendpictureBox1.LoadAsync(FriendDetails.DetailsDictionary["PictureURL"]);
            FriendHometownLabel.Text = FriendDetails.DetailsDictionary["Hometown"];
            FriendBirthdayLabel.Text = FriendDetails.DetailsDictionary["Birthday"];
            FriendNameLabel.Text = FriendDetails.DetailsDictionary["Name"];
            FriendPostsListBox.Items.Clear();
            FriendPostsListBox.Items.AddRange(FriendDetails.Posts);
        }

        private void FriendForm_Load(object sender, EventArgs e)
        {
            InitContentToLabels();
        }

        private void FriendForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
