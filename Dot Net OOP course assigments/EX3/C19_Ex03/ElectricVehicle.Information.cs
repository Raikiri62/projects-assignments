namespace C19_Ex03_GarageLogic
{
    public abstract partial class ElectricVehicle
    {
        public struct Information
        {
            private readonly float r_RemainingNumberOfHoursForLifeOfBattery;
            private readonly float r_MaximumNumberOfHoursForLifeOfBattery;

            public Information(float i_RemainingNumberOfHoursForLifeOfBattery, float i_MaximumNumberOfHoursForLifeOfBattery)
            {
                r_RemainingNumberOfHoursForLifeOfBattery = i_RemainingNumberOfHoursForLifeOfBattery;
                r_MaximumNumberOfHoursForLifeOfBattery = i_MaximumNumberOfHoursForLifeOfBattery;
            }

            public float RemainingNumberOfHoursForLifeOfBattery
            {
                get { return r_RemainingNumberOfHoursForLifeOfBattery; }
            }

            public float MaximumNumberOfHoursForLifeOfBattery
            {
                get { return r_MaximumNumberOfHoursForLifeOfBattery; }
            }

            public override string ToString()
            {
                return string.Format(
@"Remaining battery capacity: {0} hours
Maximum battery capacity: {1} hours", r_RemainingNumberOfHoursForLifeOfBattery, r_MaximumNumberOfHoursForLifeOfBattery);
            }
        }
    }
}