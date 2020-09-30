namespace C19_Ex03_ConsoleUI
{
    using System;
    using System.IO;
    using System.Threading;
    using C19_Ex03_GarageLogic;

    // $G$ DSN-999 (-15) It's not an object oriented programming to write all the code in th entry point of the application - Program

    public static class Program
    {
        private const string k_ResponseTypeOfVehicleToEnterTheGarage = "Enter vehicle type number: ";
        private const short k_MenuDelay = 750;
        private static int s_ConsoleCursorLeftBeforeRead;
        
        // $G$ DSN-999 (-5) The Main method should be short and summarized, should only invoke the main object of the program.
        public static void Main()
        {
            Console.Title = "C19 Ex03 Erez 205947062 Roy 313175192 - Garage Management Application";
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            Garage garage = new Garage();
            int numberOfOptions = Garage.NamesOfServices.Length + 1;
            int numberOfFirstOption = 1;
            int numberOfLastOption = numberOfOptions;
            int numberOfQuitOption = numberOfLastOption;

            bool userDidNotChooseToQuitTheApplication = true;
            while (userDidNotChooseToQuitTheApplication)
            {
                Console.WriteLine("=============================");
                Console.WriteLine("Garage Management Application");
                Console.WriteLine("=============================");
                Console.WriteLine();

                for (long i = 0; i < Garage.NamesOfServices.Length; i++)
                {
                    Console.WriteLine((i + 1) + ". " + Garage.NamesOfServices[i]);
                }

                Console.WriteLine(numberOfQuitOption + ". Quit");
                Console.WriteLine();
                Console.Write("Enter your choice: ");
                const bool v_intercept = true;
                byte userChoice;
                if (numberOfOptions <= 9)
                {
                    ConsoleKeyInfo readKey = Console.ReadKey(not(v_intercept));
                    if (readKey.Key == ConsoleKey.Enter)
                    {
                        Console.Clear();
                        continue;
                    }

                    userChoice = (byte)(readKey.KeyChar - '0');

                    if (userChoice < numberOfFirstOption || userChoice > numberOfLastOption)
                    {
                        Console.Clear();
                        continue;
                    }
                }
                else
                {
                    bool byteTryParseSucceed = byte.TryParse(Console.ReadLine(), out userChoice);
                    if (not(byteTryParseSucceed) || userChoice < numberOfFirstOption || userChoice > numberOfLastOption)
                    {
                        Console.Clear();
                        continue;
                    }
                }

                Thread.Sleep(k_MenuDelay);

                if (userChoice == numberOfQuitOption)
                {
                    userDidNotChooseToQuitTheApplication = false;
                    if (numberOfOptions <= 9)
                    {
                        Console.WriteLine();
                    }

                    Console.WriteLine();
                    Console.WriteLine("Good Bye");
                    Console.Write("Press any key to exit...");
                    Console.ReadKey(v_intercept);
                }
                else
                {
                    Console.Clear();
                    bool garageCurrentServiceNeedsMoreParameters;
                    bool lastReadIsLine;
                    Console.Write(GiveService(garage, userChoice, out garageCurrentServiceNeedsMoreParameters));
                    while (garageCurrentServiceNeedsMoreParameters)
                    {
                        s_ConsoleCursorLeftBeforeRead = Console.CursorLeft;
                        Console.Write(GetInputParameterFromTheUser(garage, readKeyboard(out lastReadIsLine), out garageCurrentServiceNeedsMoreParameters));
                    }

                    Console.WriteLine();
                    Console.Write("Press any key to return to the main menu...");
                    Console.ReadKey(v_intercept);
                    Console.Clear();
                }
            }
        }

        private static string readKeyboard(/*Garage i_Garage,*/ out bool o_ReadLine)
        {
            string output;
			const bool v_intercept = true;

            switch (/*i_Garage.CurrentService*/ s_CurrentService)
            {
                case Garage.eService.ChangeTheStatusOfAVehicle:
                   switch (/*i_Garage.CurrentServiceParameter*/ s_CurrentServiceParameter)
                   {
                       case Garage.eServiceParameter.Status:
                          output = Enum<Garage.eStatusOfVehicle>.Values.Length <= 9 ? Console.ReadKey(not(v_intercept)).KeyChar.ToString() : Console.ReadLine();
                          o_ReadLine = Enum<Garage.eStatusOfVehicle>.Values.Length > 9;
                       break;
                       default:
                          output = Console.ReadLine();
                          o_ReadLine = true;
                       break;
                   }

                break;
                case Garage.eService.ChargeElectricVehicle:
                    output = Console.ReadLine();
                    o_ReadLine = true;
                break;
                case Garage.eService.EnterNewVehicleIntoTheGarage:
                   switch (/*i_Garage.CurrentServiceParameter*/ s_CurrentServiceParameter)
                   {
                       case Garage.eServiceParameter.TypeOfVehicleToEnterIntoTheGarage:
                          output = Garage.NamesOfSupportedTypesOfVehicles.Length <= 9 ?
                                   Console.ReadKey(not(v_intercept)).KeyChar.ToString() :
                                   Console.ReadLine();
                          o_ReadLine = Garage.NamesOfSupportedTypesOfVehicles.Length > 9;
                       break;
                       case Garage.eServiceParameter.NewTruckContainsDangerousSubstances:
                          output = Console.ReadKey(not(v_intercept)).KeyChar.ToString();
                          o_ReadLine = false;
                       break;
                       default:
                          output = Console.ReadLine();
                          o_ReadLine = true;
                       break;
                   }

                break;
                case Garage.eService.DisplayFullInformationAboutSomeVehicle:
                    output = Console.ReadLine();
                    o_ReadLine = true;
                break;
                case Garage.eService.InflateAirPressureOfAVehicleWheelsToMaximum:
                    output = Console.ReadLine();
                    o_ReadLine = true;
                break;
                case Garage.eService.ListLicenseNumbersOfVehicles:
                   switch (/*i_Garage.CurrentServiceParameter*/ s_CurrentServiceParameter)
                   {
                       case Garage.eServiceParameter.FilterBy:
                          output = Enum<Garage.eStatusOfVehicleFilter>.Values.Length <= 9 ? Console.ReadKey(not(v_intercept)).KeyChar.ToString() : Console.ReadLine();
                          o_ReadLine = Enum<Garage.eStatusOfVehicleFilter>.Values.Length > 9;
                       break;
                       default:
                          output = Console.ReadLine();
                          o_ReadLine = true;
                       break;
                   }

                break;
                case Garage.eService.RefuelVehicle:
                    output = Console.ReadLine();
                    o_ReadLine = true;
                break;
                default:
                    throw new UnreachableCodeReachedException();
            }

            return output;
        }

        private static bool not(bool i_Boolean)
        {
            return !i_Boolean;
        }

        private static Garage.eService? s_CurrentService = null;
        private static ulong s_CurrentServiceParameterNumber = 0;
        private static Garage.eServiceParameter? s_CurrentServiceParameter = null;

        private static Vehicle.eVehicle? s_TypeOfVehicleToEnterIntoTheGarage = null;
        private static Garage.eOperatesOn s_TheVehicleToEnterIntoTheGarageOperatesOn;
        private static Vehicle.eAbstractVehicle s_AbstractVehicleToEnterIntoTheGarage;
        private static string s_NameOfModel = null;
        private static string s_NumberOfLicense = null;
        private static string s_NameOfWheelManufacturer = null;
        private static float[] s_WheelsAirPressures = null;
        private static long s_CurrentWheelIndex = 0;
        private static float? s_RemainingAmountOfFuelInTheTank = null;
        private static float? s_RemainingNumberOfHoursForLifeTimeOfBattery = null;

        private static Car.eColor? s_NewCarColor = null;
        private static byte? s_NewCarNumberOfDoors = null;

        private static Motorcycle.eTypeOfLicense? s_NewMotorcycleTypeOfLicense = null;
        private static int? s_NewMotorcycleCapacityOfEngine = null;

        private static bool? s_NewTruckContainsDangerousSubstances = null;
        private static float? s_NewTruckVolumeOfCargo = null;

        private static string s_NameOfOwner = null;
        private static string s_PhoneOfOwner = null;

        private static VehicleThatOperatesOnFuel.eTypeOfFuel? s_TypeOfFuel = null;
        private static float? s_AmountOfFuelToFillTheTankInLiters = null;
        private static float? s_NumberOfMinutesToAddToTheBattery = null;

        private static void resetServiceParameters()
        {
            s_CurrentService = null;
            s_CurrentServiceParameterNumber = 0;
            s_CurrentServiceParameter = null;

            s_TypeOfVehicleToEnterIntoTheGarage = null;
            s_NameOfModel = null;
            s_NumberOfLicense = null;
            s_NameOfWheelManufacturer = null;
            s_WheelsAirPressures = null;
            s_CurrentWheelIndex = 0;
            s_RemainingAmountOfFuelInTheTank = null;
            s_RemainingNumberOfHoursForLifeTimeOfBattery = null;

            s_NewCarColor = null;
            s_NewCarNumberOfDoors = null;

            s_NewMotorcycleTypeOfLicense = null;
            s_NewMotorcycleCapacityOfEngine = null;

            s_NewTruckContainsDangerousSubstances = null;
            s_NewTruckVolumeOfCargo = null;

            s_NameOfOwner = null;
            s_PhoneOfOwner = null;

            s_TypeOfFuel = null;
            s_AmountOfFuelToFillTheTankInLiters = null;
            s_NumberOfMinutesToAddToTheBattery = null;
        }

        // $G$ CSS-018 (-5) You should have used enumerations here.
        public static object GiveService(Garage i_Garage, long i_NumberOfService, out bool o_SelectedServiceNeedsMoreParameters)
        {
            object response;

            switch (i_NumberOfService)
            {
                case 1:
                    response = GiveService(i_Garage, Garage.eService.EnterNewVehicleIntoTheGarage, out o_SelectedServiceNeedsMoreParameters);
                break;
                case 2:
                    response = GiveService(i_Garage, Garage.eService.ListLicenseNumbersOfVehicles, out o_SelectedServiceNeedsMoreParameters);
                break;
                case 3:
                    response = GiveService(i_Garage, Garage.eService.ChangeTheStatusOfAVehicle, out o_SelectedServiceNeedsMoreParameters);
                break;
                case 4:
                    response = GiveService(i_Garage, Garage.eService.InflateAirPressureOfAVehicleWheelsToMaximum, out o_SelectedServiceNeedsMoreParameters);
                break;
                case 5:
                    response = GiveService(i_Garage, Garage.eService.RefuelVehicle, out o_SelectedServiceNeedsMoreParameters);
                break;
                case 6:
                    response = GiveService(i_Garage, Garage.eService.ChargeElectricVehicle, out o_SelectedServiceNeedsMoreParameters);
                break;
                case 7:
                    response = GiveService(i_Garage, Garage.eService.DisplayFullInformationAboutSomeVehicle, out o_SelectedServiceNeedsMoreParameters);
                break;
                default:
                    response = "The garage does not have service no. " + i_NumberOfService;
                    o_SelectedServiceNeedsMoreParameters = false;
                break;
            }

            return response;
        }

        // $G$ CSS-010 (-5) Private methods should start with an lowercase letter.
        private static StringWriter VehicleTypeMessage
        {
            get
            {
                StringWriter stringWriter = new StringWriter();
                stringWriter.WriteLine(new string('=', Garage.k_ServiceNameEnterNewVehicleIntoTheGarage.Length));
                stringWriter.WriteLine(Garage.k_ServiceNameEnterNewVehicleIntoTheGarage);
                stringWriter.WriteLine(new string('=', Garage.k_ServiceNameEnterNewVehicleIntoTheGarage.Length));
                stringWriter.WriteLine();
                stringWriter.WriteLine("Garage supported vehicles types:" + Environment.NewLine);
                for (long i = 0; i < Garage.NamesOfSupportedTypesOfVehicles.Length; i++)
                {
                    stringWriter.WriteLine((i + 1) + ". " + Garage.NamesOfSupportedTypesOfVehicles[i]);
                }

                stringWriter.WriteLine();
                stringWriter.Write(k_ResponseTypeOfVehicleToEnterTheGarage);
                return stringWriter;
            }
        }

        private static StringWriter VehicleStatusFilterMessage
        {
            get
            {
                StringWriter stringWriter = new StringWriter();
                stringWriter.WriteLine(new string('=', Garage.k_ServiceNameListVehiclesLicenseNumbers.Length));
                stringWriter.WriteLine(Garage.k_ServiceNameListVehiclesLicenseNumbers);
                stringWriter.WriteLine(new string('=', Garage.k_ServiceNameListVehiclesLicenseNumbers.Length));
                stringWriter.WriteLine();

                ///stringWriter.WriteLine("Possible Filters:");
                ///stringWriter.WriteLine();

                string[] namesOfeStatusOfVehicleFilter = Enum<Garage.eStatusOfVehicleFilter>.Names;
                for (long i = 0; i < namesOfeStatusOfVehicleFilter.Length; i++)
                {
                    stringWriter.WriteLine((i + 1) + ". " + namesOfeStatusOfVehicleFilter[i]);
                }

                stringWriter.WriteLine();
                stringWriter.Write("Choose filter: ");

                return stringWriter;
            }
        }

        public static object GiveService(Garage i_Garage, Garage.eService i_Service, out bool o_SelectedServiceNeedsMoreParameters)
        {
            const string k_EnterLicenseNumber = "Enter license number: ";

            object response;

            if (s_CurrentService == null)
            {
                StringWriter stringWriter = new StringWriter();
                switch (i_Service)
                {
                    case Garage.eService.EnterNewVehicleIntoTheGarage:
                        s_CurrentService = Garage.eService.EnterNewVehicleIntoTheGarage;
                        s_CurrentServiceParameterNumber = 1;
                        s_CurrentServiceParameter = Garage.eServiceParameter.TypeOfVehicleToEnterIntoTheGarage;
                        response = VehicleTypeMessage;
                        o_SelectedServiceNeedsMoreParameters = true;
                    break;
                    case Garage.eService.ListLicenseNumbersOfVehicles:
                        s_CurrentService = Garage.eService.ListLicenseNumbersOfVehicles;
                        s_CurrentServiceParameterNumber = 1;
                        s_CurrentServiceParameter = Garage.eServiceParameter.FilterBy;
                        response = VehicleStatusFilterMessage;
                        o_SelectedServiceNeedsMoreParameters = true;
                    break;
                    case Garage.eService.ChangeTheStatusOfAVehicle:
                        s_CurrentService = Garage.eService.ChangeTheStatusOfAVehicle;
                        s_CurrentServiceParameterNumber = 1;
                        s_CurrentServiceParameter = Garage.eServiceParameter.NumberOfLicense;
                        stringWriter.WriteLine(new string('=', Garage.k_ServiceNameChangeTheStatusOfAVehicle.Length));
                        stringWriter.WriteLine(Garage.k_ServiceNameChangeTheStatusOfAVehicle);
                        stringWriter.WriteLine(new string('=', Garage.k_ServiceNameChangeTheStatusOfAVehicle.Length));
                        stringWriter.WriteLine();
                        stringWriter.Write(k_EnterLicenseNumber);
                        response = stringWriter;
                        o_SelectedServiceNeedsMoreParameters = true;
                    break;
                    case Garage.eService.InflateAirPressureOfAVehicleWheelsToMaximum:
                        s_CurrentService = Garage.eService.InflateAirPressureOfAVehicleWheelsToMaximum;
                        s_CurrentServiceParameterNumber = 1;
                        s_CurrentServiceParameter = Garage.eServiceParameter.NumberOfLicense;
                        stringWriter.WriteLine(new string('=', Garage.k_ServiceNameInflateAirPressureOfAVehicleWheelsToMaximum.Length));
                        stringWriter.WriteLine(Garage.k_ServiceNameInflateAirPressureOfAVehicleWheelsToMaximum);
                        stringWriter.WriteLine(new string('=', Garage.k_ServiceNameInflateAirPressureOfAVehicleWheelsToMaximum.Length));
                        stringWriter.WriteLine();
                        stringWriter.Write(k_EnterLicenseNumber);
                        response = stringWriter;
                        o_SelectedServiceNeedsMoreParameters = true;
                    break;
                    case Garage.eService.RefuelVehicle:
                        s_CurrentService = Garage.eService.RefuelVehicle;
                        s_CurrentServiceParameterNumber = 1;
                        s_CurrentServiceParameter = Garage.eServiceParameter.NumberOfLicense;
                        stringWriter.WriteLine(new string('=', Garage.k_ServiceNameRefuelVehicleInTheGarage.Length));
                        stringWriter.WriteLine(Garage.k_ServiceNameRefuelVehicleInTheGarage);
                        stringWriter.WriteLine(new string('=', Garage.k_ServiceNameRefuelVehicleInTheGarage.Length));
                        stringWriter.WriteLine();
                        stringWriter.Write(k_EnterLicenseNumber);
                        response = stringWriter;
                        o_SelectedServiceNeedsMoreParameters = true;
                    break;
                    case Garage.eService.ChargeElectricVehicle:
                        s_CurrentService = Garage.eService.ChargeElectricVehicle;
                        s_CurrentServiceParameterNumber = 1;
                        s_CurrentServiceParameter = Garage.eServiceParameter.NumberOfLicense;
                        stringWriter.WriteLine(new string('=', Garage.k_ServiceNameChargeElectricVehicleInTheGarage.Length));
                        stringWriter.WriteLine(Garage.k_ServiceNameChargeElectricVehicleInTheGarage);
                        stringWriter.WriteLine(new string('=', Garage.k_ServiceNameChargeElectricVehicleInTheGarage.Length));
                        stringWriter.WriteLine();
                        stringWriter.Write(k_EnterLicenseNumber);
                        response = stringWriter;
                        o_SelectedServiceNeedsMoreParameters = true;
                    break;
                    case Garage.eService.DisplayFullInformationAboutSomeVehicle:
                        s_CurrentService = Garage.eService.DisplayFullInformationAboutSomeVehicle;
                        s_CurrentServiceParameterNumber = 1;
                        s_CurrentServiceParameter = Garage.eServiceParameter.NumberOfLicense;
                        stringWriter.WriteLine(new string('=', Garage.k_ServiceNameDisplayFullInformationAboutAVehicle.Length));
                        stringWriter.WriteLine(Garage.k_ServiceNameDisplayFullInformationAboutAVehicle);
                        stringWriter.WriteLine(new string('=', Garage.k_ServiceNameDisplayFullInformationAboutAVehicle.Length));
                        stringWriter.WriteLine();
                        stringWriter.Write(k_EnterLicenseNumber);
                        response = stringWriter;
                        o_SelectedServiceNeedsMoreParameters = true;
                    break;
                    default:
                        throw new UnreachableCodeReachedException();
                }
            }
            else
            {
                response = "Must complete current service " + s_CurrentService + '.';
                o_SelectedServiceNeedsMoreParameters = true;
            }

            return response;
        }

        // $G$ DSN-002 (-10) There is no separation between the project of the garage logic and the UI project.
        // $G$ CSS-999 (-5) If you use string as a condition --> then you should have use constant here.
        // $G$ DSN-007 (-10) This method is too long, should be divided into several methods.
        private static object GetInputParameterFromTheUser(Garage i_Garage, string i_RecentUserInputParameter, out bool o_CurrentServiceNeedsMoreInputParametersFromTheUser)
        {
            object response;

			if (s_CurrentService != null)
			{
                if (i_RecentUserInputParameter.ToUpper() == "CANCEL")
                {
                    o_CurrentServiceNeedsMoreInputParametersFromTheUser = false;
                    resetServiceParameters();
                    response = null;
                }
                else
                {
                    const string k_ResponseNameOfOwner = "Owner's name: ";
                    const string k_ResponsePhoneOfOwner = "Owner's phone number: ";
                    const string k_ResponseInputMustBeAValidFloatNumber = "Input must be a valid float number: ";
                    string responseTheGarageDoesNotOwnVehicleWithThisLicenseNumber = "The garage does not own vehicle with this license number " + i_RecentUserInputParameter + ": ";
					StringWriter stringWriter = new StringWriter();

					switch (s_CurrentService)
					{
						case Garage.eService.EnterNewVehicleIntoTheGarage:
							if (s_TypeOfVehicleToEnterIntoTheGarage == null)
							{
								long indexOfSelectedTypeOfVehicle = Garage.NamesOfSupportedTypesOfVehicles.Length <= 9 ?
																	i_RecentUserInputParameter[0] - '0' :
																	long.Parse(i_RecentUserInputParameter);
								if (indexOfSelectedTypeOfVehicle < 1 || indexOfSelectedTypeOfVehicle > Garage.NamesOfSupportedTypesOfVehicles.Length)
								{
									Console.Clear();
									response = VehicleTypeMessage;
									o_CurrentServiceNeedsMoreInputParametersFromTheUser = true;
								}
								else
								{
									Thread.Sleep(k_MenuDelay);
									string nameOfSelectedTypeOfVehicle = Garage.NamesOfSupportedTypesOfVehicles[indexOfSelectedTypeOfVehicle - 1];
									s_TypeOfVehicleToEnterIntoTheGarage = Garage.GetEnumVehicleFromString(nameOfSelectedTypeOfVehicle);
									s_TheVehicleToEnterIntoTheGarageOperatesOn = Garage.GetSourceOfEnergy(s_TypeOfVehicleToEnterIntoTheGarage.Value);
									s_AbstractVehicleToEnterIntoTheGarage = Garage.GetEnumAbstractVehicle(s_TypeOfVehicleToEnterIntoTheGarage.Value);
									s_CurrentServiceParameterNumber = 2;
									s_CurrentServiceParameter = Garage.eServiceParameter.NameOfModel;
									stringWriter.WriteLine();
									stringWriter.WriteLine();
									stringWriter.WriteLine();
									stringWriter.WriteLine(nameOfSelectedTypeOfVehicle);
									stringWriter.WriteLine(new string('-', nameOfSelectedTypeOfVehicle.Length));
									stringWriter.Write(Environment.NewLine + "Model's name: ");
									response = stringWriter;
									o_CurrentServiceNeedsMoreInputParametersFromTheUser = true;
								}
							}
							else if (s_NameOfModel == null)
							{
								s_NameOfModel = i_RecentUserInputParameter;
								s_CurrentServiceParameterNumber = 3;
								s_CurrentServiceParameter = Garage.eServiceParameter.NumberOfLicense;
								response = Environment.NewLine + "License Number: ";
								o_CurrentServiceNeedsMoreInputParametersFromTheUser = true;
							}
							else if (s_NumberOfLicense == null)
							{
								s_NumberOfLicense = i_RecentUserInputParameter;
								s_CurrentServiceParameterNumber = 4;
								s_CurrentServiceParameter = Garage.eServiceParameter.NameOfWheelManufacturer;
								response = Environment.NewLine + "Wheel manufacturer's name: ";
								o_CurrentServiceNeedsMoreInputParametersFromTheUser = true;
							}
							else if (s_NameOfWheelManufacturer == null)
							{
								s_NameOfWheelManufacturer = i_RecentUserInputParameter;
								s_CurrentServiceParameterNumber = 5;
								s_CurrentServiceParameter = Garage.eServiceParameter.WheelsAirPressures;
								s_WheelsAirPressures = new float[Vehicle.GetNumberOfWheelsOf(s_TypeOfVehicleToEnterIntoTheGarage.Value)];
								response = Environment.NewLine + string.Format("Current Air Pressure out of maximum {0} for wheel No. 1: ",
								Vehicle.GetMaximumWheelAirPressureOf(s_TypeOfVehicleToEnterIntoTheGarage.Value)/*, s_WheelsAirPressures.Length*/);
								o_CurrentServiceNeedsMoreInputParametersFromTheUser = true;
							}
							else if (s_CurrentWheelIndex < s_WheelsAirPressures.Length)
							{
                                if (float.TryParse(i_RecentUserInputParameter, out s_WheelsAirPressures[s_CurrentWheelIndex]))
                                {
									s_CurrentWheelIndex++;
									if (s_CurrentWheelIndex < s_WheelsAirPressures.Length)
									{
										response = string.Format("Current Air Pressure out of maximum {0} for wheel No. {1}: ",
										Vehicle.GetMaximumWheelAirPressureOf(s_TypeOfVehicleToEnterIntoTheGarage.Value), s_CurrentWheelIndex + 1/*, s_WheelsAirPressures.Length*/);
										o_CurrentServiceNeedsMoreInputParametersFromTheUser = true;
									}
									else switch (s_TheVehicleToEnterIntoTheGarageOperatesOn)
									{
										case Garage.eOperatesOn.Fuel:
											s_CurrentServiceParameter = Garage.eServiceParameter.RemainingAmountOfFuelInTheTank;
											response = Environment.NewLine + string.Format("Tank's remaining amount of fuel out of maximum {0} liters: ",
												Garage.GetCapacityOfTank(s_TypeOfVehicleToEnterIntoTheGarage.Value));
											o_CurrentServiceNeedsMoreInputParametersFromTheUser = true;
											break;
										case Garage.eOperatesOn.Electricity:
											s_CurrentServiceParameter = Garage.eServiceParameter.RemainingNumberOfHoursForLifeTimeOfBattery;
											response = Environment.NewLine + string.Format("Battery's remaining operation time out of maximum {0} hours: ",
												Garage.GetMaximumNumberOfHoursForLifeTimeOfBattery(s_TypeOfVehicleToEnterIntoTheGarage.Value));
											o_CurrentServiceNeedsMoreInputParametersFromTheUser = true;
											break;
										default:
											throw new UnreachableCodeReachedException();
									}
                                }
                                else
                                {
                                    response = k_ResponseInputMustBeAValidFloatNumber;
                                    o_CurrentServiceNeedsMoreInputParametersFromTheUser = true;
                                }
							}
							else if (eitherRemainingAmountOfFuelInTankOrNumberOfHoursInBatteryEqualsNull)
							{
								switch (s_TheVehicleToEnterIntoTheGarageOperatesOn)
								{
									case Garage.eOperatesOn.Fuel:
										s_RemainingAmountOfFuelInTheTank = Parse.Float(i_RecentUserInputParameter);
                                        if (s_RemainingAmountOfFuelInTheTank == null)
                                        {
                                            response = k_ResponseInputMustBeAValidFloatNumber;
                                            o_CurrentServiceNeedsMoreInputParametersFromTheUser = true;
                                            goto returnResponse;
                                        }

									break;
									case Garage.eOperatesOn.Electricity:
										s_RemainingNumberOfHoursForLifeTimeOfBattery = Parse.Float(i_RecentUserInputParameter);
                                        if (s_RemainingNumberOfHoursForLifeTimeOfBattery == null)
                                        {
                                            response = k_ResponseInputMustBeAValidFloatNumber;
                                            o_CurrentServiceNeedsMoreInputParametersFromTheUser = true;
                                            goto returnResponse;
                                        }

									break;
									default:
										throw new UnreachableCodeReachedException();
								}

								s_CurrentServiceParameterNumber = 6;

								switch (s_AbstractVehicleToEnterIntoTheGarage)
								{
									case Vehicle.eAbstractVehicle.Car:
										s_CurrentServiceParameter = Garage.eServiceParameter.NewCarColor;
										stringWriter.WriteLine();
										stringWriter.Write("Car's color (");
										for (long i = 0; i < Enum<Car.eColor>.Names.Length; i++)
										{
											stringWriter.Write(Enum<Car.eColor>.Names[i]);
											if (i < Enum<Car.eColor>.Names.Length - 1)
											{
												stringWriter.Write(", ");
											}
										}

										stringWriter.Write("): ");
										response = stringWriter;
									break;
									case Vehicle.eAbstractVehicle.Motorcycle:
										s_CurrentServiceParameter = Garage.eServiceParameter.NewMotorcycleTypeOfLicense;
										stringWriter.WriteLine();
										stringWriter.Write("Motorcycle's license type (");
										for (long i = 0; i < Enum<Motorcycle.eTypeOfLicense>.Names.Length; i++)
										{
											stringWriter.Write(Enum<Motorcycle.eTypeOfLicense>.Names[i]);
											if (i < Enum<Motorcycle.eTypeOfLicense>.Names.Length - 1)
											{
												stringWriter.Write(", ");
											}
										}

										stringWriter.Write("): ");
										response = stringWriter;
									break;
									case Vehicle.eAbstractVehicle.Truck:
										s_CurrentServiceParameter = Garage.eServiceParameter.NewTruckContainsDangerousSubstances;
										response = Environment.NewLine + "Does the truck contain dangerous substances? (Y/N): ";
									break;
									default:
										throw new UnreachableCodeReachedException();
								}

								o_CurrentServiceNeedsMoreInputParametersFromTheUser = true;
							}
							else switch (s_AbstractVehicleToEnterIntoTheGarage)
							{
								case Vehicle.eAbstractVehicle.Car:
									if (s_NewCarColor == null)
									{
										s_NewCarColor = Enum<Car.eColor>.Parse(i_RecentUserInputParameter);
										s_CurrentServiceParameterNumber = 7;
										s_CurrentServiceParameter = Garage.eServiceParameter.NewCarNumberOfDoors;
										response = Environment.NewLine + string.Format("Number of doors ({0} - {1}): ", Car.k_MinimumNumberOfDoors, Car.k_MaximumNumberOfDoors);
										o_CurrentServiceNeedsMoreInputParametersFromTheUser = true;
									}
									else if (s_NewCarNumberOfDoors == null)
									{
										s_NewCarNumberOfDoors = byte.Parse(i_RecentUserInputParameter);
										s_CurrentServiceParameterNumber = 8;
										s_CurrentServiceParameter = Garage.eServiceParameter.NameOfOwner;
										response = Environment.NewLine + k_ResponseNameOfOwner;
										o_CurrentServiceNeedsMoreInputParametersFromTheUser = true;
									}
									else if (s_NameOfOwner == null)
									{
										s_NameOfOwner = i_RecentUserInputParameter;
										s_CurrentServiceParameterNumber = 9;
										s_CurrentServiceParameter = Garage.eServiceParameter.PhoneOfOwner;
										response = Environment.NewLine + k_ResponsePhoneOfOwner;
										o_CurrentServiceNeedsMoreInputParametersFromTheUser = true;
									}
									else if (s_PhoneOfOwner == null)
									{
										s_PhoneOfOwner = i_RecentUserInputParameter;
										s_CurrentServiceParameterNumber = 10;
										switch (s_TheVehicleToEnterIntoTheGarageOperatesOn)
										{
											case Garage.eOperatesOn.Fuel:
												response = i_Garage.Enter(new CarThatOperatesOnFuel(s_NameOfModel, s_NumberOfLicense, s_NameOfWheelManufacturer,
												s_WheelsAirPressures, s_RemainingAmountOfFuelInTheTank.Value, s_NewCarColor.Value, s_NewCarNumberOfDoors.Value),
												s_NameOfOwner, s_PhoneOfOwner);
											break;
											case Garage.eOperatesOn.Electricity:
												response = i_Garage.Enter(new ElectricCar(s_NameOfModel, s_NumberOfLicense, s_NameOfWheelManufacturer,
												s_WheelsAirPressures, s_RemainingNumberOfHoursForLifeTimeOfBattery.Value, s_NewCarColor.Value, s_NewCarNumberOfDoors.Value),
												s_NameOfOwner, s_PhoneOfOwner);
											break;
											default:
												throw new UnreachableCodeReachedException();
										}

										o_CurrentServiceNeedsMoreInputParametersFromTheUser = false;
										resetServiceParameters();
									}
									else
									{
										throw new UnreachableCodeReachedException();
									}

								break;
								case Vehicle.eAbstractVehicle.Motorcycle:
									if (s_NewMotorcycleTypeOfLicense == null)
									{
										s_NewMotorcycleTypeOfLicense = Enum<Motorcycle.eTypeOfLicense>.Parse(i_RecentUserInputParameter);
										s_CurrentServiceParameterNumber = 7;
										s_CurrentServiceParameter = Garage.eServiceParameter.NewMotorcycleCapacityOfEngine;
										response = Environment.NewLine + "Motorcycle's engine capacity (cc): ";
										o_CurrentServiceNeedsMoreInputParametersFromTheUser = true;
									}
									else if (s_NewMotorcycleCapacityOfEngine == null)
									{
										s_NewMotorcycleCapacityOfEngine = int.Parse(i_RecentUserInputParameter);
										s_CurrentServiceParameterNumber = 8;
										s_CurrentServiceParameter = Garage.eServiceParameter.NameOfOwner;
										response = Environment.NewLine + k_ResponseNameOfOwner;
										o_CurrentServiceNeedsMoreInputParametersFromTheUser = true;
									}
									else if (s_NameOfOwner == null)
									{
										s_NameOfOwner = i_RecentUserInputParameter;
										s_CurrentServiceParameterNumber = 9;
										s_CurrentServiceParameter = Garage.eServiceParameter.PhoneOfOwner;
										response = Environment.NewLine + k_ResponsePhoneOfOwner;
										o_CurrentServiceNeedsMoreInputParametersFromTheUser = true;
									}
									else if (s_PhoneOfOwner == null)
									{
										s_PhoneOfOwner = i_RecentUserInputParameter;
										s_CurrentServiceParameterNumber = 10;
										switch (s_TheVehicleToEnterIntoTheGarageOperatesOn)
										{
											case Garage.eOperatesOn.Fuel:
												response = i_Garage.Enter(new MotorcycleThatOperatesOnFuel(s_NameOfModel, s_NumberOfLicense, s_NameOfWheelManufacturer,
												s_WheelsAirPressures, s_RemainingAmountOfFuelInTheTank.Value, s_NewMotorcycleTypeOfLicense.Value, s_NewMotorcycleCapacityOfEngine.Value),
												s_NameOfOwner, s_PhoneOfOwner);
											break;
											case Garage.eOperatesOn.Electricity:
												response = i_Garage.Enter(new ElectricMotorcycle(s_NameOfModel, s_NumberOfLicense, s_NameOfWheelManufacturer,
												s_WheelsAirPressures, s_RemainingNumberOfHoursForLifeTimeOfBattery.Value, s_NewMotorcycleTypeOfLicense.Value, s_NewMotorcycleCapacityOfEngine.Value),
												s_NameOfOwner, s_PhoneOfOwner);
											break;
											default:
												throw new UnreachableCodeReachedException();
										}

										o_CurrentServiceNeedsMoreInputParametersFromTheUser = false;
										resetServiceParameters();
									}
									else
									{
										throw new UnreachableCodeReachedException();
									}

								break;
								case Vehicle.eAbstractVehicle.Truck:
									if (s_NewTruckContainsDangerousSubstances == null)
									{
                                        switch (i_RecentUserInputParameter.ToUpper())
                                        {
                                            case "Y":
                                               s_NewTruckContainsDangerousSubstances = true;
                                            break;
                                            case "N":
                                               s_NewTruckContainsDangerousSubstances = false;
                                            break;
                                            default:
                                               Console.Write("\b \b");
                                               response = string.Empty;
                                               o_CurrentServiceNeedsMoreInputParametersFromTheUser = true;
                                            goto returnResponse;
                                        }

										s_CurrentServiceParameterNumber = 7;
										s_CurrentServiceParameter = Garage.eServiceParameter.NewTruckVolumeOfCargo;
										response = Environment.NewLine + "Truck's volume of cargo: ";
										o_CurrentServiceNeedsMoreInputParametersFromTheUser = true;
									}
									else if (s_NewTruckVolumeOfCargo == null)
									{
										s_NewTruckVolumeOfCargo = float.Parse(i_RecentUserInputParameter);
										s_CurrentServiceParameterNumber = 8;
										s_CurrentServiceParameter = Garage.eServiceParameter.NameOfOwner;
										response = Environment.NewLine + k_ResponseNameOfOwner;
										o_CurrentServiceNeedsMoreInputParametersFromTheUser = true;
									}
									else if (s_NameOfOwner == null)
									{
										s_NameOfOwner = i_RecentUserInputParameter;
										s_CurrentServiceParameterNumber = 9;
										s_CurrentServiceParameter = Garage.eServiceParameter.PhoneOfOwner;
										response = Environment.NewLine + k_ResponsePhoneOfOwner;
										o_CurrentServiceNeedsMoreInputParametersFromTheUser = true;
									}
									else if (s_PhoneOfOwner == null)
									{
										s_PhoneOfOwner = i_RecentUserInputParameter;
										s_CurrentServiceParameterNumber = 10;
										switch (s_TheVehicleToEnterIntoTheGarageOperatesOn)
										{
											case Garage.eOperatesOn.Fuel:
											response = i_Garage.Enter(new TruckThatOperatesOnFuel(s_NameOfModel, s_NumberOfLicense, s_NameOfWheelManufacturer,
												s_WheelsAirPressures, s_RemainingAmountOfFuelInTheTank.Value, s_NewTruckContainsDangerousSubstances.Value, s_NewTruckVolumeOfCargo.Value),
												s_NameOfOwner, s_PhoneOfOwner);
											break;
											case Garage.eOperatesOn.Electricity:
											response = i_Garage.Enter(new ElectricTruck(s_NameOfModel, s_NumberOfLicense, s_NameOfWheelManufacturer,
												s_WheelsAirPressures, s_RemainingNumberOfHoursForLifeTimeOfBattery.Value, s_NewTruckContainsDangerousSubstances.Value, s_NewTruckVolumeOfCargo.Value),
												s_NameOfOwner, s_PhoneOfOwner);
											break;
											default:
												throw new UnreachableCodeReachedException();
										}

										o_CurrentServiceNeedsMoreInputParametersFromTheUser = false;
										resetServiceParameters();
									}
									else
									{
										throw new UnreachableCodeReachedException();
									}

								break;
								default:
									throw new UnreachableCodeReachedException();
							}

						break;
						case Garage.eService.ListLicenseNumbersOfVehicles:
							long indexOfeStatusOfVehicleFilter = Enum<Garage.eStatusOfVehicleFilter>.Values.Length <= 9 ?
																 i_RecentUserInputParameter[0] - '0' :
																 long.Parse(i_RecentUserInputParameter);
							if (indexOfeStatusOfVehicleFilter < 1 || indexOfeStatusOfVehicleFilter > Enum<Garage.eStatusOfVehicleFilter>.Values.Length)
							{
								Console.Clear();
								response = VehicleStatusFilterMessage;
								o_CurrentServiceNeedsMoreInputParametersFromTheUser = true;
							}
							else
							{
								Thread.Sleep(k_MenuDelay);
								stringWriter.WriteLine();
								stringWriter.WriteLine();
								stringWriter.WriteLine("License Numbers of vehicles in the garage:");
								stringWriter.WriteLine("-----------------------------------------");
								stringWriter.WriteLine(i_Garage.GetLicenseNumbersInASingleStringByFilter(Enum<Garage.eStatusOfVehicleFilter>.Values[indexOfeStatusOfVehicleFilter - 1]));
								response = stringWriter;
								o_CurrentServiceNeedsMoreInputParametersFromTheUser = false;
								resetServiceParameters();
							}

						break;
						case Garage.eService.ChangeTheStatusOfAVehicle:
                            if (s_NumberOfLicense == null)
                            {
                                if (i_Garage.AlreadyOwnsVehicleWhoseLicenseNumberIs(i_RecentUserInputParameter))
                                {
                                    s_NumberOfLicense = i_RecentUserInputParameter;
                                    s_CurrentServiceParameterNumber = 2;
                                    s_CurrentServiceParameter = Garage.eServiceParameter.Status;
                                    stringWriter.WriteLine();
                                    stringWriter.WriteLine("Possible statuses:");
                                    stringWriter.WriteLine();
                                    for (long i = 0; i < Enum<Garage.eStatusOfVehicle>.Names.Length; i++)
                                    {
                                        stringWriter.WriteLine((i + 1) + ". " + Enum<Garage.eStatusOfVehicle>.Names[i]);
                                    }

                                    stringWriter.WriteLine();
                                    stringWriter.WriteLine("Current status: " + i_Garage.GetStatusOfAVehicleWhoseLicenseNumberIs(s_NumberOfLicense));
                                    stringWriter.Write("New status: ");
							        response = stringWriter;
							        o_CurrentServiceNeedsMoreInputParametersFromTheUser = true;
                                }
                                else
                                {
                                    response = responseTheGarageDoesNotOwnVehicleWithThisLicenseNumber;
                                    o_CurrentServiceNeedsMoreInputParametersFromTheUser = true;
                                }
                            }
                            else
                            {
                                long indexOfeStatusOfVehicle = Enum<Garage.eStatusOfVehicle>.Values.Length <= 9 ?
                                                               i_RecentUserInputParameter[0] - '0' :
                                                               long.Parse(i_RecentUserInputParameter);
                                if (indexOfeStatusOfVehicle < 1 || indexOfeStatusOfVehicle > Enum<Garage.eStatusOfVehicle>.Values.Length)
                                {
                                    if (Enum<Garage.eStatusOfVehicle>.Values.Length <= 9)
                                    {
                                        Console.CursorLeft = s_ConsoleCursorLeftBeforeRead;
                                        Console.Write(" \b");
                                        response = string.Empty;
                                    }
                                    else
                                    {
                                        response = "Input must be a number from the above list: ";
                                    }

                                    o_CurrentServiceNeedsMoreInputParametersFromTheUser = true;
                                }
                                else
                                {
                                    i_Garage.ChangeStatusOfVehicleWhoseLicenseNumberIs(s_NumberOfLicense, Enum<Garage.eStatusOfVehicle>.Values[indexOfeStatusOfVehicle - 1]);
                                    response = Environment.NewLine + "Status changed to " + Enum<Garage.eStatusOfVehicle>.Values[indexOfeStatusOfVehicle - 1] + Environment.NewLine;
                                    o_CurrentServiceNeedsMoreInputParametersFromTheUser = false;
                                    resetServiceParameters();
                                }
                            }

						break;
						case Garage.eService.InflateAirPressureOfAVehicleWheelsToMaximum:
                            if (s_NumberOfLicense == null)
                            {
                                if (i_Garage.AlreadyOwnsVehicleWhoseLicenseNumberIs(i_RecentUserInputParameter))
                                {
                                    s_NumberOfLicense = i_RecentUserInputParameter;
                                    s_CurrentServiceParameterNumber = 2;
                                    i_Garage.InflateAllWheelsToTheirMaximumOfVehicleWhoseLicenseNumberIs(s_NumberOfLicense);
                                    response = Environment.NewLine + "All wheels of vehicle with the license number " + s_NumberOfLicense + " have been inflated to maximum air pressure." + Environment.NewLine;
                                    o_CurrentServiceNeedsMoreInputParametersFromTheUser = false;
                                    resetServiceParameters();
                                }
                                else
                                {
							        response = responseTheGarageDoesNotOwnVehicleWithThisLicenseNumber;
							        o_CurrentServiceNeedsMoreInputParametersFromTheUser = true;
                                }
                            }
                            else
                            {
                                throw new UnreachableCodeReachedException();
                            }

						break;
						case Garage.eService.RefuelVehicle:
                            if (s_NumberOfLicense == null)
                            {
                                if (i_Garage.AlreadyOwnsVehicleWhoseLicenseNumberIs(i_RecentUserInputParameter))
                                {
                                    s_NumberOfLicense = i_RecentUserInputParameter;
                                    s_CurrentServiceParameterNumber = 2;
                                    s_CurrentServiceParameter = Garage.eServiceParameter.TypeOfFuel;
                                    stringWriter.Write("Fuel Type (");
                                    for (long i = 0; i < Enum<VehicleThatOperatesOnFuel.eTypeOfFuel>.Names.Length; i++)
                                    {
                                        stringWriter.Write(Enum<VehicleThatOperatesOnFuel.eTypeOfFuel>.Names[i]);
                                        if (i < Enum<VehicleThatOperatesOnFuel.eTypeOfFuel>.Names.Length - 1)
                                        {
                                            stringWriter.Write(", ");
                                        }
                                    }

                                    stringWriter.Write("): ");
                                    response = stringWriter;
                                    o_CurrentServiceNeedsMoreInputParametersFromTheUser = true;
                                }
                                else
                                {
							        response = responseTheGarageDoesNotOwnVehicleWithThisLicenseNumber;
							        o_CurrentServiceNeedsMoreInputParametersFromTheUser = true;
                                }
                            }
                            else if (s_TypeOfFuel == null)
                            {
                                s_TypeOfFuel = Enum<VehicleThatOperatesOnFuel.eTypeOfFuel>.Parse(i_RecentUserInputParameter);
                                s_CurrentServiceParameterNumber = 3;
                                s_CurrentServiceParameter = Garage.eServiceParameter.AmountOfFuelToFillTheTankInLiters;
                                Vehicle.Information information = i_Garage.GetFullInformationAboutAVehicleWhoseLicenseNumberIs(s_NumberOfLicense).InformationAboutActualVehicle;
                                stringWriter.WriteLine("Remaining amount of fuel in the tank {0} out of {1} liters.", information.Fuel.RemainingAmountOfFuel, information.Fuel.CapacityOfTank);
                                stringWriter.Write("Amount of fuel to fill the tank in liters: ");
                                response = stringWriter;
                                o_CurrentServiceNeedsMoreInputParametersFromTheUser = true;
                            }
                            else if (s_AmountOfFuelToFillTheTankInLiters == null)
                            {
                                s_AmountOfFuelToFillTheTankInLiters = float.Parse(i_RecentUserInputParameter);
                                s_CurrentServiceParameterNumber = 4;
                                const bool v_ThrowProperException = true;
                                response = i_Garage.RefuelVehicleWhoseLicenseNumberIs(s_NumberOfLicense, s_TypeOfFuel.Value, s_AmountOfFuelToFillTheTankInLiters.Value, not(v_ThrowProperException));
                                o_CurrentServiceNeedsMoreInputParametersFromTheUser = false;
                                resetServiceParameters();
                            }
                            else
                            {
                                throw new UnreachableCodeReachedException();
                            }

						break;
						case Garage.eService.ChargeElectricVehicle:
							if (s_NumberOfLicense == null)
                            {
                                if (i_Garage.AlreadyOwnsVehicleWhoseLicenseNumberIs(i_RecentUserInputParameter))
                                {
                                    s_NumberOfLicense = i_RecentUserInputParameter;
                                    s_CurrentServiceParameterNumber = 2;
                                    s_CurrentServiceParameter = Garage.eServiceParameter.NumberOfMinutesToAddToTheBattery;
                                    Vehicle.Information information = i_Garage.GetFullInformationAboutAVehicleWhoseLicenseNumberIs(s_NumberOfLicense).InformationAboutActualVehicle;
                                    stringWriter.WriteLine("Remaining battery operating time {0} out of {1} hours.", information.Battery.RemainingNumberOfHoursForLifeOfBattery, information.Battery.MaximumNumberOfHoursForLifeOfBattery);
                                    stringWriter.Write("Number of minutes to add to the operating time of the battery: ");
                                    response = stringWriter;
                                    o_CurrentServiceNeedsMoreInputParametersFromTheUser = true;
                                }
                                else
                                {
                                    response = responseTheGarageDoesNotOwnVehicleWithThisLicenseNumber;
                                    o_CurrentServiceNeedsMoreInputParametersFromTheUser = true;
                                }
                            }
                            else if (s_NumberOfMinutesToAddToTheBattery == null)
                            {
                                s_NumberOfMinutesToAddToTheBattery = float.Parse(i_RecentUserInputParameter);
                                s_CurrentServiceParameterNumber = 3;
                                const bool v_ThrowProperException = true;
                                response = i_Garage.ChargeElectricVehicleWhoseLicenseNumberIs(s_NumberOfLicense, s_NumberOfMinutesToAddToTheBattery.Value, not(v_ThrowProperException));
                                o_CurrentServiceNeedsMoreInputParametersFromTheUser = false;
                                resetServiceParameters();
                            }
                            else
                            {
                                throw new UnreachableCodeReachedException();
                            }

						break;
						case Garage.eService.DisplayFullInformationAboutSomeVehicle:
                            if (i_Garage.AlreadyOwnsVehicleWhoseLicenseNumberIs(i_RecentUserInputParameter))
                            {
                                stringWriter.WriteLine();
							    stringWriter.WriteLine();
							    stringWriter.Write(i_Garage.GetFullInformationAboutAVehicleWhoseLicenseNumberIs(i_RecentUserInputParameter));
							    response = stringWriter;
							    o_CurrentServiceNeedsMoreInputParametersFromTheUser = false;
							    resetServiceParameters();
                            }
                            else
                            {
							    response = responseTheGarageDoesNotOwnVehicleWithThisLicenseNumber;
                                o_CurrentServiceNeedsMoreInputParametersFromTheUser = true;
                            }

						break;
						default:
							throw new UnreachableCodeReachedException();
					}
                }
			}
			else
			{
				response = "What is the requested service?";
				o_CurrentServiceNeedsMoreInputParametersFromTheUser = false;
			}

            returnResponse:
            return response;
        }

        private static bool eitherRemainingAmountOfFuelInTankOrNumberOfHoursInBatteryEqualsNull
        {
            get
            {
				bool answer;
				switch (s_TheVehicleToEnterIntoTheGarageOperatesOn)
				{
					case Garage.eOperatesOn.Fuel:
						answer = s_RemainingAmountOfFuelInTheTank == null;
					break;
					case Garage.eOperatesOn.Electricity:
						answer = s_RemainingNumberOfHoursForLifeTimeOfBattery == null;
					break;
					default:
						throw new UnreachableCodeReachedException();
				}

				return answer;
            }
        }
    }
}