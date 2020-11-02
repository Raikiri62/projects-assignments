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
    public partial class MainForm : Form
    {
        private void InitProxies()
        {
            CloudinaryProxy = new CloudinaryProxy();
            DataBaseProxy = new DataBaseProxy();
        }
        private void fetchUsers()
        {
            Users = DataBaseProxy.GetAllUsers();
        }
        public void InitLoginToTheApp()
        {
            m_LoginForm = new LoginForm();
            DialogResult dialogResult = m_LoginForm.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                if(m_LoginForm.sQL_User != null) // there was a sign up for new user
                {
                    LoggedInUser = CreateNewUser(m_LoginForm.sQL_User);
                }
                else // there was a login to existing user
                {
                    var usr = FindAndFetchTheUser(m_LoginForm.Username, m_LoginForm.Password);
                    if(usr != null)
                    {
                        LoggedInUser = usr;
                    }
                    else
                    {
                        MessageBox.Show("No such user exist!");
                        Close();
                    }
                    
                }
                Show();
            }
            else
            {
                Close();
            }
        }
        public User FindAndFetchTheUser(string i_Username,string i_Password)
        {
            if(Users != null)
            {
                foreach(User usr in Users)
                {
                    if (usr.UserName.Equals(i_Username) && usr.Password.Equals(i_Password))
                    {
                        return usr;
                    }
                }
                return null;
            }
            else
            {
                return null;
            }
        }
        public User CreateNewUser(SQL_User i_SQL_User)
        {
            return DataBaseProxy.CreateNewUser(i_SQL_User);
        }
    }
}





