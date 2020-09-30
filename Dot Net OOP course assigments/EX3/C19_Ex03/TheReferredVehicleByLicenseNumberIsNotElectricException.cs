namespace C19_Ex03_GarageLogic
{
    using System;

    internal class TheReferredVehicleByLicenseNumberIsNotElectricException : ArgumentException
    {
        internal TheReferredVehicleByLicenseNumberIsNotElectricException(string i_NumberOfLicense, string i_NameOfArgument)
            : base("The referred vehicle by license number " + i_NumberOfLicense + " is not electric.", i_NameOfArgument)
        {
        }
    }
}