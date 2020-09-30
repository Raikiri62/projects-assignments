using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace facebookApp
{
    public interface Iatrributes
    {
         string Gender { get; set; }

         string Location { get; set; }

         int AgeRange { get; set; }

         bool IsBeliever { get; set; }
    }
}
