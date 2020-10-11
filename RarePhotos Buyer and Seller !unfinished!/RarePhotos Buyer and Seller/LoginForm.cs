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
    public partial class LoginForm : Form
    {
        public SQL_User sQL_User { get; set; } = null;
        public string Username { get; set; } = null;
        public string Password { get; set; } = null;
        public LoginForm()
        {
            InitializeComponent();
        }
        public void UserMapper(SQL_User i_User)
        {
            sQL_User = i_User;
        }
        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            SignUpForm signUpForm = new SignUpForm(UserMapper);
            Hide();
            DialogResult dialogResult = signUpForm.ShowDialog();
            if(dialogResult == DialogResult.OK && sQL_User != null)
            {
                Show();
                DialogResult = DialogResult.OK;
            }
            else
            {
                Show();
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Username = textBoxUsername.Text;
            Password = textBoxPassword.Text;
            if (!string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password))
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
