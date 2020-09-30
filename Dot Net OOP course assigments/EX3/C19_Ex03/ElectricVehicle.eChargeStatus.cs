namespace C19_Ex03_GarageLogic
{
    public partial class ElectricVehicle
    {
        public enum eChargeStatus
        {
            Success,
            NumberOfHoursToAddToLifeTimeOfBatteryIsNaN,
            NumberOfHoursToAddToLifeTimeOfBatteryIsInfinity,
            NumberOfHoursToAddToLifeTimeOfBatteryIsNotPositive,
            Overflow
        }
    }
}