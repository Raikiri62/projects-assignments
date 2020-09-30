namespace C19_Ex03_GarageLogic
{
    using System;
    using System.IO;
    using System.Text;
    using System.Collections.Generic;

    // $G$ DSN-999 (-5) no reason for partial
    public abstract partial class Vehicle
    {
        protected readonly string r_NameOfModel;
        protected readonly string r_NumberOfLicense;
        protected readonly Wheel[] r_Wheels;

        protected Vehicle(string i_NameOfModel, string i_NumberOfLicense, Wheel[] i_wheels, string i_NameOfWheelManufacturer, float i_MaximumWheelsAirPressure)
        {
            validate(i_NameOfModel, i_NumberOfLicense, i_wheels, i_NameOfWheelManufacturer);

            r_NameOfModel = i_NameOfModel;
            r_NumberOfLicense = i_NumberOfLicense;
            r_Wheels = i_wheels;

            for (byte i = 0; i < r_Wheels.Length; i++)
            {
                r_Wheels[i] = new Wheel(i_NameOfWheelManufacturer, i_MaximumWheelsAirPressure);
            }
        }

        protected Vehicle(string i_NameOfModel, string i_NumberOfLicense, Wheel[] i_wheels, string i_NameOfWheelManufacturer, float i_CurrentWheelsAirPressure, float i_MaximumWheelAirPressure)
        {
            validate(i_NameOfModel, i_NumberOfLicense, i_wheels, i_NameOfWheelManufacturer);

            if (float.IsNaN(i_CurrentWheelsAirPressure))
            {
                throw new ArgumentNaNException("i_CurrentAirPressure");
            }

            if (float.IsInfinity(i_CurrentWheelsAirPressure))
            {
                throw new ArgumentInfinityException("i_CurrentAirPressure");
            }

            if (i_CurrentWheelsAirPressure < 0f || i_CurrentWheelsAirPressure > i_MaximumWheelAirPressure)
            {
                throw new ValueOutOfRangeException("i_CurrentAirPressure", i_CurrentWheelsAirPressure, 0f, i_MaximumWheelAirPressure);
            }

            r_NameOfModel = i_NameOfModel;
            r_NumberOfLicense = i_NumberOfLicense;
            r_Wheels = i_wheels;

            for (byte i = 0; i < r_Wheels.Length; i++)
            {
                r_Wheels[i] = new Wheel(i_NameOfWheelManufacturer, i_CurrentWheelsAirPressure, i_MaximumWheelAirPressure);
            }
        }

        protected Vehicle(string i_NameOfModel, string i_NumberOfLicense, byte i_NumberOfWheels, string i_NameOfWheelManufacturer, float i_MaximumWheelAirPressure)
        {
            r_Wheels = new Wheel[i_NumberOfWheels];
            validate(i_NameOfModel, i_NumberOfLicense, r_Wheels, i_NameOfWheelManufacturer);

            r_NameOfModel = i_NameOfModel;
            r_NumberOfLicense = i_NumberOfLicense;

            for (byte i = 0; i < r_Wheels.Length; i++)
            {
                r_Wheels[i] = new Wheel(i_NameOfWheelManufacturer, i_MaximumWheelAirPressure);
            }
        }

        protected Vehicle(string i_NameOfModel, string i_NumberOfLicense, byte i_NumberOfWheels, string i_NameOfWheelManufacturer, float i_CurrentWheelsAirPressure, float i_MaximumWheelAirPressure)
        {
            r_Wheels = new Wheel[i_NumberOfWheels];
            validate(i_NameOfModel, i_NumberOfLicense, r_Wheels, i_NameOfWheelManufacturer);

            r_NameOfModel = i_NameOfModel;
            r_NumberOfLicense = i_NumberOfLicense;

            for (byte i = 0; i < r_Wheels.Length; i++)
            {
                r_Wheels[i] = new Wheel(i_NameOfWheelManufacturer, i_CurrentWheelsAirPressure, i_MaximumWheelAirPressure);
            }
        }

        protected Vehicle(string i_NameOfModel, string i_NumberOfLicense, float[] i_WheelsAirPressures, string i_NameOfWheelManufacturer, float i_MaximumWheelAirPressure)
        {
            r_Wheels = new Wheel[i_WheelsAirPressures.Length];
            validate(i_NameOfModel, i_NumberOfLicense, r_Wheels, i_NameOfWheelManufacturer);

            r_NameOfModel = i_NameOfModel;
            r_NumberOfLicense = i_NumberOfLicense;

            for (byte i = 0; i < r_Wheels.Length; i++)
            {
                if (float.IsNaN(i_WheelsAirPressures[i]))
                {
                    throw new ArgumentNaNException(string.Format("i_WheelsAirPressures[{0}]", i));
                }
                
                if (float.IsInfinity(i_WheelsAirPressures[i]))
                {
                    throw new ArgumentInfinityException(string.Format("i_WheelsAirPressures[{0}]", i));
                }

                if (i_WheelsAirPressures[i] < 0f || i_WheelsAirPressures[i] > i_MaximumWheelAirPressure)
                {
                    throw new ValueOutOfRangeException(string.Format("i_WheelsAirPressures[{0}]", i), i_WheelsAirPressures[i], 0f, i_MaximumWheelAirPressure);
                }

                r_Wheels[i] = new Wheel(i_NameOfWheelManufacturer, i_WheelsAirPressures[i], i_MaximumWheelAirPressure);
            }
        }

        protected Vehicle(TextReader i_TextReader)
        {
            if (i_TextReader == null)
            {
                throw new ArgumentNullException("i_TextReader", "i_TextReader must not be null.");
            }

            r_NameOfModel = i_TextReader.ReadLine();
            r_NumberOfLicense = i_TextReader.ReadLine();
            r_Wheels = new Wheel[byte.Parse(i_TextReader.ReadLine())];

            for (byte i = 0; i < r_Wheels.Length; i++)
            {
                r_Wheels[i] = new Wheel(i_TextReader);
            }
        }

        protected Vehicle(TextReader i_TextReader, byte i_NumberOfWheels)
        {
            if (i_TextReader == null)
            {
                throw new ArgumentNullException("i_TextReader", "i_TextReader must not be null.");
            }

            r_NameOfModel = i_TextReader.ReadLine();
            r_NumberOfLicense = i_TextReader.ReadLine();
            r_Wheels = new Wheel[i_NumberOfWheels];
        }

        protected Vehicle(TextReader i_TextReader, float i_MaximumWheelAirPressure)
        {
            if (i_TextReader == null)
            {
                throw new ArgumentNullException("i_TextReader", "i_TextReader must not be null.");
            }

            r_NameOfModel = i_TextReader.ReadLine();
            r_NumberOfLicense = i_TextReader.ReadLine();
            r_Wheels = new Wheel[byte.Parse(i_TextReader.ReadLine())];

            for (byte i = 0; i < r_Wheels.Length; i++)
            {
                r_Wheels[i] = new Wheel(i_TextReader, i_MaximumWheelAirPressure);
            }
        }

        protected Vehicle(TextReader i_TextReader, byte i_NumberOfWheels, float i_MaximumWheelAirPressure)
        {
            if (i_TextReader == null)
            {
                throw new ArgumentNullException("i_TextReader", "i_TextReader must not be null.");
            }

            r_NameOfModel = i_TextReader.ReadLine();
            r_NumberOfLicense = i_TextReader.ReadLine();
            r_Wheels = new Wheel[i_NumberOfWheels];

            for (byte i = 0; i < r_Wheels.Length; i++)
            {
                r_Wheels[i] = new Wheel(i_TextReader, i_MaximumWheelAirPressure);
            }
        }

        private void validate(string i_NameOfModel, string i_NumberOfLicense, Wheel[] i_Wheels, string i_NameOfWheelManufacturer)
        {
            if (i_NameOfModel == null)
            {
                throw new ArgumentNullException("i_NameOfModel", "i_NameOfModel must not be null.");
            }

            if (i_NameOfModel.Length == 0)
            {
                throw new ArgumentEmptyException("i_NameOfModel");
            }

            if (i_NumberOfLicense == null)
            {
                throw new ArgumentNullException("i_NumberOfLicense", "i_NumberOfLicense must not be null.");
            }

            if (i_NumberOfLicense.Length == 0)
            {
                throw new ArgumentEmptyException("i_NumberOfLicense");
            }

            if (i_Wheels == null)
            {
                throw new ArgumentNullException("i_Wheels", "i_wheels must not be null.");
            }

            if (i_Wheels.Length == 0)
            {
                throw new ArgumentEmptyException("i_Wheels");
            }

            if (i_NameOfWheelManufacturer == null)
            {
                throw new ArgumentNullException("i_NameOfWheelManufacturer", "i_NameOfWheelManufacturer must not be null.");
            }

            if (i_NameOfWheelManufacturer.Length == 0)
            {
                throw new ArgumentEmptyException("i_NameOfWheelManufacturer");
            }
        }

        public string NameOfModel
        {
            get { return r_NameOfModel; }
        }

        public string NumberOfLicense
        {
            get { return r_NumberOfLicense; }
        }

        public abstract float EnergyPercentageRemaining { get; }

        public Wheel[] Wheels
        {
            get { return r_Wheels; }
        }

        public long NumberOfWheels
        {
            get { return r_Wheels.LongLength; }
        }

        public void InflateAllWheelsToTheirMaximum()
        {
            for (long i = 0; i < r_Wheels.Length; i++)
            {
                r_Wheels[i].InflateToMaximum();
            }
        }

        public abstract Information Info { get; }

        public IEnumerable<Wheel.Information> WheelsInformation
        {
            get
            {
                foreach (Wheel currentWheel in r_Wheels)
                {
                    yield return currentWheel.Info;
                }
            }
        }

        public string NameOfWheelManufacturer
        {
            get
            {
                return r_Wheels[0].NameOfManufacturer;
            }
        }

        public static byte GetNumberOfWheelsOf(Vehicle.eVehicle i_Vehicle)
        {
            byte answer;
            switch (i_Vehicle)
            {
                case Vehicle.eVehicle.CarThatOperatesOnFuel:
                   answer = CarThatOperatesOnFuel.k_NumberOfWheels;
                break;
                case Vehicle.eVehicle.ElectricCar:
                   answer = ElectricCar.k_NumberOfWheels;
                break;
                case Vehicle.eVehicle.ElectricMotorcycle:
                   answer = ElectricMotorcycle.k_NumberOfWheels;
                break;
                case Vehicle.eVehicle.ElectricTruck:
                   answer = ElectricTruck.k_NumberOfWheels;
                break;
                case Vehicle.eVehicle.MotorcycleThatOperatesOnFuel:
                   answer = MotorcycleThatOperatesOnFuel.k_NumberOfWheels;
                break;
                case Vehicle.eVehicle.TruckThatOperatesOnFuel:
                   answer = TruckThatOperatesOnFuel.k_NumberOfWheels;
                break;
                default:
                   throw new UnreachableCodeReachedException();
            }

            return answer;
        }

        public static float GetMaximumWheelAirPressureOf(Vehicle.eVehicle i_Vehicle)
        {
            float answer;
            switch (i_Vehicle)
            {
                case Vehicle.eVehicle.CarThatOperatesOnFuel:
                    answer = CarThatOperatesOnFuel.k_MaximumWheelAirPressure;
                break;
                case Vehicle.eVehicle.ElectricCar:
                    answer = ElectricCar.k_MaximumWheelAirPressure;
                break;
                case Vehicle.eVehicle.ElectricMotorcycle:
                    answer = ElectricMotorcycle.k_MaximumWheelAirPressure;
                break;
                case Vehicle.eVehicle.MotorcycleThatOperatesOnFuel:
                    answer = MotorcycleThatOperatesOnFuel.k_MaximumWheelAirPressure;
                break;
                case Vehicle.eVehicle.TruckThatOperatesOnFuel:
                    answer = TruckThatOperatesOnFuel.k_MaximumWheelAirPressure;
                break;
                case Vehicle.eVehicle.ElectricTruck:
                    answer = ElectricTruck.k_MaximumWheelAirPressure;
                break;
                default:
                   throw new UnreachableCodeReachedException();
            }

            return answer;
        }

        protected virtual StringBuilder ToStringBuilder()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(r_NameOfModel);
            stringBuilder.AppendLine(r_NumberOfLicense);
            stringBuilder.AppendLine(NameOfWheelManufacturer);

            return stringBuilder;
        }

        protected virtual StringWriter ToStringWriter()
        {
            StringWriter stringWriter = new StringWriter();
            stringWriter.WriteLine(r_NameOfModel);
            stringWriter.WriteLine(r_NumberOfLicense);
            stringWriter.WriteLine(NameOfWheelManufacturer);

            return stringWriter;
        }

        public override string ToString()
        {
            return ToStringWriter().ToString();
        }
    }
}
