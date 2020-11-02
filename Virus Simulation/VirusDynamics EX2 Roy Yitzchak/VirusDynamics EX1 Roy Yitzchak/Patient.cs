using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusDynamics_EX1_Roy_Yitzchak
{
    public class Patient
    {
        public List<Virus> VirusPopulation { get; private set; }
        public bool IsOnMedication { get; private set; } = false;
        public int MedicationEffectPeriod { get; private set; } = 0;
        private double ReproducmentProbability;
        public Patient()
        {
            VirusPopulation = new List<Virus>();
            for (int i = 0; i < 100; i++)
            {
                VirusPopulation.Add(new Virus(this));
            }
        }
        public void UpdateVirusesStateOfThePatient(PatientStatistics o_PatientStatistics)
        {
            GenerateReproducmentProbability(); // determine what is the real probability by the parameters of number of viruses compared to the number of cells times the given growth constant
            List<Virus> ReproducedViruses = new List<Virus>(); // the viruses that have been reproduced in one (this) phase
            foreach (Virus virus in VirusPopulation)
            {
                Virus newVirus = virus.UpdateSelfStateAndCheckWhetherToReproduce(ReproducmentProbability);
                if (newVirus != null)
                {
                    ReproducedViruses.Add(newVirus);
                }
            }
            // at the end of this phase, we add the new viruses that have been reproduced:
            if (ReproducedViruses.Count > 0)
            {
                VirusPopulation.AddRange(ReproducedViruses);
            }
            // a day (iteration) has passed, so:
            ADayPass();
            // at the end, lets make a new record for our statistics object:
            PatientDayRecord patientDayRecord = new PatientDayRecord(CalculateNumberOfAliveViruses(), CalculateNumberOfDeadViruses());
            o_PatientStatistics.DaysRecords.Add(patientDayRecord);
        }
        private int CalculateNumberOfAliveViruses()
        {
            int count = 0;
            foreach (Virus virus in VirusPopulation)
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
            double calculation = (double)CalculateNumberOfAliveViruses() / 1000;
            ReproducmentProbability = (1 - calculation) * 0.1;
        }
        public void TakeMedication()
        {
            IsOnMedication = true;
            MedicationEffectPeriod = 15;
        }
        private void ADayPass()
        {
            if (MedicationEffectPeriod > 0)
            {
                MedicationEffectPeriod--;
            }
            if (MedicationEffectPeriod == 0)
            {
                IsOnMedication = false;
            }
        }
    }
}
