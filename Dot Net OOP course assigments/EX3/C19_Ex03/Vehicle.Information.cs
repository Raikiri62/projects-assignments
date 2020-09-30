namespace C19_Ex03_GarageLogic
{
    using System.IO;
    using System.Text;
    using System.Collections.Generic;

    public partial class Vehicle
    {
        public struct Information
        {
            private readonly string r_NumberOfLicense;
            private readonly string r_NameOfModel;
            private readonly IEnumerable<Wheel.Information> r_WheelsInformation;
            private readonly object r_FuelOrBattery;
            private readonly object r_MoreInformation;

            public Information(string i_NumberOfLicense, string i_NameOfModel, IEnumerable<Wheel.Information> i_WheelsInformation, object i_FuelOrBattery, object i_MoreInformation)
            {
                r_NumberOfLicense = i_NumberOfLicense;
                r_NameOfModel = i_NameOfModel;
                r_WheelsInformation = i_WheelsInformation;
                r_FuelOrBattery = i_FuelOrBattery;
                r_MoreInformation = i_MoreInformation;
            }

            public string NumberOfLicense
            {
                get { return r_NumberOfLicense; }
            }

            public string NameOfModel
            {
                get { return r_NameOfModel; }
            }

            public IEnumerable<Wheel.Information> WheelsInformation
            {
                get { return r_WheelsInformation; }
            }

            public StringBuilder WheelsInformationAsStringBuilder
            {
                get
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    ulong wheelNo = 1;

                    foreach (Wheel.Information currentWheelInformation in r_WheelsInformation)
                    {
                        string format = string.Format("Wheel No. {0}", wheelNo);
                        stringBuilder.Append(format);
                        stringBuilder.AppendLine();
                        stringBuilder.AppendLine(new string('-', format.Length));
                        stringBuilder.Append(currentWheelInformation);
						stringBuilder.AppendLine();
						stringBuilder.AppendLine();
                        wheelNo++;
                    }

                    return stringBuilder;
                }
            }

            public StringWriter WheelsInformationAsStringWriter
            {
                 get
                 {
                     StringWriter stringWriter = new StringWriter();
                     ulong wheelNo = 1;

                     foreach (Wheel.Information currentWheelInformation in r_WheelsInformation)
                     {
                         string format = string.Format("Wheel No. {0}", wheelNo);
                         stringWriter.Write(format);
                         stringWriter.WriteLine();
                         stringWriter.WriteLine(new string('-', format.Length));
                         stringWriter.Write(currentWheelInformation);
                         stringWriter.WriteLine();
                         stringWriter.WriteLine();
                         wheelNo++;
                     }

                     return stringWriter;
                 }
            }

            public string WheelsInformationAsString
            {
                get { return WheelsInformationAsStringWriter.ToString(); }
            }

            public VehicleThatOperatesOnFuel.Information Fuel
            {
                get { return (VehicleThatOperatesOnFuel.Information)r_FuelOrBattery; }
            }

            public ElectricVehicle.Information Battery
            {
                get { return (ElectricVehicle.Information)r_FuelOrBattery; }
            }

            public override string ToString()
            {
                return string.Format(
@"
License Number: {0}
Model Name: {1}

{2}
{3}

{4}
", r_NumberOfLicense, r_NameOfModel, WheelsInformationAsString, r_FuelOrBattery, r_MoreInformation);
            }
        }
    }
}