using System;
using FacebookWrapper.ObjectModel;
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
    public partial class PostForm : Form
    {
        public PostDetails PostDetails { get; set; }

        public PostForm(PostDetails i_PostDetails)
        {
            InitializeComponent();
            PostDetails = i_PostDetails;
        }

        public void InitContentToLabels()
        {
            if (!string.IsNullOrEmpty(PostDetails.DetailsDictionary["Name"]))
            {
                this.Text = PostDetails.DetailsDictionary["Name"];
            }
            else
            {
                this.Text = "post content";
            }

            CaptionLabel.Text = PostDetails.DetailsDictionary["Caption"];
            DescriptionLabel.Text = PostDetails.DetailsDictionary["Description"];
            MessageLabel.Text = PostDetails.DetailsDictionary["Message"];
            NameLabel.Text = PostDetails.DetailsDictionary["Name"];
            CommentsListBox.Items.Clear();
            CommentsListBox.Items.AddRange(PostDetails.Comments);
        }

        private void PostForm_Load(object sender, EventArgs e)
        {
            InitContentToLabels();
        }

        private void PostForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
