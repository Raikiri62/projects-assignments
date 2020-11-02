using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VirusDynamics_EX1_Roy_Yitzchak
{
    public class Virus
    {
        public bool IsAlive { get; private set; } = true; // we assume that when we create the virus, it is alive at the begining..
        public bool IsResistance = false; // we assume that when we create the virus it is regular "weak" virus that has no resistance to Meds
        public Patient TheHostPatient { get; set; }
        public Virus(Patient i_TheHostPatient)
        {
            TheHostPatient = i_TheHostPatient;
        }
        public Virus UpdateSelfStateAndCheckWhetherToReproduce(double i_ReproducmentProbability)
        {
            SelfMutate();
            if (TestingSelfDisconnection())
            {
                // the virus died
                IsAlive = false;
                // the virus didn't reproduced - because it is dead.
                return null;
            }
            else if (IsResistance)
            {// the virus is resistance,hence, its dosent matter wheater the patient toke medication, the virus just can reproduce:
                if (DetermineReproducment(i_ReproducmentProbability))
                {
                    return Reproduce();
                }
                else
                { // the virus got the chance to reproduce,but it did not succeed
                    return null;
                }
            }
            else if (!TheHostPatient.IsOnMedication)
            { // the virus is not resistance to medication, but the patient is not on medication, so the virus can reproduce:
                if (DetermineReproducment(i_ReproducmentProbability))
                {
                    // the virus reproduced!
                    return Reproduce();
                }
                else
                {// the virus got the chance to reproduce,but it did not succeed
                    return null;
                }
            }
            else
            {
                // the virus is stil alive, but didn't reproduced. maybe the virus was not resistant and the patient toke on Medication:
                return null;
            }
        }

        private void SelfMutate()
        {
            if (RandomProvider.NextBool(0.005))
            {
                IsResistance = !IsResistance;
            }
        }
        private Virus Reproduce()
        {
            Virus virus = new Virus(TheHostPatient);
            virus.IsResistance = IsResistance; // if resistant virus split, than the other newly created virus is also resistant virus
            return virus;
        }
        private bool TestingSelfDisconnection()
        {
            return RandomProvider.NextBool(0.03);
        }
        private bool DetermineReproducment(double i_ReproducmentProbability)
        {
            return RandomProvider.NextBool(i_ReproducmentProbability);
        }
    }
}
