using System;
using FacebookWrapper;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;

namespace facebookApp
{
    public partial class LoginForm : Form
    {
        public AppSettings m_AppSettings;

        private LoginForm()
        {
            InitializeComponent();
            InitSettings();
        }

        private static volatile LoginForm sr_Instance = new LoginForm();

        public static LoginForm Instance
        {
            get { return sr_Instance; }
        }

        private void InitSettings()
        {
            m_AppSettings = AppSettings.LoadFromFile();
            rememberCheckBox.Checked = m_AppSettings.RememberUser;
        }

        private void log_in_button_OnClick(object sender, EventArgs e)
        {
            bool IsConnectedOk;
            if (m_AppSettings.RememberUser && !string.IsNullOrEmpty(m_AppSettings.LastAccessToken))
            {
                IsConnectedOk = true;
            }
            else
            {
                IsConnectedOk = InitiateNewLoginToFacebook();
            }

            DialogResult = IsConnectedOk ? DialogResult.OK : DialogResult.Abort;
        }

        private bool InitiateNewLoginToFacebook()
        {
            LoginResult result = FacebookService.Login("887224295099281", /// (desig patter's "Design Patterns Course App 2.4" app)

                "public_profile",
                "email",
                "publish_to_groups",
                "user_birthday",
                "user_age_range",
                "user_gender",
                "user_link",
                "user_tagged_places",
                "user_videos",
                "publish_to_groups",
                "groups_access_member_info",
                "user_friends",
                "user_events",
                "user_likes",
                "user_location",
                "user_photos",
                "user_posts",
                "user_hometown"

                /// DEPRECATED PERMISSIONS:
                ///"publish_actions"
                ///"user_about_me",
                ///"user_education_history",
                ///"user_actions.video",
                ///"user_actions.news",
                ///"user_actions.music",
                ///"user_actions.fitness",
                ///"user_actions.books",
                ///"user_games_activity",
                ///"user_managed_groups",
                ///"user_relationships",
                ///"user_relationship_details",
                ///"user_religion_politics",
                ///"user_tagged_places",
                ///"user_website",
                ///"user_work_history",
                ///"read_custom_friendlists",
                ///"read_page_mailboxes",
                ///"manage_pages",
                ///"publish_pages",
                ///"publish_actions",
                ///"rsvp_event"
                ///"user_groups" (This permission is only available for apps using Graph API version v2.3 or older.)
                ///"user_status" (This permission is only available for apps using Graph API version v2.3 or older.)
                /// "read_mailbox", (This permission is only available for apps using Graph API version v2.3 or older.)
                /// "read_stream", (This permission is only available for apps using Graph API version v2.3 or older.)
                /// "manage_notifications", (This permission is only available for apps using Graph API version v2.3 or older.)

                );
            if (!string.IsNullOrEmpty(result.AccessToken))
            {
                m_AppSettings.LastAccessToken = result.AccessToken;

                return true;
            }
            else
            {
                MessageBox.Show(result.ErrorMessage);

                return false;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (m_AppSettings.RememberUser && !string.IsNullOrEmpty(m_AppSettings.LastAccessToken))
            {
                this.button_login.PerformClick();
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (rememberCheckBox.Checked)
            {
                m_AppSettings.RememberUser = rememberCheckBox.Checked;
                m_AppSettings.SaveToFile();
            }
            else
            {
                AppSettings appsettings = new AppSettings();
                appsettings.SaveToFile();
            }
        }
    }
}