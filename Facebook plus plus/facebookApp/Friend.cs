using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace facebookApp
{
    public class Friend
    {
        public Friend()
        {
            FullName = "Default name";
        }

        public Friend(string i_Fullname)
        {
            FullName = i_Fullname;
        }

        public string FullName { get;set; }

        public override string ToString()
        {
            return FullName;
        }
    }
}
