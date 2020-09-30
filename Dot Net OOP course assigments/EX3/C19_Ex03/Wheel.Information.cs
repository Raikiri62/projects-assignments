namespace C19_Ex03_GarageLogic
{
    public partial struct Wheel
    {
        public struct Information
        {
            private readonly float r_CurrentAirPressure;
            private readonly float r_MaximumAirPressure;
            private readonly string r_NameOfManufacturer;

            public Information(float i_CurrentAirPressure, float i_MaximumAirPressure, string i_NameOfManufacturer)
            {
                r_CurrentAirPressure = i_CurrentAirPressure;
                r_MaximumAirPressure = i_MaximumAirPressure;
                r_NameOfManufacturer = i_NameOfManufacturer;
            }

            public float CurrentAirPressure
            {
                get { return r_CurrentAirPressure; }
            }

            public float MaximumAirPressure
            {
                get { return r_MaximumAirPressure; }
            }

            public string NameOfManufacturer
            {
                get { return r_NameOfManufacturer; }
            }

            public override string ToString()
            {
                return string.Format(
@"Current Air Pressure: {0}
Maximum Air Pressure: {1}
Name of Manufacturer: {2}", r_CurrentAirPressure, r_MaximumAirPressure, r_NameOfManufacturer);
            }
        }
    }
}