namespace C19_Ex03_GarageLogic
{
    public partial struct Car
    {
        public struct Information
        {
            private readonly eColor r_color;
            private readonly byte r_NumberOfDoors;

            public Information(eColor i_color, byte i_NumberOfDoors)
            {
                r_color = i_color;
                r_NumberOfDoors = i_NumberOfDoors;
            }

            public eColor Color
            {
                get { return r_color; }
            }

            public byte NumberOfDoors
            {
                get { return r_NumberOfDoors; }
            }

			public override string ToString()
            {
                return string.Format(
@"
Color: {0}
Number of Doors: {1}
", r_color, r_NumberOfDoors);
			}
        }
    }
}