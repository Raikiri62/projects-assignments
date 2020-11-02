using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusDynamics_EX1_Roy_Yitzchak
{
    public class PatientDayRecord
    {
        public int NumberOfAliveViruses{ get; private set; }
        public int NumberOfDeadViruses { get; private set; }
        public PatientDayRecord(int i_NumberOfAliveViruses, int i_NumberOfDeadViruses)
        {
            NumberOfAliveViruses = i_NumberOfAliveViruses;
            NumberOfDeadViruses = i_NumberOfDeadViruses;
        }
    }
}
