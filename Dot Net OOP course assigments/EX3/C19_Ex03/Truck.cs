namespace C19_Ex03_GarageLogic
{
    using System;
    using System.IO;

    // $G$ DSN-999 (-5) This class should have been abstract.
    public partial struct Truck
    {
        private bool m_ContainsDangerousSubstances;
        private float m_VolumeOfCargo;

        internal Truck(bool i_ContainsDangerousSubstances, float i_VolumeOfCargo)
        {
            m_ContainsDangerousSubstances = i_ContainsDangerousSubstances;
            m_VolumeOfCargo = i_VolumeOfCargo;
        }

        internal Truck(TextReader i_TextReader)
        {
            if (i_TextReader == null)
            {
                throw new ArgumentNullException("i_TextReader", "i_TextReader must not be null.");
            }

            this = new Truck(bool.Parse(i_TextReader.ReadLine()), float.Parse(i_TextReader.ReadLine()));
        }

        internal bool ContainsDangerousSubstances
        {
            get { return m_ContainsDangerousSubstances; }
            set { m_ContainsDangerousSubstances = value; }
        }

        internal float VolumeOfCargo
        {
            get { return m_VolumeOfCargo; }
            set { m_VolumeOfCargo = value; }
        }

        internal Truck.Information Info
        {
            get { return new Truck.Information(m_ContainsDangerousSubstances, m_VolumeOfCargo); }
        }

        public override string ToString()
        {
            return m_ContainsDangerousSubstances + Environment.NewLine + m_VolumeOfCargo;
        }
    }
}