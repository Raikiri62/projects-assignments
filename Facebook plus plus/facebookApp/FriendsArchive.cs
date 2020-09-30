using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace facebookApp
{
    public class FriendsArchive
    {
        public FriendsArchive(FriendList i_CurrentFriends)
        {
            CurrentFriends = i_CurrentFriends;
            loadLastFriends();
            saveFriendsList();
            proccessNewFriends();
            proccessNoLonogerFriends();
        }

        public FriendList LastFriends { get; set; } // init by ctor + private method.

        public FriendList CurrentFriends { get; set; } // init by ctor.

        public FriendList NoLonogerFriends { get; set; } // init by proccessNoLonogerFriends method.

        public FriendList NewFriends { get; set; }

        public bool IsSomethingChanged { get; set; } = false;

        private void proccessNoLonogerFriends()
        {
            List<Friend> lst;
            if(!IsSomethingChanged)
            {
                lst = new List<Friend>();
            }
            else
            {
                lst = new List<Friend>();
                foreach (Friend lastFriend in LastFriends.m_FriendsList)
                {
                    bool exist = false;
                    foreach (Friend currentFriend in CurrentFriends.m_FriendsList)
                    {
                        if (lastFriend.FullName == currentFriend.FullName)
                        {
                            exist = true;
                        }
                    }

                    if (!exist)
                    {
                        lst.Add(lastFriend);
                    }
                }
            }

            FriendList friendList = new FriendList(lst);
            NoLonogerFriends = friendList;
        }

        private void proccessNewFriends()
        {
            List<Friend> lst;
            if (!this.IsSomethingChanged)
            {
                lst = new List<Friend>();
            }
            else
            {
                lst = new List<Friend>();
                foreach(Friend currentFriend in CurrentFriends.m_FriendsList)
                {
                    bool exist = false;
                    foreach (Friend lastFriend in LastFriends.m_FriendsList)
                    {
                        if (currentFriend.FullName == lastFriend.FullName)
                        {
                            exist = true;
                        }
                    }

                    if (!exist)
                    {
                        lst.Add(currentFriend);
                    }
                }
            }

            FriendList friendList = new FriendList(lst);
            NewFriends = friendList;
        }

        private void loadLastFriends()
        {
            if (!File.Exists(@"oldfriends.xml"))
            {
                this.LastFriends = this.CurrentFriends;
                this.IsSomethingChanged = false;
            }
            else
            {
                this.IsSomethingChanged = true;
                Stream stream = null;
                using (stream = new FileStream(@"oldfriends.xml", FileMode.Open))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(FriendList));
                    this.LastFriends = serializer.Deserialize(stream) as FriendList;
                }
            }
        }

        private void saveFriendsList()
        {
            Stream stream = null;
            if (File.Exists(@"oldfriends.xml"))
            {
                File.Delete(@"oldfriends.xml");
            }

            using (stream = new FileStream(@"oldfriends.xml", FileMode.Create))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(FriendList));
                serializer.Serialize(stream, CurrentFriends);
            }
        }
    }
}
