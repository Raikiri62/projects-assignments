namespace C19_Ex03_GarageLogic
{
    public partial class Garage
    {
        public partial class Vehicle
        {
            private C19_Ex03_GarageLogic.Vehicle m_vehicle;
            private string m_NameOfOwner;
            private string m_PhoneOfOwner;
            private Garage.eStatusOfVehicle m_status;

            public Vehicle(C19_Ex03_GarageLogic.Vehicle i_vehicle, string i_NameOfOwner, string i_PhoneOfOwner)
            {
                m_vehicle = i_vehicle;
                m_NameOfOwner = i_NameOfOwner;
                m_PhoneOfOwner = i_PhoneOfOwner;
                m_status = Garage.eStatusOfVehicle.InRepair;
            }

            public C19_Ex03_GarageLogic.Vehicle ActualVehicle
            {
                get { return m_vehicle; }
            }

            public string NameOfOwner
            {
                get
                {
                    return m_NameOfOwner;
                }
            }

            public string PhoneOfOwner
            {
                get
                {
                    return m_PhoneOfOwner;
                }
            }

            public eStatusOfVehicle Status
            {
                get { return m_status; }
                set { m_status = value; }
            }

            public Information Info
            {
                get
                {
                    return new Information(m_NameOfOwner, m_PhoneOfOwner, m_status, m_vehicle.Info);
                }
            }
        }
    }
}