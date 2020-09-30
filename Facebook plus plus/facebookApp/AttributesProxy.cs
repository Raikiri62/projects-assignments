using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facebookApp
{
    public class AttributesProxy : Iatrributes
    {
        public AttributesProxy(int i_AgeRange, string i_Gender, bool i_IsBeliever, string i_Location)
        {
            Attributes attributes = new Attributes(i_AgeRange, i_Gender, i_IsBeliever, i_Location);

            if (attributes.Location == null)
            {
                Location = attributes.Location = "tel aviv";
            }
            else if (attributes.Location == "bnei brak" && attributes.IsBeliever != true)
            {
                IsBeliever = attributes.IsBeliever = true;
            }

            if (attributes.Gender == null)
            {
                Gender = attributes.Gender = "female";
            }

            if (attributes.AgeRange == 0)
            {
                AgeRange = attributes.AgeRange = 18;
            }

            Gender = attributes.Gender;
            Location = attributes.Location;
            AgeRange = attributes.AgeRange;
            IsBeliever = attributes.IsBeliever;
        }

        public string Gender { get; set; }

        public string Location { get; set ; }

        public int AgeRange { get; set; }

        public bool IsBeliever { get ; set ; }
    }
}
