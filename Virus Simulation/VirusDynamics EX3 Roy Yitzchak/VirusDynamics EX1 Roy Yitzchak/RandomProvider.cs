using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusDynamics_EX1_Roy_Yitzchak
{
    public static class RandomProvider
    {
        private static Random random = new Random();
        public static bool NextBool(double i_Probability)
        {
            return random.NextDouble() < i_Probability;
        }
    }
}
