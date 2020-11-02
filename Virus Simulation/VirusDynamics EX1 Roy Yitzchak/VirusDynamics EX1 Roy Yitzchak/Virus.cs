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
        public bool UpdateSelfStateAndCheckWhetherToReproduce(double i_ReproduceProbability,double i_DisconnectionProbability)
        {
            if (TestingSelfDisconnection(i_DisconnectionProbability))
            {
                // the virus died
                IsAlive = false;
                // the virus didn't reproduced - because it is dead...so:
                return false;
            }
            else if(DetermineReproducment(i_ReproduceProbability))
            {
                // the virus reproduced!
                return true;
            }
            else
            {
                // the virus is stil alive, but didn't reproduced
                return false;
            }
        }
        private bool TestingSelfDisconnection(double i_DisconnectionProbability)
        {
            return RandomProvider.NextBool(i_DisconnectionProbability);
        }
        private bool DetermineReproducment(double i_ReproduceProbability)
        {
            return RandomProvider.NextBool(i_ReproduceProbability);
        }
    }
}
