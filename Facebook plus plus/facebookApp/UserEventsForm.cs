using System;
using FacebookWrapper;
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
    public partial class UserEventsForm : Form
    {
        public User UserLoggedIn { get; set; }

        public UserEventsForm(User i_LoggedUser)
        {
            UserLoggedIn = i_LoggedUser;
            InitializeComponent();
        }

        private void fetchEvents()
        {
            /*            listBoxEvents.Items.Clear();
                        listBoxEvents.DisplayMember = "Name";
                        foreach (Event fbEvent in UserLoggedIn.Events)
                        {
                            listBoxEvents.Items.Add(fbEvent);
                        }

                        if (UserLoggedIn.Events.Count == 0)
                        {
                            MessageBox.Show("No Events to retrieve :(");
                        }*/

            eventBindingSource.DataSource = UserLoggedIn.Events;
        }

        private void labelEvents_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            fetchEvents();
        }
    }
}
