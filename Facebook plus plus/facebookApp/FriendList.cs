using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facebookApp
{
    public class FriendList
    {
        public List<Friend> m_FriendsList;

        public FriendList()
        {
            m_FriendsList = new List<Friend>();
        }

        public FriendList(List<Friend> i_FriendsList)
        {
            m_FriendsList = i_FriendsList;
        }

        public string[] ToStringArray()
        {
            int size = m_FriendsList.Count;
            string[] stringArray = new string[size];

            for(int i = 0; i < size; i++)
            {
                stringArray[i] = m_FriendsList[i].ToString();
            }

            return stringArray;
        }

        public bool IsEmpty()
        {
            if(this.m_FriendsList == null)
            {
                return true;
            }
            else
            {
                return !this.m_FriendsList.Any();
            }
        }

        public bool Equals(FriendList i_friendList)
        {
            string[] InFriendList = this.ToStringArray();
            string[] OutFriendList = i_friendList.ToStringArray();

            return InFriendList.SequenceEqual(OutFriendList);
        }
    }
}
