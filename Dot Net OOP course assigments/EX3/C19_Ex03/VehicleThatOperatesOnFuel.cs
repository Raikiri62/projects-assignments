namespace C19_Ex03_GarageLogic
{
    using System;
    using System.IO;
    using System.Text;
    using System.Collections.Generic;

    public abstract partial class VehicleThatOperatesOnFuel : Vehicle
    {
        protected readonly VehicleThatOperatesOnFuel.eTypeOfFuel r_TypeOfFuel;
        protected float m_RemainingAmountOfFuelInTheTank;
        protected readonly float r_CapacityOfTank;

        public VehicleThatOperatesOnFuel.eTypeOfFuel TypeOfFuel
        {
            get { return r_TypeOfFuel; }
        }

        public float RemainingAmountOfFuelInTheTank
        {
            get { return m_RemainingAmountOfFuelInTheTank; }
        }

        public float CapacityOfTank
        {
            get { return r_CapacityOfTank; }
        }

        protected VehicleThatOperatesOnFuel(string i_NameOfModel, string i_NumberOfLicense, Wheel[] i_wheels,
            string i_NameOfWheelManufacturer, float i_MaximumWheelAirPressure,
            VehicleThatOperatesOnFuel.eTypeOfFuel i_TypeOfFuel, float i_CapacityOfTank)
            : base(i_NameOfModel, i_NumberOfLicense, i_wheels, i_NameOfWheelManufacturer, i_MaximumWheelAirPressure)
        {
            validate(i_CapacityOfTank);

            r_TypeOfFuel = i_TypeOfFuel;
            m_RemainingAmountOfFuelInTheTank = i_CapacityOfTank;
            r_CapacityOfTank = i_CapacityOfTank;
        }

        protected VehicleThatOperatesOnFuel(string i_NameOfModel, string i_NumberOfLicense, Wheel[] i_wheels,
            string i_NameOfWheelManufacturer, float i_MaximumWheelAirPressure,
            VehicleThatOperatesOnFuel.eTypeOfFuel i_TypeOfFuel, float i_RemainingAmountOfFuelInTheTank, float i_CapacityOfTank)
            : base(i_NameOfModel, i_NumberOfLicense, i_wheels, i_NameOfWheelManufacturer, i_MaximumWheelAirPressure)
        {
            validate(i_CapacityOfTank, i_RemainingAmountOfFuelInTheTank);

            r_TypeOfFuel = i_TypeOfFuel;
            m_RemainingAmountOfFuelInTheTank = i_RemainingAmountOfFuelInTheTank;
            r_CapacityOfTank = i_CapacityOfTank;
        }

        protected VehicleThatOperatesOnFuel(string i_NameOfModel, string i_NumberOfLicense, byte i_NumberOfWheels,
            string i_NameOfWheelManufacturer, float i_MaximumWheelAirPressure,
            VehicleThatOperatesOnFuel.eTypeOfFuel i_TypeOfFuel, float i_CapacityOfTank)
            : base(i_NameOfModel, i_NumberOfLicense, i_NumberOfWheels, i_NameOfWheelManufacturer, i_MaximumWheelAirPressure)
        {
            validate(i_CapacityOfTank);

            r_TypeOfFuel = i_TypeOfFuel;
            m_RemainingAmountOfFuelInTheTank = i_CapacityOfTank;
            r_CapacityOfTank = i_CapacityOfTank;
        }

        protected VehicleThatOperatesOnFuel(string i_NameOfModel, string i_NumberOfLicense, byte i_NumberOfWheels,
            string i_NameOfWheelManufacturer, float i_MaximumWheelAirPressure,
            VehicleThatOperatesOnFuel.eTypeOfFuel i_TypeOfFuel, float i_RemainingAmountOfFuelInTheTank, float i_CapacityOfTank)
            : base(i_NameOfModel, i_NumberOfLicense, i_NumberOfWheels, i_NameOfWheelManufacturer, i_MaximumWheelAirPressure)
        {
            validate(i_CapacityOfTank, i_RemainingAmountOfFuelInTheTank);

            r_TypeOfFuel = i_TypeOfFuel;
            m_RemainingAmountOfFuelInTheTank = i_RemainingAmountOfFuelInTheTank;
            r_CapacityOfTank = i_CapacityOfTank;
        }

        protected VehicleThatOperatesOnFuel(string i_NameOfModel, string i_NumberOfLicense, float[] i_WheelsAirPressures,
            string i_NameOfWheelManufacturer, float i_MaximumWheelAirPressure,
            VehicleThatOperatesOnFuel.eTypeOfFuel i_TypeOfFuel, float i_CapacityOfTank)
            : base(i_NameOfModel, i_NumberOfLicense, i_WheelsAirPressures, i_NameOfWheelManufacturer, i_MaximumWheelAirPressure)
        {
            validate(i_CapacityOfTank);

            r_TypeOfFuel = i_TypeOfFuel;
            m_RemainingAmountOfFuelInTheTank = i_CapacityOfTank;
            r_CapacityOfTank = i_CapacityOfTank;
        }

        protected VehicleThatOperatesOnFuel(string i_NameOfModel, string i_NumberOfLicense, float[] i_WheelsAirPressures,
            string i_NameOfWheelManufacturer, float i_MaximumWheelAirPressure,
            VehicleThatOperatesOnFuel.eTypeOfFuel i_TypeOfFuel, float i_RemainingAmountOfFuelInTheTank, float i_CapacityOfTank)
            : base(i_NameOfModel, i_NumberOfLicense, i_WheelsAirPressures, i_NameOfWheelManufacturer, i_MaximumWheelAirPressure)
        {
            validate(i_CapacityOfTank, i_RemainingAmountOfFuelInTheTank);

            r_TypeOfFuel = i_TypeOfFuel;
            m_RemainingAmountOfFuelInTheTank = i_RemainingAmountOfFuelInTheTank;
            r_CapacityOfTank = i_CapacityOfTank;
        }

        protected VehicleThatOperatesOnFuel(TextReader i_TextReader) : base(i_TextReader)
        {
            if (i_TextReader == null)
            {
                throw new ArgumentNullException("i_TextReader", "i_TextReader must not be null.");
            }

            r_TypeOfFuel = Enum<VehicleThatOperatesOnFuel.eTypeOfFuel>.Parse(i_TextReader.ReadLine());
            m_RemainingAmountOfFuelInTheTank = float.Parse(i_TextReader.ReadLine());
            r_CapacityOfTank = float.Parse(i_TextReader.ReadLine());

            validate(m_RemainingAmountOfFuelInTheTank, r_CapacityOfTank);
        }

        protected VehicleThatOperatesOnFuel(TextReader i_TextReader, byte i_NumberOfWheels) : base(i_TextReader, i_NumberOfWheels)
        {
            if (i_TextReader == null)
            {
                throw new ArgumentNullException("i_TextReader", "i_TextReader must not be null.");
            }

            r_TypeOfFuel = Enum<VehicleThatOperatesOnFuel.eTypeOfFuel>.Parse(i_TextReader.ReadLine());
            m_RemainingAmountOfFuelInTheTank = float.Parse(i_TextReader.ReadLine());
            r_CapacityOfTank = float.Parse(i_TextReader.ReadLine());

            validate(m_RemainingAmountOfFuelInTheTank, r_CapacityOfTank);
        }

        protected VehicleThatOperatesOnFuel(TextReader i_TextReader, float i_MaximumWheelAirPressure) : base(i_TextReader, i_MaximumWheelAirPressure)
        {
            if (i_TextReader == null)
            {
                throw new ArgumentNullException("i_TextReader", "i_TextReader must not be null.");
            }

            r_TypeOfFuel = Enum<VehicleThatOperatesOnFuel.eTypeOfFuel>.Parse(i_TextReader.ReadLine());
            m_RemainingAmountOfFuelInTheTank = float.Parse(i_TextReader.ReadLine());
            r_CapacityOfTank = float.Parse(i_TextReader.ReadLine());

            validate(m_RemainingAmountOfFuelInTheTank, r_CapacityOfTank);
        }

        protected VehicleThatOperatesOnFuel(TextReader i_TextReader, byte i_NumberOfWheels, float i_MaximumWheelAirPressure) : base(i_TextReader, i_NumberOfWheels, i_MaximumWheelAirPressure)
        {
            if (i_TextReader == null)
            {
                throw new ArgumentNullException("i_TextReader", "i_TextReader must not be null.");
            }

            r_TypeOfFuel = Enum<VehicleThatOperatesOnFuel.eTypeOfFuel>.Parse(i_TextReader.ReadLine());
            m_RemainingAmountOfFuelInTheTank = float.Parse(i_TextReader.ReadLine());
            r_CapacityOfTank = float.Parse(i_TextReader.ReadLine());

            validate(m_RemainingAmountOfFuelInTheTank, r_CapacityOfTank);
        }

        protected VehicleThatOperatesOnFuel(TextReader i_TextReader, byte i_NumberOfWheels, float i_MaximumWheelAirPressure,
            VehicleThatOperatesOnFuel.eTypeOfFuel i_TypeOfFuel, float i_CapacityOfTank)
            : base(i_TextReader, i_NumberOfWheels, i_MaximumWheelAirPressure)
        {
            if (i_TextReader == null)
            {
                throw new ArgumentNullException("i_TextReader", "i_TextReader must not be null.");
            }

            r_TypeOfFuel = i_TypeOfFuel;
            m_RemainingAmountOfFuelInTheTank = float.Parse(i_TextReader.ReadLine());
            r_CapacityOfTank = i_CapacityOfTank;

            validate(m_RemainingAmountOfFuelInTheTank, i_CapacityOfTank);
        }

        protected VehicleThatOperatesOnFuel(TextReader i_TextReader, byte i_NumberOfWheels, float i_MaximumWheelAirPressure,
            VehicleThatOperatesOnFuel.eTypeOfFuel i_TypeOfFuel, float i_RemainingAmountOfFuel, float i_CapacityOfTank)
            : base(i_TextReader, i_NumberOfWheels, i_MaximumWheelAirPressure)
        {
            if (i_TextReader == null)
            {
                throw new ArgumentNullException("i_TextReader", "i_TextReader must not be null.");
            }

            r_TypeOfFuel = i_TypeOfFuel;
            m_RemainingAmountOfFuelInTheTank = i_RemainingAmountOfFuel;
            r_CapacityOfTank = i_CapacityOfTank;

            validate(i_CapacityOfTank, i_RemainingAmountOfFuel);
        }

        private static void validate(float i_CapacityOfTank)
        {
            if (float.IsNaN(i_CapacityOfTank))
            {
                throw new ArgumentNaNException("i_CapacityOfTank");
            }

            if (float.IsInfinity(i_CapacityOfTank))
            {
                throw new ArgumentInfinityException("i_CapacityOfTank");
            }

            if (i_CapacityOfTank <= 0f)
            {
                throw new ArgumentIsNotPositiveNumberException("i_CapacityOfTank", i_CapacityOfTank);
            }
        }

        private static void validate(float i_CapacityOfTank, float i_RemainingAmountOfFuelInTheTank)
        {
            validate(i_CapacityOfTank);

            if (float.IsNaN(i_RemainingAmountOfFuelInTheTank))
            {
                throw new ArgumentNaNException("i_RemainingAmountOfFuelInTheTank");
            }

            if (float.IsInfinity(i_RemainingAmountOfFuelInTheTank))
            {
                throw new ArgumentInfinityException("i_RemainingAmountOfFuelInTheTank");
            }

            if (i_RemainingAmountOfFuelInTheTank < 0f || i_RemainingAmountOfFuelInTheTank > i_CapacityOfTank)
            {
                throw new ValueOutOfRangeException("i_RemainingAmountOfFuelInTheTank", i_RemainingAmountOfFuelInTheTank, 0f, i_CapacityOfTank);
            }
        }

        public override float EnergyPercentageRemaining
        {
            get { return (m_RemainingAmountOfFuelInTheTank / r_CapacityOfTank) * 100f; }
        }

        public eRefuelStatus Refuel(float i_AmountOfFuelToAdd, eTypeOfFuel i_TypeOfFuel, bool i_ThrowException = true)
        {
            eRefuelStatus status;
            if (float.IsNaN(i_AmountOfFuelToAdd))
            {
                if (i_ThrowException)
                {
                    throw new ArgumentNaNException("i_AmountOfFuelToAdd");
                }
                status = eRefuelStatus.AmountOfFuelToAddIsNaN;
            }
            else if (float.IsInfinity(i_AmountOfFuelToAdd))
            {
                if (i_ThrowException)
                {
                    throw new ArgumentInfinityException("i_AmountOfFuelToAdd");
                }
                status = eRefuelStatus.AmountOfFuelToAddIsInfinity;
            }
            else
            {
                if (i_TypeOfFuel != r_TypeOfFuel)
                {
                    status = eRefuelStatus.TypesOfFuelsAreIncompatible;
                }
                else if (m_RemainingAmountOfFuelInTheTank + i_AmountOfFuelToAdd > r_CapacityOfTank)
                {
                    status = eRefuelStatus.FuelTankOverflow;
                }
                else
                {
                    m_RemainingAmountOfFuelInTheTank += i_AmountOfFuelToAdd;
                    status = eRefuelStatus.Success;
                }
            }

            return status;
        }

        public VehicleThatOperatesOnFuel.Information FuelInformation
        {
            get { return new VehicleThatOperatesOnFuel.Information(m_RemainingAmountOfFuelInTheTank, r_CapacityOfTank, r_TypeOfFuel); }
        }

        protected override StringBuilder ToStringBuilder()
        {
            StringBuilder stringBuilder = base.ToStringBuilder();
            stringBuilder.AppendLine(r_TypeOfFuel.ToString());

            return stringBuilder;
        }

        protected override StringWriter ToStringWriter()
        {
            StringWriter stringWriter = base.ToStringWriter();
            stringWriter.WriteLine(r_TypeOfFuel);

            return stringWriter;
        }

        public override string ToString()
        {
            return this.ToStringWriter().ToString();
        }
    }
}