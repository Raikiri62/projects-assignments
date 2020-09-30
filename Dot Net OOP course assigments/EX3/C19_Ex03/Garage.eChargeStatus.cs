namespace C19_Ex03_GarageLogic
{
    public partial class Garage
    {
        public enum eChargeStatus
        {
            Success,
            NumberOfLicenseIsNull,
            NumberOfMinutesToAddToLifeTimeOfBatteryIsNaN,
            NumberOfMinutesToAddToLifeTimeOfBatteryIsInfinity,
            NumberOfMinutesToAddToLifeTimeOfBatteryIsNotPositive,
            TheGarageDoesNotHaveAVehicleWithThisLicenseNumber,
            TheReferredVehicleIsNotElectric,
            Overflow
        }
    }
}