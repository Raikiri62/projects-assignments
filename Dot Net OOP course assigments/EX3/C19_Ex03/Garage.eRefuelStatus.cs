namespace C19_Ex03_GarageLogic
{
    public partial class Garage
    {
        public enum eRefuelStatus
        {
            Success,
            NumberOfLicenseIsNull,
            AmountOfFuelToAddIsNaN,
            AmountOfFuelToAddIsInfinity,
            TheGarageDoesNotHaveAVehicleWithThisLicenseNumber,
            TheReferredVehicleDoesNotOperateOnFuel,
            TypesOfFuelsAreIncompatible,
            FuelTankOverflow
        }
    }
}