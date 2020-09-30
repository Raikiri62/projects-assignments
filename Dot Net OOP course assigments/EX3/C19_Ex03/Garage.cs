namespace C19_Ex03_GarageLogic
{
    using System;
    using System.IO;
    using System.Text;
    using System.Collections.Generic;

    public partial class Garage
    {
        private const string k_StringFuelCar            = "Fuel Car";
        private const string k_StringElectricCar        = "Electric Car";
        private const string k_StringFuelMotorcycle     = "Fuel Motorcycle";
        private const string k_StringElectricMotorcycle = "Electric Motorcycle";
        private const string k_StringFuelTruck          = "Fuel Truck";
        private const string k_StringElectricTruck      = "Electric Truck";

        private IDictionary<string, Garage.Vehicle> m_VehiclesInGarage = new Dictionary<string, Garage.Vehicle>();
        private Garage.Vehicle m_CurrentVehicleInUse = null;

        public Garage()
        {
        }

        public Garage(string i_TextFileNameOfVehicles)
        {
            ReadFrom(i_TextFileNameOfVehicles);
        }

        public Garage(StreamReader i_StreamReader)
        {
            ReadFrom(i_StreamReader);
        }

        public void ReadFrom(string i_TextFileNameOfVehicles)
        {
            if (i_TextFileNameOfVehicles == null)
            {
                throw new ArgumentNullException("i_TextFileNameOfVehicles", "i_TextFileNameOfVehicles must not be null.");
            }

            if (not(File.Exists(i_TextFileNameOfVehicles)))
            {
                throw new FileNotFoundException("The file " + '"' + i_TextFileNameOfVehicles + '"' + " does not exist.", i_TextFileNameOfVehicles);
            }

            ReadFrom(File.OpenText(i_TextFileNameOfVehicles));
        }

        public void ReadFrom(StreamReader i_StreamReader)
        {
            while (not(i_StreamReader.EndOfStream))
            {
                string readLine = i_StreamReader.ReadLine();
                C19_Ex03_GarageLogic.Vehicle vehicle;
                switch (readLine)
                {
                    case k_StringFuelCar:
                        vehicle = new CarThatOperatesOnFuel(i_StreamReader);
                    break;
                    case k_StringElectricCar:
                        vehicle = new ElectricCar(i_StreamReader);
                    break;
                    case k_StringFuelMotorcycle:
                        vehicle = new MotorcycleThatOperatesOnFuel(i_StreamReader);
                    break;
                    case k_StringElectricMotorcycle:
                        vehicle = new ElectricMotorcycle(i_StreamReader);
                    break;
                    case k_StringFuelTruck:
                        vehicle = new TruckThatOperatesOnFuel(i_StreamReader);
                    break;
                        /*
                    case k_StringElectricTruck:
                        vehicle = new ElectricTruck(i_StreamReader);
                    break;
                        */
                    default:
                        throw new NotSupportedException("The garage does not support vehicle of type " + '"' + readLine + '"');
                }

                for (long i = 0; i < vehicle.Wheels.Length; i++)
                {
                    vehicle.Wheels[i].CurrentAirPressure = float.Parse(i_StreamReader.ReadLine());
                }

                Enter(vehicle, i_StreamReader.ReadLine(), i_StreamReader.ReadLine());
            }

            i_StreamReader.DiscardBufferedData();
            i_StreamReader.Close();
            i_StreamReader.Dispose();
        }

        public static Garage FromTextFile(string i_TextFileNameOfVehicles)
        {
            return new Garage(i_TextFileNameOfVehicles);
        }

        public static Garage FromStreamReader(StreamReader i_StreamReader)
        {
            return new Garage(i_StreamReader);
        }

        public void ToTextFile(string i_TextFileNameOfVehicles)
        {
            StreamWriter streamWriter = File.CreateText(i_TextFileNameOfVehicles);
            foreach (var currentVehicle in m_VehiclesInGarage.Values)
            {
                streamWriter.WriteLine(currentVehicle);
                foreach (Wheel currentWheel in currentVehicle.ActualVehicle.Wheels)
                {
                    streamWriter.WriteLine(currentWheel.CurrentAirPressure);
                }
                streamWriter.WriteLine(currentVehicle.NameOfOwner);
                streamWriter.WriteLine(currentVehicle.PhoneOfOwner);
            }

            streamWriter.Flush();
            streamWriter.Close();
            streamWriter.Dispose();
        }

        public string Enter(C19_Ex03_GarageLogic.Vehicle i_Vehicle, string i_NameOfOwner, string i_PhoneOfOwner)
        {
            if (i_Vehicle == null)
            {
                throw new ArgumentNullException("i_vehicle", "i_vehicle must not be null.");
            }
            if (i_NameOfOwner == null)
            {
                throw new ArgumentNullException("i_NameOfOwner", "i_NameOfOwner must not be null.");
            }
            if (i_PhoneOfOwner == null)
            {
                throw new ArgumentNullException("i_PhoneOfOwner", "i_PhoneOfOwner must not be null.");
            }

            string message = null;
            try
            {
                m_CurrentVehicleInUse = new Garage.Vehicle(i_Vehicle, i_NameOfOwner, i_PhoneOfOwner);
                m_VehiclesInGarage.Add(i_Vehicle.NumberOfLicense, m_CurrentVehicleInUse);
            }
            catch
            {
                message = "Vehicle with license number " + i_Vehicle.NumberOfLicense + " already exists in the garage.";
                m_CurrentVehicleInUse = m_VehiclesInGarage[i_Vehicle.NumberOfLicense];
                m_CurrentVehicleInUse.Status = Garage.eStatusOfVehicle.InRepair;
            }

            return message;
        }

        public IEnumerable<string> AllLicenseNumbers
        {
            get
            {
                foreach (var currentVehicleInGarage in m_VehiclesInGarage)
                {
                    yield return currentVehicleInGarage.Key;
                }
            }
        }

        private StringBuilder allLicenseNumbersInASingleStringBuilder
        {
            get
            {
                return IEnumerableTo.StringBuilderFrom(AllLicenseNumbers);
            }
        }

        private StringWriter allLicenseNumbersInASingleStringWriter
        {
            get
            {
                return IEnumerableTo.StringWriterFrom(AllLicenseNumbers);
            }
        }

        public string AllLicenseNumbersInASingleString
        {
            get
            {
                return IEnumerableTo.StringFrom(AllLicenseNumbers);
            }
        }

        public IEnumerable<string> GetLicenseNumbersWhoseVehicleStatusIs(Garage.eStatusOfVehicle i_Status)
        {
            foreach (var currentVehicleInGarage in m_VehiclesInGarage)
            {
                if (currentVehicleInGarage.Value.Status == i_Status)
                {
                    yield return currentVehicleInGarage.Key;
                }
            }
        }

        private StringBuilder getLicenseNumbersInASingleStringBuilderWhoseVehicleStatusIs(Garage.eStatusOfVehicle i_Status)
        {
            return IEnumerableTo.StringBuilderFrom(GetLicenseNumbersWhoseVehicleStatusIs(i_Status));
        }

        private StringWriter getLicenseNumbersInASingleStringWriterWhoseVehicleStatusIs(Garage.eStatusOfVehicle i_Status)
        {
            return IEnumerableTo.StringWriterFrom(GetLicenseNumbersWhoseVehicleStatusIs(i_Status));
        }

        public string GetLicenseNumbersInASingleStringWhoseVehicleStatusIs(Garage.eStatusOfVehicle i_Status)
        {
            return IEnumerableTo.StringFrom(GetLicenseNumbersWhoseVehicleStatusIs(i_Status));
        }

        public IEnumerable<string> GetLicenseNumbersWhoseVehicleStatusSatisfies(Func<Garage.eStatusOfVehicle, bool> i_Condition)
        {
            if (i_Condition == null)
            {
                throw new ArgumentNullException("i_Condition", "i_Condition must not be null.");
            }

            foreach (var currentVehicleInGarage in m_VehiclesInGarage)
            {
                if (i_Condition(currentVehicleInGarage.Value.Status))
                {
                    yield return currentVehicleInGarage.Key;
                }
            }
        }

        private StringBuilder getLicenseNumbersInASingleStringBuilderWhoseVehicleStatusSatisfies(Func<Garage.eStatusOfVehicle, bool> i_Condition)
        {
            return IEnumerableTo.StringBuilderFrom(GetLicenseNumbersWhoseVehicleStatusSatisfies(i_Condition));
        }

        private StringWriter getLicenseNumbersInASingleStringWriterWhoseVehicleStatusSatisfies(Func<Garage.eStatusOfVehicle, bool> i_Condition)
        {
            return IEnumerableTo.StringWriterFrom(GetLicenseNumbersWhoseVehicleStatusSatisfies(i_Condition));
        }

        public string GetLicenseNumbersInASingleStringWhoseVehicleStatusSatisfies(Func<Garage.eStatusOfVehicle, bool> i_Condition)
        {
            return IEnumerableTo.StringFrom(GetLicenseNumbersWhoseVehicleStatusSatisfies(i_Condition));
        }

        public IEnumerable<string> GetLicenseNumbersByFilter(Garage.eStatusOfVehicleFilter i_Filter)
        {
            IEnumerable<string> output;
            switch (i_Filter)
            {
                case eStatusOfVehicleFilter.All:
                   output = AllLicenseNumbers;
                break;
                case eStatusOfVehicleFilter.InRepair:
                   output = GetLicenseNumbersWhoseVehicleStatusIs(eStatusOfVehicle.InRepair);
                break;
                case eStatusOfVehicleFilter.Paid:
                   output = GetLicenseNumbersWhoseVehicleStatusIs(eStatusOfVehicle.Paid);
                break;
                case eStatusOfVehicleFilter.Repaired:
                   output = GetLicenseNumbersWhoseVehicleStatusIs(eStatusOfVehicle.Repaired);
                break;
                default:
                   throw new UnreachableCodeReachedException();
            }

            return output;
        }

        private StringBuilder getLicenseNumbersInASingleStringBuilderByFilter(Garage.eStatusOfVehicleFilter i_Filter)
        {
            return IEnumerableTo.StringBuilderFrom(GetLicenseNumbersByFilter(i_Filter));
        }

        private StringWriter getLicenseNumbersInASingleStringWriterByFilter(Garage.eStatusOfVehicleFilter i_Filter)
        {
            return IEnumerableTo.StringWriterFrom(GetLicenseNumbersByFilter(i_Filter));
        }

        public string GetLicenseNumbersInASingleStringByFilter(Garage.eStatusOfVehicleFilter i_Filter)
        {
            return IEnumerableTo.StringFrom(GetLicenseNumbersByFilter(i_Filter));
        }

        public void ChangeStatusOfVehicleWhoseLicenseNumberIs(string i_NumberOfLicense, Garage.eStatusOfVehicle i_NewStatus)
        {
            if (i_NumberOfLicense == null)
            {
                throw new ArgumentNullException("i_NumberOfLicense", "i_NumberOfLicense must not be null.");
            }

            if (not(m_VehiclesInGarage.ContainsKey(i_NumberOfLicense)))
            {
                throw new ArgumentException("The garage does not have a vehicle with this license number " + i_NumberOfLicense + '.', "i_NumberOfLicense");
            }

            m_VehiclesInGarage[i_NumberOfLicense].Status = i_NewStatus;
        }

        public void InflateAllWheelsToTheirMaximumOfVehicleWhoseLicenseNumberIs(string i_NumberOfLicense)
        {
            if (i_NumberOfLicense == null)
            {
                throw new ArgumentNullException("i_NumberOfLicense", "i_NumberOfLicense must not be null.");
            }

            if (not(m_VehiclesInGarage.ContainsKey(i_NumberOfLicense)))
            {
                throw new ArgumentException("The garage does not have a vehicle with this license number " + i_NumberOfLicense + '.', "i_NumberOfLicense");
            }

            m_VehiclesInGarage[i_NumberOfLicense].ActualVehicle.InflateAllWheelsToTheirMaximum();
        }

        public Garage.eRefuelStatus RefuelVehicleWhoseLicenseNumberIs(string i_NumberOfLicense, VehicleThatOperatesOnFuel.eTypeOfFuel i_TypeOfFuel, float i_AmountOfFuelToFillTheTankInLiters, bool i_ThrowProperExceptionOnError = true)
        {
            Garage.eRefuelStatus status;
            if (i_NumberOfLicense == null)
            {
                if (i_ThrowProperExceptionOnError)
                {
                    throw new ArgumentNullException("i_NumberOfLicense", "i_NumberOfLicense must not be null.");
                }
                status = Garage.eRefuelStatus.NumberOfLicenseIsNull;
            }
            else if (float.IsNaN(i_AmountOfFuelToFillTheTankInLiters))
            {
                if (i_ThrowProperExceptionOnError)
                {
                    throw new ArgumentNaNException("i_AmountOfFuelToFillTheTankInLiters");
                }
                status = Garage.eRefuelStatus.AmountOfFuelToAddIsNaN;
            }
            else if (float.IsInfinity(i_AmountOfFuelToFillTheTankInLiters))
            {
                if (i_ThrowProperExceptionOnError)
                {
                    throw new ArgumentInfinityException("i_AmountOfFuelToFillTheTankInLiters");
                }
                status = Garage.eRefuelStatus.AmountOfFuelToAddIsInfinity;
            }
            else if (not(m_VehiclesInGarage.ContainsKey(i_NumberOfLicense)))
            {
                if (i_ThrowProperExceptionOnError)
                {
                    throw new TheReferredVehicleByLicenseNumberDoesNotOperateOnFuelException(i_NumberOfLicense, "i_NumberOfLicense");
                }
                status = Garage.eRefuelStatus.TheGarageDoesNotHaveAVehicleWithThisLicenseNumber;
            }
            else
            {
                C19_Ex03_GarageLogic.Vehicle vehicle = m_VehiclesInGarage[i_NumberOfLicense].ActualVehicle;
                if (not(vehicle is VehicleThatOperatesOnFuel))
                {
                    if (i_ThrowProperExceptionOnError)
                    {
                        throw new TheGarageDoesNotOwnAVehicleWithThisLicenseNumberException(i_NumberOfLicense, "i_NumberOfLicense");
                    }
                    status = Garage.eRefuelStatus.TheReferredVehicleDoesNotOperateOnFuel;
                }
                else
                {
                    VehicleThatOperatesOnFuel vehicleThatOperatesOnFuel = vehicle as VehicleThatOperatesOnFuel;
                    switch (vehicleThatOperatesOnFuel.Refuel(i_AmountOfFuelToFillTheTankInLiters, i_TypeOfFuel, i_ThrowProperExceptionOnError))
                    {
                        case VehicleThatOperatesOnFuel.eRefuelStatus.AmountOfFuelToAddIsNaN:
                            status = Garage.eRefuelStatus.AmountOfFuelToAddIsNaN;
                        break;
                        case VehicleThatOperatesOnFuel.eRefuelStatus.AmountOfFuelToAddIsInfinity:
                            status = Garage.eRefuelStatus.AmountOfFuelToAddIsInfinity;
                        break;
                        case VehicleThatOperatesOnFuel.eRefuelStatus.FuelTankOverflow:
                            status = Garage.eRefuelStatus.FuelTankOverflow;
                        break;
                        case VehicleThatOperatesOnFuel.eRefuelStatus.TypesOfFuelsAreIncompatible:
                            status = Garage.eRefuelStatus.TypesOfFuelsAreIncompatible;
                        break;
                        default:
                        case VehicleThatOperatesOnFuel.eRefuelStatus.Success:
                            status = Garage.eRefuelStatus.Success;
                        break;
                    }
                }
            }

            return status;
        }

        public Garage.eChargeStatus ChargeElectricVehicleWhoseLicenseNumberIs(string i_NumberOfLicense, float i_NumberOfMinutesToAddToLifeTimeOfBattery, bool i_ThrowProperExceptionOnError = true)
        {
            Garage.eChargeStatus status = Garage.eChargeStatus.Success;
            if (i_NumberOfLicense == null)
            {
                if (i_ThrowProperExceptionOnError)
                {
                    throw new ArgumentNullException("i_NumberOfLicense", "i_NumberOfLicense must not be null.");
                }
                status = Garage.eChargeStatus.NumberOfLicenseIsNull;
            }
            else if (float.IsNaN(i_NumberOfMinutesToAddToLifeTimeOfBattery))
            {
                if (i_ThrowProperExceptionOnError)
                {
                    throw new ArgumentNaNException("i_NumberOfMinutesToAddToLifeTimeOfBattery");
                }
                status = Garage.eChargeStatus.NumberOfMinutesToAddToLifeTimeOfBatteryIsNaN;
            }
            else if (float.IsInfinity(i_NumberOfMinutesToAddToLifeTimeOfBattery))
            {
                if (i_ThrowProperExceptionOnError)
                {
                    throw new ArgumentInfinityException("i_NumberOfMinutesToAddToLifeTimeOfBattery");
                }
                status = Garage.eChargeStatus.NumberOfMinutesToAddToLifeTimeOfBatteryIsInfinity;
            }
            else if (i_NumberOfMinutesToAddToLifeTimeOfBattery <= 0f)
            {
                if (i_ThrowProperExceptionOnError)
                {
                    throw new ArgumentIsNotPositiveNumberException("i_NumberOfMinutesToAddToLifeTimeOfBattery", i_NumberOfMinutesToAddToLifeTimeOfBattery);
                }
                status = Garage.eChargeStatus.NumberOfMinutesToAddToLifeTimeOfBatteryIsNotPositive;
            }
            else if (not(m_VehiclesInGarage.ContainsKey(i_NumberOfLicense)))
            {
                if (i_ThrowProperExceptionOnError)
                {
                    throw new TheGarageDoesNotOwnAVehicleWithThisLicenseNumberException(i_NumberOfLicense, "i_NumberOfLicense");
                }
                status = eChargeStatus.TheGarageDoesNotHaveAVehicleWithThisLicenseNumber;
            }
            else
            {
                C19_Ex03_GarageLogic.Vehicle vehicle = m_VehiclesInGarage[i_NumberOfLicense].ActualVehicle;
                if (not(vehicle is ElectricVehicle))
                {
                    if (i_ThrowProperExceptionOnError)
                    {
                        throw new TheReferredVehicleByLicenseNumberIsNotElectricException(i_NumberOfLicense, "i_NumberOfLicense");
                    }
                    status = eChargeStatus.TheReferredVehicleIsNotElectric;
                }
                else
                {
                    ElectricVehicle electricVehicle = vehicle as ElectricVehicle;
                    switch (electricVehicle.Charge(TimeUnitConverter.FromMinutesToHours(i_NumberOfMinutesToAddToLifeTimeOfBattery), i_ThrowProperExceptionOnError))
                    {
                        case ElectricVehicle.eChargeStatus.NumberOfHoursToAddToLifeTimeOfBatteryIsNaN:
                            status = Garage.eChargeStatus.NumberOfMinutesToAddToLifeTimeOfBatteryIsNaN;
                        break;
                        case ElectricVehicle.eChargeStatus.NumberOfHoursToAddToLifeTimeOfBatteryIsInfinity:
                            status = Garage.eChargeStatus.NumberOfMinutesToAddToLifeTimeOfBatteryIsInfinity;
                        break;
                        case ElectricVehicle.eChargeStatus.NumberOfHoursToAddToLifeTimeOfBatteryIsNotPositive:
                            status = Garage.eChargeStatus.NumberOfMinutesToAddToLifeTimeOfBatteryIsNotPositive;
                        break;
                        case ElectricVehicle.eChargeStatus.Overflow:
                            status = eChargeStatus.Overflow;
                        break;
                        case ElectricVehicle.eChargeStatus.Success:
                            status = eChargeStatus.Success;
                        break;
                    }
                }
            }

            return status;
        }

        public Garage.Vehicle.Information GetFullInformationAboutAVehicleWhoseLicenseNumberIs(string i_NumberOfLicense)
        {
            if (i_NumberOfLicense == null)
            {
                throw new ArgumentNullException("i_NumberOfLicense", "i_NumberOfLicense must not be null.");
            }

            if (not(m_VehiclesInGarage.ContainsKey(i_NumberOfLicense)))
            {
                throw new TheGarageDoesNotOwnAVehicleWithThisLicenseNumberException(i_NumberOfLicense, "i_NumberOfLicense");
            }

            return m_VehiclesInGarage[i_NumberOfLicense].Info;
        }

        public bool AlreadyOwnsVehicleWhoseLicenseNumberIs(string i_NumberOfLicense)
        {
            if (i_NumberOfLicense == null)
            {
                throw new ArgumentNullException("i_NumberOfLicense", "i_NumberOfLicense must not be null.");
            }

            return m_VehiclesInGarage.ContainsKey(i_NumberOfLicense);
        }

        public Garage.eStatusOfVehicle GetStatusOfAVehicleWhoseLicenseNumberIs(string i_NumberOfLicense)
        {
            if (i_NumberOfLicense == null)
            {
                throw new ArgumentNullException("i_NumberOfLicense", "i_NumberOfLicense must not be null.");
            }

            if (not(m_VehiclesInGarage.ContainsKey(i_NumberOfLicense)))
            {
                throw new TheGarageDoesNotOwnAVehicleWithThisLicenseNumberException(i_NumberOfLicense, "i_NumberOfLicense");
            }

            return m_VehiclesInGarage[i_NumberOfLicense].Status;
        }

        public float GetRemainingAmountOfFuelInTheTankOfAVehicleWhoseLicenseNumberIs(string i_NumberOfLicense)
        {
            if (i_NumberOfLicense == null)
            {
                throw new ArgumentNullException("i_NumberOfLicense", "i_NumberOfLicense must not be null.");
            }

            if (not(m_VehiclesInGarage.ContainsKey(i_NumberOfLicense)))
            {
                throw new TheGarageDoesNotOwnAVehicleWithThisLicenseNumberException(i_NumberOfLicense, "i_NumberOfLicense");
            }

            C19_Ex03_GarageLogic.Vehicle vehicle = m_VehiclesInGarage[i_NumberOfLicense].ActualVehicle;

            if (not(vehicle is VehicleThatOperatesOnFuel))
            {
                throw new TheReferredVehicleByLicenseNumberDoesNotOperateOnFuelException(i_NumberOfLicense, "i_NumberOfLicense");
            }

            return (vehicle as VehicleThatOperatesOnFuel).RemainingAmountOfFuelInTheTank;
        }

        public float GetRemainingNumberOfHoursForLifeTimeOfBatteryOfAnElectricVehicleWhoseLicenseNumberIs(string i_NumberOfLicense)
        {
            if (i_NumberOfLicense == null)
            {
                throw new ArgumentNullException("i_NumberOfLicense", "i_NumberOfLicense must not be null.");
            }

            if (not(m_VehiclesInGarage.ContainsKey(i_NumberOfLicense)))
            {
                throw new TheGarageDoesNotOwnAVehicleWithThisLicenseNumberException(i_NumberOfLicense, "i_NumberOfLicense");
            }

            C19_Ex03_GarageLogic.Vehicle vehicle = m_VehiclesInGarage[i_NumberOfLicense].ActualVehicle;

            if (not(vehicle is ElectricVehicle))
            {
                throw new TheReferredVehicleByLicenseNumberIsNotElectricException(i_NumberOfLicense, "i_NumberOfLicense");
            }

            return (vehicle as ElectricVehicle).RemainingNumberOfHoursForLifeTimeOfBattery;
        }

        public void Clear()
        {
            m_VehiclesInGarage.Clear();
        }

        public static string[] NamesOfSupportedTypesOfVehicles
        {
            get
            {
                return new string[]
                {
                    k_StringFuelMotorcycle,
                    k_StringElectricMotorcycle,
                    k_StringFuelCar,
                    k_StringElectricCar,
                    k_StringFuelTruck/*,
                    k_StringElectricTruck*/
                };
            }
        }

        public static bool Supports(string i_NameOfTypeOfVehicle)
        {
            bool garageSupportsThisTypeOfVehicle = false;
            foreach (string currentNameOfSupportedTypeOfVehicle in NamesOfSupportedTypesOfVehicles)
            {
                if (i_NameOfTypeOfVehicle == currentNameOfSupportedTypeOfVehicle)
                {
                    garageSupportsThisTypeOfVehicle = true;
                    break;
                }
            }

            return garageSupportsThisTypeOfVehicle;
        }

        public /*private*/ const string k_ServiceNameEnterNewVehicleIntoTheGarage = "Enter new vehicle into the garage";
        public /*private*/ const string k_ServiceNameListVehiclesLicenseNumbers = "List vehicles license numbers";
        public /*private*/ const string k_ServiceNameChangeTheStatusOfAVehicle = "Change the status of a vehicle in the garage";
        public /*private*/ const string k_ServiceNameInflateAirPressureOfAVehicleWheelsToMaximum = "Inflate air pressure of a vehicle wheels to maximum";
        public /*private*/ const string k_ServiceNameRefuelVehicleInTheGarage = "Refuel vehicle in the garage";
        public /*private*/ const string k_ServiceNameChargeElectricVehicleInTheGarage = "Charge electric vehicle in the garage";
        public /*private*/ const string k_ServiceNameDisplayFullInformationAboutAVehicle = "Display full information about a vehicle in the garage";

        private const string k_ResponseTypeOfVehicleToEnterIntoTheGarage = "Enter vehicle type number: ";

        public static string[] NamesOfServices
        {
            get
            {
                return new string[]
                {
                    k_ServiceNameEnterNewVehicleIntoTheGarage,
                    k_ServiceNameListVehiclesLicenseNumbers,
                    k_ServiceNameChangeTheStatusOfAVehicle,
                    k_ServiceNameInflateAirPressureOfAVehicleWheelsToMaximum,
                    k_ServiceNameRefuelVehicleInTheGarage,
                    k_ServiceNameChargeElectricVehicleInTheGarage,
                    k_ServiceNameDisplayFullInformationAboutAVehicle
                };
            }
        }

        public /*private*/ static C19_Ex03_GarageLogic.Vehicle.eVehicle GetEnumVehicleFromString(string i_String)
        {
            C19_Ex03_GarageLogic.Vehicle.eVehicle output;
            switch (i_String)
            {
                case k_StringFuelCar:
                    output = C19_Ex03_GarageLogic.Vehicle.eVehicle.CarThatOperatesOnFuel;
                break;
                case k_StringFuelMotorcycle:
                    output = C19_Ex03_GarageLogic.Vehicle.eVehicle.MotorcycleThatOperatesOnFuel;
                break;
                case k_StringFuelTruck:
                    output = C19_Ex03_GarageLogic.Vehicle.eVehicle.TruckThatOperatesOnFuel;
                break;
                case k_StringElectricCar:
                    output = C19_Ex03_GarageLogic.Vehicle.eVehicle.ElectricCar;
                break;
                case k_StringElectricMotorcycle:
                    output = C19_Ex03_GarageLogic.Vehicle.eVehicle.ElectricMotorcycle;
                break;
                case k_StringElectricTruck:
                    output = C19_Ex03_GarageLogic.Vehicle.eVehicle.ElectricTruck;
                break;
                default:
                    throw new NotSupportedException("The garage does not support this type of vehicle.");
            }

            return output;
        }

        public /*private*/ static Garage.eOperatesOn GetSourceOfEnergy(C19_Ex03_GarageLogic.Vehicle.eVehicle i_Vehicle)
        {
            Garage.eOperatesOn output;
            switch (i_Vehicle)
            {
                case C19_Ex03_GarageLogic.Vehicle.eVehicle.CarThatOperatesOnFuel:
                case C19_Ex03_GarageLogic.Vehicle.eVehicle.MotorcycleThatOperatesOnFuel:
                case C19_Ex03_GarageLogic.Vehicle.eVehicle.TruckThatOperatesOnFuel:
                    output = Garage.eOperatesOn.Fuel;
                break;
                case C19_Ex03_GarageLogic.Vehicle.eVehicle.ElectricCar:
                case C19_Ex03_GarageLogic.Vehicle.eVehicle.ElectricMotorcycle:
                case C19_Ex03_GarageLogic.Vehicle.eVehicle.ElectricTruck:
                    output = Garage.eOperatesOn.Electricity;
                break;
                default:
                    throw new UnreachableCodeReachedException();
            }

            return output;
        }

        public /*private*/ static C19_Ex03_GarageLogic.Vehicle.eAbstractVehicle GetEnumAbstractVehicle(C19_Ex03_GarageLogic.Vehicle.eVehicle i_Vehicle)
        {
            C19_Ex03_GarageLogic.Vehicle.eAbstractVehicle output;
            switch (i_Vehicle)
            {
                case C19_Ex03_GarageLogic.Vehicle.eVehicle.CarThatOperatesOnFuel:
                case C19_Ex03_GarageLogic.Vehicle.eVehicle.ElectricCar:
                    output = C19_Ex03_GarageLogic.Vehicle.eAbstractVehicle.Car;
                break;
                case C19_Ex03_GarageLogic.Vehicle.eVehicle.MotorcycleThatOperatesOnFuel:
                case C19_Ex03_GarageLogic.Vehicle.eVehicle.ElectricMotorcycle:
                    output = C19_Ex03_GarageLogic.Vehicle.eAbstractVehicle.Motorcycle;
                break;
                case C19_Ex03_GarageLogic.Vehicle.eVehicle.TruckThatOperatesOnFuel:
                case C19_Ex03_GarageLogic.Vehicle.eVehicle.ElectricTruck:
                    output = C19_Ex03_GarageLogic.Vehicle.eAbstractVehicle.Truck;
                break;
                default:
                    throw new UnreachableCodeReachedException();
            }

            return output;
        }

        public /*private*/ static float GetCapacityOfTank(C19_Ex03_GarageLogic.Vehicle.eVehicle i_Vehicle)
        {
            float output;
            switch (i_Vehicle)
            {
                case C19_Ex03_GarageLogic.Vehicle.eVehicle.CarThatOperatesOnFuel:
                    output = CarThatOperatesOnFuel.k_CapacityOfTank;
                break;
                case C19_Ex03_GarageLogic.Vehicle.eVehicle.MotorcycleThatOperatesOnFuel:
                    output = MotorcycleThatOperatesOnFuel.k_CapacityOfTank;
                break;
                case C19_Ex03_GarageLogic.Vehicle.eVehicle.TruckThatOperatesOnFuel:
                    output = TruckThatOperatesOnFuel.k_CapacityOfTank;
                break;
                default:
                    throw new ArgumentException("i_Vehicle's value must be a vehicle that operates on fuel enum value.", "i_Vehicle");
            }

            return output;
        }

        public /*private*/ static float GetMaximumNumberOfHoursForLifeTimeOfBattery(C19_Ex03_GarageLogic.Vehicle.eVehicle i_Vehicle)
        {
            float output;
            switch (i_Vehicle)
            {
                case C19_Ex03_GarageLogic.Vehicle.eVehicle.ElectricCar:
                    output = ElectricCar.k_MaximumNumberOfHoursForLifeTimeOfBattery;
                break;
                case C19_Ex03_GarageLogic.Vehicle.eVehicle.ElectricMotorcycle:
                    output = ElectricMotorcycle.k_MaximumNumberOfHoursForLifeOfBattery;
                break;
                case C19_Ex03_GarageLogic.Vehicle.eVehicle.ElectricTruck:
                    output = ElectricTruck.k_MaximumNumberOfHoursForLifeTimeOfBattery;
                break;
                default:
                    throw new ArgumentException("i_Vehicle's value must be an electric vehicle enum value.", "i_Vehicle");
            }

            return output;
        }

        private bool not(bool i_boolean)
        {
            return !i_boolean;
        }
    }
}