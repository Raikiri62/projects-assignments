namespace C19_Ex03_GarageLogic
{
    using System;
    using System.IO;

    // $G$ DSN-999 (-5) This class should have been abstract.
    public partial struct Motorcycle
    {
        private Motorcycle.eTypeOfLicense m_license;
        private int m_CapacityOfEngine;

        internal Motorcycle(Motorcycle.eTypeOfLicense i_license, int i_CapacityOfEngine)
        {
            if (i_CapacityOfEngine <= 0)
            {
                throw new ArgumentIsNotPositiveNumberException("i_CapacityOfEngine", i_CapacityOfEngine);
            }

            m_license = i_license;
            m_CapacityOfEngine = i_CapacityOfEngine;
        }

        internal Motorcycle(TextReader i_TextReader)
        {
            if (i_TextReader == null)
            {
                throw new ArgumentNullException("i_TextReader", "i_TextReader must not be null.");
            }

            this = new Motorcycle(Enum<Motorcycle.eTypeOfLicense>.Parse(i_TextReader.ReadLine()), int.Parse(i_TextReader.ReadLine()));
        }

        internal Motorcycle.eTypeOfLicense License
        {
            get { return m_license; }
            set { m_license = value; }
        }

        internal int CapacityOfEngine
        {
            get { return m_CapacityOfEngine; }
            set { m_CapacityOfEngine = value; }
        }

        internal Motorcycle.Information Info
        {
            get { return new Motorcycle.Information(m_license, m_CapacityOfEngine); }
        }

        public override string ToString()
        {
            return m_license + Environment.NewLine + m_CapacityOfEngine;
        }
    }
}