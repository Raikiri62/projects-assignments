using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper.ObjectModel;

namespace facebookApp
{
    abstract public class Matching
    {
        public  void FindMatch(User UserLoggedIn, int i_AgeRangeChoice, string i_LocationChoice, 
                                List<Person> i_Persons, List<Person> io_BestMatchList, List<Person> io_SecondBestMatchList)
        {
            CollectAllFriendsToList(i_Persons, UserLoggedIn);
            ChosenGenderMatch(i_AgeRangeChoice, i_LocationChoice, i_Persons, io_BestMatchList, io_SecondBestMatchList);
        }

        public void CollectAllFriendsToList(List<Person> i_Persons, User UserLoggedIn)
        {
            foreach (User friend in UserLoggedIn.Friends)
            {
                Person person = Data.DataVerifyAndCorrect(friend);
                i_Persons.Add(person);
            }
        }

        public abstract void ChosenGenderMatch(int i_AgeRangeChoice, string i_LocationChoice, List<Person> i_Persons, List<Person> io_BestMatchList, List<Person> io_SecondBestMatchList);
    }
}