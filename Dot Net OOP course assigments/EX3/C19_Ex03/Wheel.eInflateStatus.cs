namespace C19_Ex03_GarageLogic
{
    public partial struct Wheel
    {
        public enum eInflateStatus
        {
            Success,
            AmountOfAirToAddToTheWheelIsNan,
            AmountOfAirToAddToTheWheelIsInfinity,
            AmountOfAirToAddToTheWheelIsNotPositiveNumber,
            Overflow
        }
    }
}