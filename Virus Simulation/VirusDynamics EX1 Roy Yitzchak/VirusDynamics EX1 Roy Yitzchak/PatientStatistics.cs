using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusDynamics_EX1_Roy_Yitzchak
{
    public class PatientStatistics
    {
        public List<PatientDayRecord> DaysRecords { get; set; }
        public PatientStatistics()
        {
            DaysRecords = new List<PatientDayRecord>();
        }
    }
}
