using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facebookApp
{
    public class MenMatch : Matching
    {
        public override void ChosenGenderMatch(int i_AgeRangeChoice, string i_LocationChoice, List<Person> i_Persons, List<Person> io_BestMatchList, List<Person> io_SecondBestMatchList)
        {
            foreach (Person person in i_Persons)
            {
                if (person.Gender == "male" && (person.RelationshipStatus == "single")
                    && person.Age >= i_AgeRangeChoice && person.Age <= (i_AgeRangeChoice + 20)) 
                {
                    io_SecondBestMatchList.Add(person);

                    if (person.Location.Contains(i_LocationChoice))
                    {
                        io_SecondBestMatchList.Remove(person);
                        io_BestMatchList.Add(person);
                    }
                }
            }
        }
    }
}
