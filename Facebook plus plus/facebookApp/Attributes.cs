using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facebookApp
{
    public class Attributes : Iatrributes
    {
        public Attributes(int i_AgeRange, string i_Gender, bool i_IsBeliever, string i_Location)
        {
            Gender = i_Gender;
            Location = i_Location;
            AgeRange = i_AgeRange;
            IsBeliever = i_IsBeliever;
        }

        public string Gender { get; set ; }

        public string Location { get ; set; }

        public int AgeRange { get; set; }

        public bool IsBeliever { get ; set; }
    }
}
