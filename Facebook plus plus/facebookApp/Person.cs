using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facebookApp
{
    public class Person
    {
        public Person(string i_Name, string i_Gender, int i_Age, string i_Birthday, string i_Location, string i_RelationshipStatus, bool i_Relegion)
        {
            Name = i_Name;
            Gender = i_Gender;
            Birthday = i_Birthday;
            Age = i_Age;
            Location = i_Location;
            RelationshipStatus = i_RelationshipStatus;
            Religion = i_Relegion;
        }

        public bool Religion { get; }

        public string Name { get; }

        public string Birthday { get; }

        public string Location { get; }

        public string RelationshipStatus { get; }

        public string Gender { get; }

        public int Age { get; }
    }
}
