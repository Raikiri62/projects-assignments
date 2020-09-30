using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace facebookApp
{
    public class Data
    {
        public static Person DataVerifyAndCorrect(User i_FriendAccount)
        {
            string Unknown = "Unknown";
            string i_Gender = Unknown, i_Birthday = Unknown,
                   i_Location = Unknown, i_RelationshipStatus = Unknown;
            bool i_Relegion = false;
            int i_Age = 0;

            if (i_FriendAccount.Birthday != null)
            {
                AgeCalculation(i_FriendAccount.Birthday, out i_Age);
            }

            if (i_FriendAccount.Gender != null)
            {
                i_Gender = i_FriendAccount.Gender.ToString().ToLower();
            }

            if (i_FriendAccount.Location?.Name != null)
            {
                i_Location = i_FriendAccount.Location.Name.ToLower();
            }

            if (i_FriendAccount.RelationshipStatus != null)
            {
                i_RelationshipStatus = i_FriendAccount.RelationshipStatus.ToString().ToLower();
            }

            if (i_FriendAccount.Religion != null)
            {
                i_Relegion = true;
            }

            Person friendsList = new Person(i_FriendAccount.Name, i_Gender, i_Age, i_Birthday, i_Location, i_RelationshipStatus, i_Relegion);

            return friendsList;
        }

        public static void AgeCalculation(string i_Date, out int io_Age)
        {
            DateTime birthdayDate = DateTime.ParseExact(i_Date, "dd/mm/yyyy", CultureInfo.CurrentCulture);
            io_Age = new DateTime(DateTime.Now.Subtract(birthdayDate).Ticks).Year - 1;
        }
    }
}