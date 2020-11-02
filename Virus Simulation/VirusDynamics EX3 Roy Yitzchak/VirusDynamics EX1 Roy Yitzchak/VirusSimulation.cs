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
        private List<Medication> Medications;
        public void InitSimulation(List<Medication> i_Medications)
        {
            ThePatient = new Patient();
            if (i_Medications != null && i_Medications.Count > 0)
            {
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
                    foreach(Medication medication in Medications)
                    {
                        if(medication.OnDay == i)
                        {
                            ThePatient.TakeMedication(medication.PeriodEffect);
                        }
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
