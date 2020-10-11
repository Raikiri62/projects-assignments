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
    public partial class SignUpForm : Form
    {
        SQL_User user;
        public delegate void UserMapperDelegate(SQL_User i_user);
        UserMapperDelegate m_UserMapperDelegate;
        public SignUpForm(UserMapperDelegate i_UserMapperDelegate)
        {
            InitializeComponent();
            m_UserMapperDelegate = i_UserMapperDelegate;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int ID = rnd.Next(1, 1000000);
            string Name = textBoxName.Text;
            string Username = textBoxUsername.Text;
            string Password = textBoxPassword.Text;
            if(!string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Username) && !string.IsNullOrEmpty(Password) && !Name.Equals("Name") && !Username.Equals("Username") && !Password.Equals("Password"))
            {
                user = new SQL_User() { id = ID, name = Name, username = Username, password = Password };
                m_UserMapperDelegate(user);
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("You have entered one or more things wrong, try fill again..");
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
