using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusDynamics_EX1_Roy_Yitzchak
{
    public class Patient
    {
        private List<Virus> VirusPopulation;
        private int AmountOfCells;
        private double VirusDisconnectionProbability;
        private double VirusGrowthProbability;
        private double ReproducmentProbability;
        public Patient(int i_AmountOfCells, int i_AmountOfInitialViruses, double i_VirusDisconnectionProbability, double i_VirusGrowthProbability)
        {
            AmountOfCells = i_AmountOfCells;
            VirusDisconnectionProbability = i_VirusDisconnectionProbability;
            VirusGrowthProbability = i_VirusGrowthProbability;
            VirusPopulation = new List<Virus>();
            for(int i=0;i< i_AmountOfInitialViruses;i++)
            {
                VirusPopulation.Add(new Virus());
            }
        }
        
        //this is the main method:
        public void UpdateVirusesStateOfThePatient(PatientStatistics o_PatientStatistics)
        {
            GenerateReproducmentProbability(); // determine what is the real probability by the parameters of number of viruses compared to the number of cells times the given growth constant
            int NumberOfVirusesThatReproduced = 0;
            foreach (Virus virus in VirusPopulation)
            {
                bool DoesTheVirusReproduced = virus.UpdateSelfStateAndCheckWhetherToReproduce(ReproducmentProbability, VirusDisconnectionProbability);
                if (DoesTheVirusReproduced)
                {
                    NumberOfVirusesThatReproduced++;
                }
            }
            // at the end of this phase, we add the new viruses that have been reproduced:
            for (int i = 0; i < NumberOfVirusesThatReproduced; i++)
            {
                VirusPopulation.Add(new Virus());
            }


            // at the end, lets make a new record for our statistics object:
            PatientDayRecord patientDayRecord = new PatientDayRecord(CalculateNumberOfAliveViruses(), CalculateNumberOfDeadViruses());
            o_PatientStatistics.DaysRecords.Add(patientDayRecord);   
        }
        private int CalculateNumberOfAliveViruses()
        {
            int count = 0;
            foreach(Virus virus in VirusPopulation)
            {
                if (virus.IsAlive) count++;
            }
            return count;
        }
        private int CalculateNumberOfDeadViruses()
        {
            return VirusPopulation.Count - CalculateNumberOfAliveViruses();
        }
        private void GenerateReproducmentProbability()
        {
            double calculation = (double)CalculateNumberOfAliveViruses() / AmountOfCells;
            ReproducmentProbability = (1 - calculation) * VirusGrowthProbability;
        }
    }
}
