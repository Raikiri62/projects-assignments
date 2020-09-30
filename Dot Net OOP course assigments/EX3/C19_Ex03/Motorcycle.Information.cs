namespace C19_Ex03_GarageLogic
{
    public partial struct Motorcycle
    {
        public struct Information
        {
            private readonly eTypeOfLicense r_TypeOfLicense;
            private readonly int r_CapacityOfEngine;

            public Information(eTypeOfLicense i_TypeOfLicense, int i_CapacityOfEngine)
            {
                r_TypeOfLicense = i_TypeOfLicense;
                r_CapacityOfEngine = i_CapacityOfEngine;
            }

            public eTypeOfLicense License
            {
                get { return r_TypeOfLicense; }
            }

            public int CapacityOfEngine
            {
                get { return r_CapacityOfEngine; }
            }

			public override string ToString()
            {
                return string.Format(
@"
License Type: {0}
Capacity of Engine (cc): {1}
", r_TypeOfLicense, r_CapacityOfEngine);
			}
        }
    }
}