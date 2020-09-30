namespace C19_Ex03_GarageLogic
{
    using System;

    public class TheGarageDoesNotOwnAVehicleWithThisLicenseNumberException : ArgumentException
    {
        public TheGarageDoesNotOwnAVehicleWithThisLicenseNumberException(string i_NumberOfLicense, string i_NameOfArgument)
            : base("The garage does not own a vehicle with this license number " + i_NumberOfLicense + '.', i_NameOfArgument)
        {
        }
    }
}