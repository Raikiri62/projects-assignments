namespace C19_Ex03_GarageLogic
{
    using System;

    internal class TheReferredVehicleByLicenseNumberDoesNotOperateOnFuelException : ArgumentException
    {
        internal TheReferredVehicleByLicenseNumberDoesNotOperateOnFuelException(string i_NumberOfLicense, string i_NameOfArgument)
            : base("The referred vehicle by license number " + i_NumberOfLicense + " does not operate on fuel.", i_NameOfArgument)
        {
        }
    }
}