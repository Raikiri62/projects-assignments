namespace C19_Ex03_GarageLogic
{
    using System;
    using System.IO;
    using System.Text;
    using System.Collections.Generic;

    public class CarThatOperatesOnFuel : VehicleThatOperatesOnFuel
    {
        internal const byte k_NumberOfWheels = 4;
        internal const float k_MaximumWheelAirPressure = 30f;
        internal const eTypeOfFuel k_TypeOfFuel = eTypeOfFuel.Octan96;
        internal const float k_CapacityOfTank = 42f;

        private Car m_car;

        public CarThatOperatesOnFuel(string i_NameOfModel, string i_NumberOfLicense, string i_NameOfWheelManufacturer,
            Car.eColor i_Color, byte i_NumberOfDoors)
            : base(i_NameOfModel, i_NumberOfLicense, k_NumberOfWheels, i_NameOfWheelManufacturer, k_MaximumWheelAirPressure, k_TypeOfFuel, k_CapacityOfTank)
        {
            m_car = new Car(i_Color, i_NumberOfDoors);
        }

        public CarThatOperatesOnFuel(string i_NameOfModel, string i_NumberOfLicense, string i_NameOfWheelManufacturer,
            float i_RemainingAmountOfFuelInTheTank,
            Car.eColor i_Color, byte i_NumberOfDoors)
            : base(i_NameOfModel, i_NumberOfLicense, k_NumberOfWheels, i_NameOfWheelManufacturer, k_MaximumWheelAirPressure, k_TypeOfFuel, i_RemainingAmountOfFuelInTheTank, k_CapacityOfTank)
        {
            m_car = new Car(i_Color, i_NumberOfDoors);
        }

        public CarThatOperatesOnFuel(string i_NameOfModel, string i_NumberOfLicense, string i_NameOfWheelManufacturer, float[] i_WheelsAirPressures,
            Car.eColor i_Color, byte i_NumberOfDoors)
            : base(i_NameOfModel, i_NumberOfLicense, i_WheelsAirPressures, i_NameOfWheelManufacturer, k_MaximumWheelAirPressure, k_TypeOfFuel, k_CapacityOfTank)
        {
            if (i_WheelsAirPressures.Length != k_NumberOfWheels)
            {
                throw new ArgumentException("i_WheelsAirPressures.Length must be equal to " + k_NumberOfWheels + '.', "i_WheelsAirPressures.Length");
            }

            m_car = new Car(i_Color, i_NumberOfDoors);
        }

        public CarThatOperatesOnFuel(string i_NameOfModel, string i_NumberOfLicense, string i_NameOfWheelManufacturer, float[] i_WheelsAirPressures,
            float i_RemainingAmountOfFuelInTheTank,
            Car.eColor i_Color, byte i_NumberOfDoors)
            : base(i_NameOfModel, i_NumberOfLicense, i_WheelsAirPressures, i_NameOfWheelManufacturer, k_MaximumWheelAirPressure, k_TypeOfFuel, i_RemainingAmountOfFuelInTheTank, k_CapacityOfTank)
        {
            if (i_WheelsAirPressures.Length != k_NumberOfWheels)
            {
                throw new ArgumentException("i_WheelsAirPressures.Length must be equal to " + k_NumberOfWheels + '.', "i_WheelsAirPressures.Length");
            }

            m_car = new Car(i_Color, i_NumberOfDoors);
        }

        public CarThatOperatesOnFuel(TextReader i_TextReader)
            : base(i_TextReader, k_NumberOfWheels, k_MaximumWheelAirPressure, k_TypeOfFuel, k_CapacityOfTank)
        {
            m_car = new Car(i_TextReader);
        }

        public CarThatOperatesOnFuel(TextReader i_TextReader, byte i_NumberOfWheels)
            : base(i_TextReader, i_NumberOfWheels, k_MaximumWheelAirPressure, k_TypeOfFuel, k_CapacityOfTank)
        {
            m_car = new Car(i_TextReader);
        }

        public CarThatOperatesOnFuel(TextReader i_TextReader, float i_MaximumWheelAirPressure)
            : base(i_TextReader, k_NumberOfWheels, i_MaximumWheelAirPressure, k_TypeOfFuel, k_CapacityOfTank)
        {
            m_car = new Car(i_TextReader);
        }

        public CarThatOperatesOnFuel(TextReader i_TextReader, byte i_NumberOfWheels, float i_MaximumWheelAirPressure)
            : base(i_TextReader, i_NumberOfWheels, i_MaximumWheelAirPressure, k_TypeOfFuel, k_CapacityOfTank)
        {
            m_car = new Car(i_TextReader);
        }

        public override Vehicle.Information Info
        {
            get { return new Vehicle.Information(r_NumberOfLicense, r_NameOfModel, WheelsInformation, FuelInformation, ExtendedInformation); }
        }

        public Car.Information ExtendedInformation
        {
            get { return m_car.Info; }
        }

        protected override StringBuilder ToStringBuilder()
        {
            StringBuilder stringBuilder = base.ToStringBuilder();
            stringBuilder.AppendLine(m_car.ToString());

            return stringBuilder;
        }

        protected override StringWriter ToStringWriter()
        {
            StringWriter stringWriter = base.ToStringWriter();
            stringWriter.WriteLine(m_car);

            return stringWriter;
        }

        public override string ToString()
        {
            return "Fuel Car" + Environment.NewLine + this.ToStringWriter().ToString();
        }
    }
}