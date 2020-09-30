namespace C19_Ex03_GarageLogic
{
    public partial class VehicleThatOperatesOnFuel
    {
        public enum eRefuelStatus
        {
            Success,
            AmountOfFuelToAddIsNaN,
            AmountOfFuelToAddIsInfinity,
            TypesOfFuelsAreIncompatible,
            FuelTankOverflow
        }
    }
}