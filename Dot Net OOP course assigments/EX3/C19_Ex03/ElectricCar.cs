namespace C19_Ex03_GarageLogic
{
    using System;
    using System.IO;
    using System.Text;
    using System.Collections.Generic;

    public partial class ElectricCar : ElectricVehicle
    {
        internal const byte k_NumberOfWheels = 4;
        internal const float k_MaximumWheelAirPressure = 30f;
        internal const float k_MaximumNumberOfHoursForLifeTimeOfBattery = 2.5f;

        private Car m_car;

        public ElectricCar(string i_NameOfModel, string i_NumberOfLicense, string i_NameOfWheelManufacturer,
            Car.eColor i_Color, byte i_NumberOfDoors)
            : base(i_NameOfModel, i_NumberOfLicense, k_NumberOfWheels, i_NameOfWheelManufacturer, k_MaximumWheelAirPressure, k_MaximumNumberOfHoursForLifeTimeOfBattery)
        {
            m_car = new Car(i_Color, i_NumberOfDoors);
        }

        public ElectricCar(string i_NameOfModel, string i_NumberOfLicense, string i_NameOfWheelManufacturer,
            float i_RemainingNumberOfHoursForLifeTimeOfBattery,
            Car.eColor i_Color, byte i_NumberOfDoors)
            : base(i_NameOfModel, i_NumberOfLicense, k_NumberOfWheels, i_NameOfWheelManufacturer, k_MaximumWheelAirPressure, i_RemainingNumberOfHoursForLifeTimeOfBattery, k_MaximumNumberOfHoursForLifeTimeOfBattery)
        {
            m_car = new Car(i_Color, i_NumberOfDoors);
        }

        public ElectricCar(string i_NameOfModel, string i_NumberOfLicense, string i_NameOfWheelManufacturer, float[] i_WheelsAirPressures,
            Car.eColor i_Color, byte i_NumberOfDoors)
            : base(i_NameOfModel, i_NumberOfLicense, i_WheelsAirPressures, i_NameOfWheelManufacturer, k_MaximumWheelAirPressure, k_MaximumNumberOfHoursForLifeTimeOfBattery)
        {
            if (i_WheelsAirPressures.Length != k_NumberOfWheels)
            {
                throw new ArgumentException("i_WheelsAirPressures.Length must be equal to " + k_NumberOfWheels + '.', "i_WheelsAirPressures.Length");
            }

            m_car = new Car(i_Color, i_NumberOfDoors);
        }

        public ElectricCar(string i_NameOfModel, string i_NumberOfLicense, string i_NameOfWheelManufacturer, float[] i_WheelsAirPressures,
            float i_RemainingNumberOfHoursForLifeTimeOfBattery,
            Car.eColor i_Color, byte i_NumberOfDoors)
            : base(i_NameOfModel, i_NumberOfLicense, i_WheelsAirPressures, i_NameOfWheelManufacturer, k_MaximumWheelAirPressure, i_RemainingNumberOfHoursForLifeTimeOfBattery, k_MaximumNumberOfHoursForLifeTimeOfBattery)
        {
            if (i_WheelsAirPressures.Length != k_NumberOfWheels)
            {
                throw new ArgumentException("i_WheelsAirPressures.Length must be equal to " + k_NumberOfWheels + '.', "i_WheelsAirPressures.Length");
            }

            m_car = new Car(i_Color, i_NumberOfDoors);
        }

        public ElectricCar(TextReader i_TextReader)
            : base(i_TextReader, k_NumberOfWheels, k_MaximumWheelAirPressure, k_MaximumNumberOfHoursForLifeTimeOfBattery)
        {
            m_car = new Car(i_TextReader);
        }

        public ElectricCar(TextReader i_TextReader, byte i_NumberOfWheels)
            : base(i_TextReader, i_NumberOfWheels, k_MaximumWheelAirPressure, k_MaximumNumberOfHoursForLifeTimeOfBattery)
        {
            m_car = new Car(i_TextReader);
        }

        public ElectricCar(TextReader i_TextReader, float i_MaximumWheelAirPressure)
            : base(i_TextReader, k_NumberOfWheels, i_MaximumWheelAirPressure, k_MaximumNumberOfHoursForLifeTimeOfBattery)
        {
            m_car = new Car(i_TextReader);
        }

        public ElectricCar(TextReader i_TextReader, byte i_NumberOfWheels, float i_MaximumWheelAirPressure)
            : base(i_TextReader, i_NumberOfWheels, i_MaximumWheelAirPressure, k_MaximumNumberOfHoursForLifeTimeOfBattery)
        {
            m_car = new Car(i_TextReader);
        }

        public override Vehicle.Information Info
        {
            get { return new Vehicle.Information(r_NumberOfLicense, r_NameOfModel, WheelsInformation, BatteryInformation, ExtendedInformation); }
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
            return "Electric Car" + Environment.NewLine + this.ToStringWriter().ToString();
        }
    }
}