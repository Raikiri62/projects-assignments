using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusDynamics_EX1_Roy_Yitzchak
{
    public class VirusSimulation
    {
        public int AmountOfCells { get; private set; }
        public int AmountOfInitialViruses { get; private set; }
        public double VirusDisconnectionProbability { get; private set; }
        public double VirusGrowthProbability { get; private set; }
        private Patient ThePatient;
        public void InitSimulation(int i_AmountOfCells,int i_AmountOfInitialViruses, double i_VirusDisconnectionProbability, double i_VirusGrowthProbability)
        {
            AmountOfCells = i_AmountOfCells;
            AmountOfInitialViruses = i_AmountOfInitialViruses;
            VirusDisconnectionProbability = i_VirusDisconnectionProbability;
            VirusGrowthProbability = i_VirusGrowthProbability;
            ThePatient = new Patient(AmountOfCells, AmountOfInitialViruses, VirusDisconnectionProbability, VirusGrowthProbability);
        }
        private bool IsEverythingInitializedCorrectly()
        {
            if(ThePatient != null && VirusDisconnectionProbability > 0 && VirusGrowthProbability > 0 && AmountOfCells > AmountOfInitialViruses && AmountOfInitialViruses > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public PatientStatistics RunSimulation(int i_NumberOfDays)
        {
            if(IsEverythingInitializedCorrectly())
            {
                PatientStatistics patientStatistics = new PatientStatistics();
                for(int i=0;i<i_NumberOfDays;i++)
                {
                    ThePatient.UpdateVirusesStateOfThePatient(patientStatistics);
                }
                return patientStatistics;
            }
            else
            {
                throw new Exception("Some parameters were not initialized correctly.. :( ");
            }
        }
    }
}
