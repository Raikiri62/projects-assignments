namespace C19_Ex03_GarageLogic
{
    using System;
    using System.IO;

    // $G$ DSN-999 (-5) This class should have been abstract.
    public partial struct Car
    {
        private Car.eColor m_color;
        private byte m_NumberOfDoors;

        public /*internal*/ const byte k_MinimumNumberOfDoors = 2;
        public /*internal*/ const byte k_MaximumNumberOfDoors = 5;

        internal Car(Car.eColor i_color, byte i_NumberOfDoors)
        {
            if (i_NumberOfDoors < k_MinimumNumberOfDoors || i_NumberOfDoors > k_MaximumNumberOfDoors)
            {
                throw new ValueOutOfRangeException("i_NumberOfDoors", i_NumberOfDoors, k_MinimumNumberOfDoors, k_MaximumNumberOfDoors);
            }
            m_color = i_color;
            m_NumberOfDoors = i_NumberOfDoors;
        }

        internal Car(TextReader i_TextReader)
        {
            if (i_TextReader == null)
            {
                throw new ArgumentNullException("i_TextReader", "i_TextReader must not be null.");
            }

            this = new Car(Enum<Car.eColor>.Parse(i_TextReader.ReadLine()), byte.Parse(i_TextReader.ReadLine()));
        }

        internal eColor Color
        {
            get { return m_color; }
            set { m_color = value; }
        }

        internal byte NumberOfDoors
        {
            get { return m_NumberOfDoors; }
            set { m_NumberOfDoors = value; }
        }

        internal Car.Information Info
        {
            get { return new Car.Information(m_color, m_NumberOfDoors); }
        }

        public override string ToString()
        {
            return m_color + Environment.NewLine + m_NumberOfDoors;
        }
    }
}