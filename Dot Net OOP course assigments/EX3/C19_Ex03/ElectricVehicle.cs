namespace C19_Ex03_GarageLogic
{
    using System;
    using System.IO;
    using System.Text;
    using System.Collections.Generic;

    public abstract partial class ElectricVehicle : Vehicle
    {
        protected float m_RemainingNumberOfHoursForLifeTimeOfBattery;
        protected readonly float r_MaximumNumberOfHoursForLifeTimeOfBattery;

        public float RemainingNumberOfHoursForLifeTimeOfBattery
        {
            get { return m_RemainingNumberOfHoursForLifeTimeOfBattery; }
        }

        public float MaximumNumberOfHoursForLifeTimeOfBattery
        {
            get { return r_MaximumNumberOfHoursForLifeTimeOfBattery; }
        }

        protected ElectricVehicle(string i_NameOfModel, string i_NumberOfLicense, Wheel[] i_wheels,
            string i_NameOfWheelManufacturer, float i_MaximumWheelAirPressure,
            float i_MaximumNumberOfHoursForLifeTimeOfBattery)
            : base(i_NameOfModel, i_NumberOfLicense, i_wheels, i_NameOfWheelManufacturer, i_MaximumWheelAirPressure)
        {
            validate(i_MaximumNumberOfHoursForLifeTimeOfBattery);

            m_RemainingNumberOfHoursForLifeTimeOfBattery = i_MaximumNumberOfHoursForLifeTimeOfBattery;
            r_MaximumNumberOfHoursForLifeTimeOfBattery = i_MaximumNumberOfHoursForLifeTimeOfBattery;
        }

        protected ElectricVehicle(string i_NameOfModel, string i_NumberOfLicense, Wheel[] i_wheels,
            string i_NameOfWheelManufacturer, float i_MaximumWheelAirPressure,
            float i_RemainingNumberOfHoursForLifeTimeOfBattery, float i_MaximumNumberOfHoursForLifeTimeOfBattery)
            : base(i_NameOfModel, i_NumberOfLicense, i_wheels, i_NameOfWheelManufacturer, i_MaximumWheelAirPressure)
        {
            validate(i_RemainingNumberOfHoursForLifeTimeOfBattery, i_MaximumNumberOfHoursForLifeTimeOfBattery);

            m_RemainingNumberOfHoursForLifeTimeOfBattery = i_RemainingNumberOfHoursForLifeTimeOfBattery;
            r_MaximumNumberOfHoursForLifeTimeOfBattery = i_MaximumNumberOfHoursForLifeTimeOfBattery;
        }

        protected ElectricVehicle(string i_NameOfModel, string i_NumberOfLicense, byte i_NumberOfWheels,
            string i_NameOfWheelManufacturer, float i_MaximumWheelAirPressure,
            float i_MaximumNumberOfHoursForLifeTimeOfBattery)
            : base(i_NameOfModel, i_NumberOfLicense, i_NumberOfWheels, i_NameOfWheelManufacturer, i_MaximumWheelAirPressure)
        {
            validate(i_MaximumNumberOfHoursForLifeTimeOfBattery);

            m_RemainingNumberOfHoursForLifeTimeOfBattery = i_MaximumNumberOfHoursForLifeTimeOfBattery;
            r_MaximumNumberOfHoursForLifeTimeOfBattery = i_MaximumNumberOfHoursForLifeTimeOfBattery;
        }

        protected ElectricVehicle(string i_NameOfModel, string i_NumberOfLicense, byte i_NumberOfWheels,
            string i_NameOfWheelManufacturer, float i_MaximumWheelAirPressure,
            float i_RemainingNumberOfHoursForLifeTimeOfBattery, float i_MaximumNumberOfHoursForLifeTimeOfBattery)
            : base(i_NameOfModel, i_NumberOfLicense, i_NumberOfWheels, i_NameOfWheelManufacturer, i_MaximumWheelAirPressure)
        {
            validate(i_RemainingNumberOfHoursForLifeTimeOfBattery, i_MaximumNumberOfHoursForLifeTimeOfBattery);

            m_RemainingNumberOfHoursForLifeTimeOfBattery = i_RemainingNumberOfHoursForLifeTimeOfBattery;
            r_MaximumNumberOfHoursForLifeTimeOfBattery = i_MaximumNumberOfHoursForLifeTimeOfBattery;
        }

        protected ElectricVehicle(string i_NameOfModel, string i_NumberOfLicense, float[] i_WheelsAirPressures,
            string i_NameOfWheelManufacturer, float i_MaximumWheelAirPressure,
            float i_MaximumNumberOfHoursForLifeTimeOfBattery)
            : base(i_NameOfModel, i_NumberOfLicense, i_WheelsAirPressures, i_NameOfWheelManufacturer, i_MaximumWheelAirPressure)
        {
            validate(i_MaximumNumberOfHoursForLifeTimeOfBattery);

            m_RemainingNumberOfHoursForLifeTimeOfBattery = i_MaximumNumberOfHoursForLifeTimeOfBattery;
            r_MaximumNumberOfHoursForLifeTimeOfBattery = i_MaximumNumberOfHoursForLifeTimeOfBattery;
        }

        protected ElectricVehicle(string i_NameOfModel, string i_NumberOfLicense, float[] i_WheelsAirPressures,
            string i_NameOfWheelManufacturer, float i_MaximumWheelAirPressure,
            float i_RemainingNumberOfHoursForLifeTimeOfBattery, float i_MaximumNumberOfHoursForLifeTimeOfBattery)
            : base(i_NameOfModel, i_NumberOfLicense, i_WheelsAirPressures, i_NameOfWheelManufacturer, i_MaximumWheelAirPressure)
        {
            validate(i_RemainingNumberOfHoursForLifeTimeOfBattery, i_MaximumNumberOfHoursForLifeTimeOfBattery);

            m_RemainingNumberOfHoursForLifeTimeOfBattery = i_RemainingNumberOfHoursForLifeTimeOfBattery;
            r_MaximumNumberOfHoursForLifeTimeOfBattery = i_MaximumNumberOfHoursForLifeTimeOfBattery;
        }

        protected ElectricVehicle(TextReader i_TextReader) : base(i_TextReader)
        {
            if (i_TextReader == null)
            {
                throw new ArgumentNullException("i_TextReader", "i_TextReader must not be null.");
            }

            m_RemainingNumberOfHoursForLifeTimeOfBattery = float.Parse(i_TextReader.ReadLine());
            r_MaximumNumberOfHoursForLifeTimeOfBattery = float.Parse(i_TextReader.ReadLine());

            validate(m_RemainingNumberOfHoursForLifeTimeOfBattery, r_MaximumNumberOfHoursForLifeTimeOfBattery);
        }

        protected ElectricVehicle(TextReader i_TextReader, byte i_NumberOfWheels) : base(i_TextReader, i_NumberOfWheels)
        {
            if (i_TextReader == null)
            {
                throw new ArgumentNullException("i_TextReader", "i_TextReader must not be null.");
            }

            m_RemainingNumberOfHoursForLifeTimeOfBattery = float.Parse(i_TextReader.ReadLine());
            r_MaximumNumberOfHoursForLifeTimeOfBattery = float.Parse(i_TextReader.ReadLine());

            validate(m_RemainingNumberOfHoursForLifeTimeOfBattery, r_MaximumNumberOfHoursForLifeTimeOfBattery);
        }

        protected ElectricVehicle(TextReader i_TextReader, float i_MaximumWheelAirPressure) : base(i_TextReader, i_MaximumWheelAirPressure)
        {
            if (i_TextReader == null)
            {
                throw new ArgumentNullException("i_TextReader", "i_TextReader must not be null.");
            }

            m_RemainingNumberOfHoursForLifeTimeOfBattery = float.Parse(i_TextReader.ReadLine());
            r_MaximumNumberOfHoursForLifeTimeOfBattery = float.Parse(i_TextReader.ReadLine());

            validate(m_RemainingNumberOfHoursForLifeTimeOfBattery, r_MaximumNumberOfHoursForLifeTimeOfBattery);
        }

        protected ElectricVehicle(TextReader i_TextReader, byte i_NumberOfWheels, float i_MaximumWheelAirPressure) : base(i_TextReader, i_NumberOfWheels, i_MaximumWheelAirPressure)
        {
            if (i_TextReader == null)
            {
                throw new ArgumentNullException("i_TextReader", "i_TextReader must not be null.");
            }

            m_RemainingNumberOfHoursForLifeTimeOfBattery = float.Parse(i_TextReader.ReadLine());
            r_MaximumNumberOfHoursForLifeTimeOfBattery = float.Parse(i_TextReader.ReadLine());

            validate(m_RemainingNumberOfHoursForLifeTimeOfBattery, r_MaximumNumberOfHoursForLifeTimeOfBattery);
        }

        protected ElectricVehicle(TextReader i_TextReader, byte i_NumberOfWheels, float i_MaximumWheelAirPressure,
            float i_MaximumNumberOfHoursForLifeTimeOfBattery) : base(i_TextReader, i_NumberOfWheels, i_MaximumWheelAirPressure)
        {
            if (i_TextReader == null)
            {
                throw new ArgumentNullException("i_TextReader", "i_TextReader must not be null.");
            }

            m_RemainingNumberOfHoursForLifeTimeOfBattery = float.Parse(i_TextReader.ReadLine());
            r_MaximumNumberOfHoursForLifeTimeOfBattery = i_MaximumNumberOfHoursForLifeTimeOfBattery;

            validate(m_RemainingNumberOfHoursForLifeTimeOfBattery, i_MaximumNumberOfHoursForLifeTimeOfBattery);
        }

        protected ElectricVehicle(TextReader i_TextReader, byte i_NumberOfWheels, float i_MaximumWheelAirPressure,
            float i_RemainingNumberOfHoursForLifeTimeOfBattery, float i_MaximumNumberOfHoursForLifeTimeOfBattery) : base(i_TextReader, i_NumberOfWheels, i_MaximumWheelAirPressure)
        {
            if (i_TextReader == null)
            {
                throw new ArgumentNullException("i_TextReader", "i_TextReader must not be null.");
            }

            m_RemainingNumberOfHoursForLifeTimeOfBattery = i_RemainingNumberOfHoursForLifeTimeOfBattery;
            r_MaximumNumberOfHoursForLifeTimeOfBattery = i_MaximumNumberOfHoursForLifeTimeOfBattery;

            validate(i_RemainingNumberOfHoursForLifeTimeOfBattery, i_MaximumNumberOfHoursForLifeTimeOfBattery);
        }

        private static void validate(float i_MaximumNumberOfHoursForLifeTimeOfBattery)
        {
            if (float.IsNaN(i_MaximumNumberOfHoursForLifeTimeOfBattery))
            {
                throw new ArgumentNaNException("i_MaximumNumberOfHoursForLifeTimeOfBattery");
            }

            if (float.IsInfinity(i_MaximumNumberOfHoursForLifeTimeOfBattery))
            {
                throw new ArgumentInfinityException("i_MaximumNumberOfHoursForLifeTimeOfBattery");
            }

            if (i_MaximumNumberOfHoursForLifeTimeOfBattery <= 0f)
            {
                throw new ArgumentIsNotPositiveNumberException("i_MaximumNumberOfHoursForLifeTimeOfBattery", i_MaximumNumberOfHoursForLifeTimeOfBattery);
            }
        }

        private static void validate(float i_RemainingNumberOfHoursForLifeTimeOfBattery, float i_MaximumNumberOfHoursForLifeTimeOfBattery)
        {
            validate(i_MaximumNumberOfHoursForLifeTimeOfBattery);

            if (float.IsNaN(i_RemainingNumberOfHoursForLifeTimeOfBattery))
            {
                throw new ArgumentNaNException("i_RemainingNumberOfHoursForLifeTimeOfBattery");
            }

            if (float.IsInfinity(i_RemainingNumberOfHoursForLifeTimeOfBattery))
            {
                throw new ArgumentInfinityException("i_RemainingNumberOfHoursForLifeTimeOfBattery");
            }

            if (i_RemainingNumberOfHoursForLifeTimeOfBattery < 0f || i_RemainingNumberOfHoursForLifeTimeOfBattery > i_MaximumNumberOfHoursForLifeTimeOfBattery)
            {
                throw new ValueOutOfRangeException("i_RemainingNumberOfHoursForLifeTimeOfBattery", i_RemainingNumberOfHoursForLifeTimeOfBattery,
                    0f, i_MaximumNumberOfHoursForLifeTimeOfBattery);
            }
        }

        public override float EnergyPercentageRemaining
        {
            get { return (m_RemainingNumberOfHoursForLifeTimeOfBattery / r_MaximumNumberOfHoursForLifeTimeOfBattery) * 100f; }
        }

        public ElectricVehicle.eChargeStatus Charge(float i_NumberOfHoursToAddToLifeTimeOfBattery, bool i_ThrowProperExceptionOnError = true)
        {
            ElectricVehicle.eChargeStatus status;
            if (float.IsNaN(i_NumberOfHoursToAddToLifeTimeOfBattery))
            {
                if (i_ThrowProperExceptionOnError)
                {
                    throw new ArgumentNaNException("i_NumberOfHoursToAddToLifeTimeOfBattery");
                }
                status = ElectricVehicle.eChargeStatus.NumberOfHoursToAddToLifeTimeOfBatteryIsNaN;
            }
            else if (float.IsInfinity(i_NumberOfHoursToAddToLifeTimeOfBattery))
            {
                if (i_ThrowProperExceptionOnError)
                {
                    throw new ArgumentInfinityException("i_NumberOfHoursToAddToLifeTimeOfBattery");
                }
                status = ElectricVehicle.eChargeStatus.NumberOfHoursToAddToLifeTimeOfBatteryIsInfinity;
            }
            else if (i_NumberOfHoursToAddToLifeTimeOfBattery <= 0)
            {
                if (i_ThrowProperExceptionOnError)
                {
                    throw new ArgumentIsNotPositiveNumberException("i_NumberOfHoursToAddToLifeTimeOfBattery",
                        i_NumberOfHoursToAddToLifeTimeOfBattery, r_MaximumNumberOfHoursForLifeTimeOfBattery - m_RemainingNumberOfHoursForLifeTimeOfBattery);
                }
                status = ElectricVehicle.eChargeStatus.NumberOfHoursToAddToLifeTimeOfBatteryIsNotPositive;
            }
            else if (m_RemainingNumberOfHoursForLifeTimeOfBattery + i_NumberOfHoursToAddToLifeTimeOfBattery > r_MaximumNumberOfHoursForLifeTimeOfBattery)
            {
                if (i_ThrowProperExceptionOnError)
                {
                    const bool v_IncludeMin = true;
                    throw new ValueOutOfRangeException("i_NumberOfHoursToAddToLifeTimeOfBattery", i_NumberOfHoursToAddToLifeTimeOfBattery,
                        0f, r_MaximumNumberOfHoursForLifeTimeOfBattery - m_RemainingNumberOfHoursForLifeTimeOfBattery, not(v_IncludeMin));
                }
                status = ElectricVehicle.eChargeStatus.Overflow;
            }
            else
            {
                m_RemainingNumberOfHoursForLifeTimeOfBattery += i_NumberOfHoursToAddToLifeTimeOfBattery;
                status = ElectricVehicle.eChargeStatus.Success;
            }
            
            return status;
        }

        public ElectricVehicle.Information BatteryInformation
        {
            get { return new ElectricVehicle.Information(m_RemainingNumberOfHoursForLifeTimeOfBattery, r_MaximumNumberOfHoursForLifeTimeOfBattery); }
        }

        private bool not(bool i_boolean)
        {
            return !i_boolean;
        }

        protected override StringBuilder ToStringBuilder()
        {
            StringBuilder stringBuilder = base.ToStringBuilder();
            return stringBuilder;
        }

        protected override StringWriter ToStringWriter()
        {
            StringWriter stringWriter = base.ToStringWriter();
            return stringWriter;
        }

        public override string ToString()
        {
            return this.ToStringWriter().ToString();
        }
    }
}