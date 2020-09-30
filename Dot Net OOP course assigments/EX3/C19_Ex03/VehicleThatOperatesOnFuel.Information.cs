namespace C19_Ex03_GarageLogic
{
    public abstract partial class VehicleThatOperatesOnFuel
    {
        public struct Information
        {
            private readonly float r_RemainingAmountOfFuel;
            private readonly float r_CapacityOfTank;
            private readonly eTypeOfFuel r_TypeOfFuel;

            public Information(float i_RemainingAmountOfFuel, float i_CapacityOfTank, eTypeOfFuel i_TypeOfFuel)
            {
                r_RemainingAmountOfFuel = i_RemainingAmountOfFuel;
                r_CapacityOfTank = i_CapacityOfTank;
                r_TypeOfFuel = i_TypeOfFuel;
            }

            public float RemainingAmountOfFuel
            {
                get { return r_RemainingAmountOfFuel; }
            }

            public float CapacityOfTank
            {
                get { return r_CapacityOfTank; }
            }

            public eTypeOfFuel TypeOfFuel
            {
                get { return r_TypeOfFuel; }
            }

            public override string ToString()
            {
                return string.Format(
@"Remaining amount of fuel: {0} liters
Capacity of fuel Tank: {1} liters
Type of Fuel: {2}", r_RemainingAmountOfFuel, r_CapacityOfTank, r_TypeOfFuel);
            }
        }
    }
}