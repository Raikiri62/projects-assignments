namespace C19_Ex03_GarageLogic
{
    public partial class Garage
    {
        public partial class Vehicle
        {
            public struct Information
            {
                private readonly string r_NameOfOwner;
                private readonly string r_PhoneOfOwner;
                private readonly Garage.eStatusOfVehicle r_StatusInGarage;
                private readonly C19_Ex03_GarageLogic.Vehicle.Information r_InformationAboutActualVehicle;

                public Information(string i_NameOfOwner, string i_PhoneOfOwner, Garage.eStatusOfVehicle i_StatusInGarage, C19_Ex03_GarageLogic.Vehicle.Information i_InformationAboutActualVehicle)
                {
                    r_NameOfOwner = i_NameOfOwner;
                    r_PhoneOfOwner = i_PhoneOfOwner;
                    r_StatusInGarage = i_StatusInGarage;
                    r_InformationAboutActualVehicle = i_InformationAboutActualVehicle;
                }

                public string NameOfOwner
                {
                    get { return r_NameOfOwner; }
                }

                public string PhoneOfOwner
                {
                    get { return r_PhoneOfOwner; }
                }

                public Garage.eStatusOfVehicle StatusInGarage
                {
                    get { return r_StatusInGarage; }
                }

                public C19_Ex03_GarageLogic.Vehicle.Information InformationAboutActualVehicle
                {
                    get { return r_InformationAboutActualVehicle; }
                }

                public override string ToString()
                {
                    return string.Format(
@"Name of Owner: {0}
Phone of Owner: {1}
Status in Garage: {2}
{3}", r_NameOfOwner, r_PhoneOfOwner, r_StatusInGarage, r_InformationAboutActualVehicle);
                }
            }
        }
    }
}