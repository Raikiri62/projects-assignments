namespace C19_Ex03_GarageLogic
{
    using System;
    using System.IO;
    using System.Text;
    using System.Collections.Generic;

    public class ElectricTruck : ElectricVehicle
    {
        internal const byte k_NumberOfWheels = 16;
        internal const float k_MaximumWheelAirPressure = 26f;
        internal const float k_MaximumNumberOfHoursForLifeTimeOfBattery = 3f;

        private Truck m_truck;

        public ElectricTruck(string i_NameOfModel, string i_NumberOfLicense, string i_NameOfWheelManufacturer,
            bool i_ContainsDangerousSubstances, float i_VolumeOfCargo)
            : base(i_NameOfModel, i_NumberOfLicense, k_NumberOfWheels, i_NameOfWheelManufacturer, k_MaximumWheelAirPressure, k_MaximumNumberOfHoursForLifeTimeOfBattery)
        {
            m_truck = new Truck(i_ContainsDangerousSubstances, i_VolumeOfCargo);
        }

        public ElectricTruck(string i_NameOfModel, string i_NumberOfLicense, string i_NameOfWheelManufacturer,
            float i_RemainingNumberOfHoursForLifeOfBattery,
            bool i_ContainsDangerousSubstances, float i_VolumeOfCargo)
            : base(i_NameOfModel, i_NumberOfLicense, k_NumberOfWheels, i_NameOfWheelManufacturer, k_MaximumWheelAirPressure, i_RemainingNumberOfHoursForLifeOfBattery, k_MaximumNumberOfHoursForLifeTimeOfBattery)
        {
            m_truck = new Truck(i_ContainsDangerousSubstances, i_VolumeOfCargo);
        }

        public ElectricTruck(string i_NameOfModel, string i_NumberOfLicense, string i_NameOfWheelManufacturer, float[] i_WheelsAirPressures,
            bool i_ContainsDangerousSubstances, float i_VolumeOfCargo)
            : base(i_NameOfModel, i_NumberOfLicense, i_WheelsAirPressures, i_NameOfWheelManufacturer, k_MaximumWheelAirPressure, k_MaximumNumberOfHoursForLifeTimeOfBattery)
        {
            if (i_WheelsAirPressures.Length != k_NumberOfWheels)
            {
                throw new ArgumentException("i_WheelsAirPressures.Length must be equal to " + k_NumberOfWheels + '.', "i_WheelsAirPressures.Length");
            }

            m_truck = new Truck(i_ContainsDangerousSubstances, i_VolumeOfCargo);
        }

        public ElectricTruck(string i_NameOfModel, string i_NumberOfLicense, string i_NameOfWheelManufacturer, float[] i_WheelsAirPressures,
            float i_RemainingNumberOfHoursForLifeOfBattery,
            bool i_ContainsDangerousSubstances, float i_VolumeOfCargo)
            : base(i_NameOfModel, i_NumberOfLicense, i_WheelsAirPressures, i_NameOfWheelManufacturer, k_MaximumWheelAirPressure, i_RemainingNumberOfHoursForLifeOfBattery, k_MaximumNumberOfHoursForLifeTimeOfBattery)
        {
            if (i_WheelsAirPressures.Length != k_NumberOfWheels)
            {
                throw new ArgumentException("i_WheelsAirPressures.Length must be equal to " + k_NumberOfWheels + '.', "i_WheelsAirPressures.Length");
            }

            m_truck = new Truck(i_ContainsDangerousSubstances, i_VolumeOfCargo);
        }

        public ElectricTruck(TextReader i_TextReader)
            : base(i_TextReader, k_NumberOfWheels, k_MaximumWheelAirPressure, k_MaximumNumberOfHoursForLifeTimeOfBattery)
        {
            m_truck = new Truck(i_TextReader);
        }

        public ElectricTruck(TextReader i_TextReader, byte i_NumberOfWheels)
            : base(i_TextReader, i_NumberOfWheels, k_MaximumWheelAirPressure, k_MaximumNumberOfHoursForLifeTimeOfBattery)
        {
            m_truck = new Truck(i_TextReader);
        }

        public ElectricTruck(TextReader i_TextReader, float i_MaximumWheelAirPressure)
            : base(i_TextReader, k_NumberOfWheels, i_MaximumWheelAirPressure, k_MaximumNumberOfHoursForLifeTimeOfBattery)
        {
            m_truck = new Truck(i_TextReader);
        }

        public ElectricTruck(TextReader i_TextReader, byte i_NumberOfWheels, float i_MaximumWheelAirPressure)
            : base(i_TextReader, i_NumberOfWheels, i_MaximumWheelAirPressure, k_MaximumNumberOfHoursForLifeTimeOfBattery)
        {
            m_truck = new Truck(i_TextReader);
        }

        public override Vehicle.Information Info
        {
            get { return new Vehicle.Information(r_NumberOfLicense, r_NameOfModel, WheelsInformation, BatteryInformation, ExtendedInformation); }
        }

        public Truck.Information ExtendedInformation
        {
            get { return m_truck.Info; }
        }

        protected override StringBuilder ToStringBuilder()
        {
            StringBuilder stringBuilder = base.ToStringBuilder();
            stringBuilder.AppendLine(m_truck.ToString());

            return stringBuilder;
        }

        protected override StringWriter ToStringWriter()
        {
            StringWriter stringWriter = base.ToStringWriter();
            stringWriter.WriteLine(m_truck);

            return stringWriter;
        }

        public override string ToString()
        {
            return "Electric Truck" + Environment.NewLine + this.ToStringWriter().ToString();
        }
    }
}