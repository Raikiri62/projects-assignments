using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusDynamics_EX1_Roy_Yitzchak
{
    public class VirusSimulation
    {
        private Patient ThePatient;
        private int[] Medications;
        public void InitSimulation(int[] i_Medications)
        {
            ThePatient = new Patient();
            if (i_Medications != null && i_Medications.Length > 1)
            {
                Array.Sort(i_Medications);
                Medications = i_Medications;
            }
        }
        public PatientStatistics RunSimulation(int i_NumberOfDays)
        {
            PatientStatistics patientStatistics = new PatientStatistics();
            if (Medications != null)
            {
                for (int i = 1; i <= i_NumberOfDays; i++)
                {
                    if (Medications.Contains(i))
                    {
                        // in this day the patient should get medication.
                        ThePatient.TakeMedication();
                    }
                    ThePatient.UpdateVirusesStateOfThePatient(patientStatistics);
                }
                return patientStatistics;
            }
            else
            {
                for (int i = 0; i < i_NumberOfDays; i++)
                {
                    ThePatient.UpdateVirusesStateOfThePatient(patientStatistics);
                }
                return patientStatistics;
            }
        }
    }
}
