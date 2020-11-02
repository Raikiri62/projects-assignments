using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusDynamics_EX1_Roy_Yitzchak
{
    public class Medication
    {
        public int OnDay { get; set; }
        public int PeriodEffect { get; set; }
        public Medication(int i_OnDay,int i_PeriodEffect)
        {
            OnDay = i_OnDay;
            PeriodEffect = i_PeriodEffect;
        }
    }
}
