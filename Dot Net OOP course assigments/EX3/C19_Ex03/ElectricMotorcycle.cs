namespace C19_Ex03_GarageLogic
{
    using System;
    using System.IO;
    using System.Text;
    using System.Collections.Generic;

    public class ElectricMotorcycle : ElectricVehicle
    {
        internal const byte k_NumberOfWheels = 2;
        internal const float k_MaximumWheelAirPressure = 28f;
        internal const float k_MaximumNumberOfHoursForLifeOfBattery = 1.6f;

        private Motorcycle m_motorcycle;

        public ElectricMotorcycle(string i_NameOfModel, string i_NumberOfLicense, string i_NameOfWheelManufacturer,
            Motorcycle.eTypeOfLicense i_license, int i_CapacityOfEngine)
            : base(i_NameOfModel, i_NumberOfLicense, k_NumberOfWheels, i_NameOfWheelManufacturer, k_MaximumWheelAirPressure, k_MaximumNumberOfHoursForLifeOfBattery)
        {
            m_motorcycle = new Motorcycle(i_license, i_CapacityOfEngine);
        }

        public ElectricMotorcycle(string i_NameOfModel, string i_NumberOfLicense, string i_NameOfWheelManufacturer,
            float i_RemainingNumberOfHoursForLifeTimeOfBattery,
            Motorcycle.eTypeOfLicense i_license, int i_CapacityOfEngine)
            : base(i_NameOfModel, i_NumberOfLicense, k_NumberOfWheels, i_NameOfWheelManufacturer, k_MaximumWheelAirPressure, i_RemainingNumberOfHoursForLifeTimeOfBattery, k_MaximumNumberOfHoursForLifeOfBattery)
        {
            m_motorcycle = new Motorcycle(i_license, i_CapacityOfEngine);
        }

        public ElectricMotorcycle(string i_NameOfModel, string i_NumberOfLicense, string i_NameOfWheelManufacturer, float[] i_WheelsAirPressures,
            Motorcycle.eTypeOfLicense i_license, int i_CapacityOfEngine)
            : base(i_NameOfModel, i_NumberOfLicense, i_WheelsAirPressures, i_NameOfWheelManufacturer, k_MaximumWheelAirPressure, k_MaximumNumberOfHoursForLifeOfBattery)
        {
            if (i_WheelsAirPressures.Length != k_NumberOfWheels)
            {
                throw new ArgumentException("i_WheelsAirPressures.Length must be equal to " + k_NumberOfWheels + '.', "i_WheelsAirPressures.Length");
            }

            m_motorcycle = new Motorcycle(i_license, i_CapacityOfEngine);
        }

        public ElectricMotorcycle(string i_NameOfModel, string i_NumberOfLicense, string i_NameOfWheelManufacturer, float[] i_WheelsAirPressures,
            float i_RemainingNumberOfHoursForLifeTimeOfBattery,
            Motorcycle.eTypeOfLicense i_license, int i_CapacityOfEngine)
            : base(i_NameOfModel, i_NumberOfLicense, i_WheelsAirPressures, i_NameOfWheelManufacturer, k_MaximumWheelAirPressure, i_RemainingNumberOfHoursForLifeTimeOfBattery, k_MaximumNumberOfHoursForLifeOfBattery)
        {
            if (i_WheelsAirPressures.Length != k_NumberOfWheels)
            {
                throw new ArgumentException("i_WheelsAirPressures.Length must be equal to " + k_NumberOfWheels + '.', "i_WheelsAirPressures.Length");
            }

            m_motorcycle = new Motorcycle(i_license, i_CapacityOfEngine);
        }

        public ElectricMotorcycle(TextReader i_TextReader)
            : base(i_TextReader, k_NumberOfWheels, k_MaximumWheelAirPressure, k_MaximumNumberOfHoursForLifeOfBattery)
        {
            m_motorcycle = new Motorcycle(i_TextReader);
        }

        public ElectricMotorcycle(TextReader i_TextReader, byte i_NumberOfWheels)
            : base(i_TextReader, i_NumberOfWheels, k_MaximumWheelAirPressure, k_MaximumNumberOfHoursForLifeOfBattery)
        {
            m_motorcycle = new Motorcycle(i_TextReader);
        }

        public ElectricMotorcycle(TextReader i_TextReader, float i_MaximumWheelAirPressure)
            : base(i_TextReader, k_NumberOfWheels, i_MaximumWheelAirPressure, k_MaximumNumberOfHoursForLifeOfBattery)
        {
            m_motorcycle = new Motorcycle(i_TextReader);
        }

        public ElectricMotorcycle(TextReader i_TextReader, byte i_NumberOfWheels, float i_MaximumWheelAirPressure)
            : base(i_TextReader, i_NumberOfWheels, i_MaximumWheelAirPressure, k_MaximumNumberOfHoursForLifeOfBattery)
        {
            m_motorcycle = new Motorcycle(i_TextReader);
        }

        public override Vehicle.Information Info
        {
            get { return new Vehicle.Information(r_NumberOfLicense, r_NameOfModel, WheelsInformation, BatteryInformation, ExtendedInformation); }
        }

        public Motorcycle.Information ExtendedInformation
        {
            get { return m_motorcycle.Info; }
        }

        protected override StringBuilder ToStringBuilder()
        {
            StringBuilder stringBuilder = base.ToStringBuilder();
            stringBuilder.AppendLine(m_motorcycle.ToString());

            return stringBuilder;
        }

        protected override StringWriter ToStringWriter()
        {
            StringWriter stringWriter = base.ToStringWriter();
            stringWriter.WriteLine(m_motorcycle);

            return stringWriter;
        }

        public override string ToString()
        {
            return "Electric Motorcycle" + Environment.NewLine + this.ToStringWriter().ToString();
        }
    }
}