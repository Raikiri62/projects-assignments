namespace C19_Ex03_GarageLogic
{
    public partial struct Truck
    {
        public struct Information
        {
            private readonly bool r_ContainsDangerousSubstances;
            private readonly float r_VolumeOfCargo;

            public Information(bool i_ContainsDangerousSubstances, float i_VolumeOfCargo)
            {
                r_ContainsDangerousSubstances = i_ContainsDangerousSubstances;
                r_VolumeOfCargo = i_VolumeOfCargo;
            }

            public bool ContainsDangerousSubstances
            {
                get { return r_ContainsDangerousSubstances; }
            }

            public float VolumeOfCargo
            {
                get { return r_VolumeOfCargo; }
            }

			public override string ToString()
            {
                return string.Format(
@"
Contains dangerous substances: {0}
Volume of Cargo: {1}
", r_ContainsDangerousSubstances ? "Yes" : "No", r_VolumeOfCargo);
			}
        }
    }
}