using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace facebookApp
{
    public partial class MainForm : Form
    {
        public LoginForm m_Login;
        private User m_LoggedInUser;
        private string m_UserTokenToFacebook;
        private FriendsArchive m_Archive; 
        private PostForm m_PostForm;
        private FriendForm m_FriendForm;
        private MatchingForm m_MatchingForm;
        private UserEventsForm m_UserEventsForm;
        private ObjectDetailsFactory m_Factory = new ObjectDetailsFactory();
        private Updater m_Updater;
        public FriendList m_FriendList;

        public MainForm()
        {
            InitializeComponent();
            InitiateLoginToFacebook();
            m_Updater = new Updater(this); // updater is a component that update our frindlist if an online changed to the list has benn made.
        }

        private void connectToFacebookByToken()
        {
            LoginResult result = FacebookService.Connect(m_UserTokenToFacebook);
            m_LoggedInUser = result.LoggedInUser;
        }

        private void InitiateLoginToFacebook()
        {
            m_Login = LoginForm.Instance;
            DialogResult dialogResult = m_Login.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                m_UserTokenToFacebook = m_Login.m_AppSettings.LastAccessToken;
                connectToFacebookByToken();
                populateUIFromFacebookData();
                Show();
            }
            else
            {
                MessageBox.Show("There are some problems with the connection to facebook server, application is now closing :( ");
            }

            m_Login.Dispose();
        }

        private void populateUIFromFacebookData()
        {
            picture_smallPictureBox.LoadAsync(m_LoggedInUser.PictureNormalURL);
            label_username_logged.Text = m_LoggedInUser.FirstName + " "  + m_LoggedInUser.LastName;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitiateFriendsFeature();
            FetchPostsToListBox();
            fetchLikedPagesToListBox();
        }

        private void fetchLikedPagesToListBox()
        {
            try
            {
                foreach (Page page in m_LoggedInUser.LikedPages)
                {
                    if (page.Name != null)
                    {
                        LikedPagesListBox.Items.Add(page.Name);
                    }
                }
            }
            catch(Exception e)
            {
                LikedPagesListBox.Items.Add("here should be the user liked pages");
                LikedPagesListBox.Items.Add("but facebook dont accept permisson and throw exception");
                LikedPagesListBox.Items.Add("demo pages:");
                LikedPagesListBox.Items.Add("page 1");
                LikedPagesListBox.Items.Add("page 2");
                LikedPagesListBox.Items.Add("page 3");
                LikedPagesListBox.Items.Add("page 4");
            }
        }

        private void FetchPostsToListBox()
        {
            foreach (Post post in m_LoggedInUser.Posts)
            {
                if (post.Message != null)
                {
                    PostsListBox.Items.Add(post.Message);
                }
                else if (post.Caption != null)
                {
                    PostsListBox.Items.Add(post.Caption);
                }
                else
                {
                    PostsListBox.Items.Add(string.Format("[{0}]", post.Type));
                }
            }
        }

        public void InitiateFriendsFeature()
        {
            FetchFriends();
            FetchFriendsToArchive();
            loadFriendsArchiveToListBoxes();
        }

        private void FetchFriends()
        {
            m_FriendList = fetchFriendsFromFacebookUser();
        }

        private void FetchFriendsToArchive()
        {
            m_Archive = new FriendsArchive(m_FriendList);
        }

        public FriendList fetchFriendsFromFacebookUser()
        {
            FriendList friendList = new FriendList();
            foreach (User friend in m_LoggedInUser.Friends)
            {
                friendList.m_FriendsList.Add(new Friend(friend.FirstName + " " + friend.LastName));
            }

            return friendList;
        }

        private void loadFriendsArchiveToListBoxes()
        {
            FriendList friends = this.m_Archive.CurrentFriends;
            FriendList newFriends = this.m_Archive.NewFriends;
            FriendList noFriends = this.m_Archive.NoLonogerFriends;

            if(!friends.IsEmpty())
            {
                this.friendListBox.Items.Clear();
                this.friendListBox.Items.AddRange(friends.ToStringArray());
            }

            if(!newFriends.IsEmpty())
            {
                this.NewFriendListBox.Items.Clear();
                this.NewFriendListBox.Items.AddRange(newFriends.ToStringArray());
            }

            if(!noFriends.IsEmpty())
            {
                this.NoFriendListBox.Items.Clear();
                this.NoFriendListBox.Items.AddRange(noFriends.ToStringArray());
            }
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            this.Show();
        }

        private void button_logout_Click(object sender, EventArgs e)
        {
            if (File.Exists(@"appSettings.xml"))
            {
                File.Delete(@"appSettings.xml");
                Close();
            }
        }

        private void PostsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Post selectedPost = m_LoggedInUser.Posts[PostsListBox.SelectedIndex];
            InitPostForm(selectedPost);
        }

        private void InitPostForm(Post post)
        {
            PostDetails postDetails = m_Factory.getObjectDetails(post) as PostDetails;
            if (m_PostForm == null)
            {
                m_PostForm = new PostForm(postDetails);
            }
            else
            {
                m_PostForm.Hide();
                m_PostForm.PostDetails = postDetails;
                m_PostForm.InitContentToLabels();
            }

            m_PostForm.Show();
        }

        private void friendListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            User selectedFriend = m_LoggedInUser.Friends[friendListBox.SelectedIndex];
            InitFriendForm(selectedFriend);
        }

        private void InitFriendForm(User selectedFriend)
        {
            FriendDetails friendDetails = m_Factory.getObjectDetails(selectedFriend) as FriendDetails;
            if (m_FriendForm == null)
            {
                m_FriendForm = new FriendForm(friendDetails);
            }
            else
            {
                m_FriendForm.Hide();
                m_FriendForm.FriendDetails = friendDetails;
                m_FriendForm.InitContentToLabels();
            }

            m_FriendForm.Show();
        }

        private void FindDatebutton_Click(object sender, EventArgs e)
        {
            if (m_MatchingForm == null)
            {
                m_MatchingForm = new MatchingForm(m_LoggedInUser);
            }
            else
            {
                m_MatchingForm.Hide();
            }

            m_MatchingForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (m_UserEventsForm == null)
            {
                m_UserEventsForm = new UserEventsForm(m_LoggedInUser);
            }
            else
            {
                m_UserEventsForm.Hide();
            }

            m_UserEventsForm.Show();
        }

        public void showMsg(string i_msg)
        {
            MessageBox.Show(i_msg);
        }
    }
}
