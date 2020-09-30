namespace C19_Ex03_GarageLogic
{
    using System;
    using System.IO;
    using System.Text;

    public partial struct Wheel
    {
        private readonly string r_NameOfManufacturer;
        private float m_CurrentAirPressure;
        private readonly float r_MaximumAirPressure;

        public Wheel(string i_NameOfManufacturer, float i_MaximumAirPressure)
        {
            r_NameOfManufacturer = i_NameOfManufacturer;
            m_CurrentAirPressure = i_MaximumAirPressure;
            r_MaximumAirPressure = i_MaximumAirPressure;

            validate(i_NameOfManufacturer, i_MaximumAirPressure);
        }

        public Wheel(string i_NameOfManufacturer, float i_CurrentAirPressure, float i_MaximumAirPressure)
        {
            r_NameOfManufacturer = i_NameOfManufacturer;
            m_CurrentAirPressure = i_CurrentAirPressure;
            r_MaximumAirPressure = i_MaximumAirPressure;

            validate(i_NameOfManufacturer, i_MaximumAirPressure);

            if (float.IsNaN(i_CurrentAirPressure))
            {
                throw new ArgumentNaNException("i_CurrentAirPressure");
            }

            if (float.IsInfinity(i_CurrentAirPressure))
            {
                throw new ArgumentInfinityException("i_CurrentAirPressure");
            }

            if (i_CurrentAirPressure < 0f || i_CurrentAirPressure > i_MaximumAirPressure)
            {
                throw new ValueOutOfRangeException("i_CurrentAirPressure", i_CurrentAirPressure, 0f, i_MaximumAirPressure);
            }
        }

        public Wheel(TextReader i_TextReader)
        {
            if (i_TextReader == null)
            {
                throw new ArgumentNullException("i_TextReader", "i_TextReader must not be null.");
            }

            this = new Wheel(i_TextReader.ReadLine(), float.Parse(i_TextReader.ReadLine()), float.Parse(i_TextReader.ReadLine()));
        }

        public Wheel(TextReader i_TextReader, float i_MaximumAirPressure)
        {
            if (i_TextReader == null)
            {
                throw new ArgumentNullException("i_TextReader", "i_TextReader must not be null.");
            }

            this = new Wheel(i_TextReader.ReadLine(), float.Parse(i_TextReader.ReadLine()), i_MaximumAirPressure);
        }

        private void validate(string i_NameOfManufacturer, float i_MaximumAirPressure)
        {
            if (i_NameOfManufacturer == null)
            {
                throw new ArgumentNullException("i_NameOfManufacturer", "i_NameOfManufacturer must not be null.");
            }

            if (i_NameOfManufacturer.Length == 0)
            {
                throw new ArgumentEmptyException("i_NameOfManufacturer");
            }

            if (float.IsNaN(i_MaximumAirPressure))
            {
                throw new ArgumentNaNException("i_MaximumAirPressure");
            }

            if (float.IsInfinity(i_MaximumAirPressure))
            {
                throw new ArgumentInfinityException("i_MaximumAirPressure");
            }

            if (i_MaximumAirPressure <= 0f)
            {
                throw new ArgumentIsNotPositiveNumberException("i_MaximumAirPressure", i_MaximumAirPressure);
            }
        }

        public string NameOfManufacturer
        {
            get { return r_NameOfManufacturer; }
        }

        public float CurrentAirPressure
        {
            get { return m_CurrentAirPressure; }
            set { m_CurrentAirPressure = value; }
        }

        public float MaximumAirPressureThatTheManufacturerDetermined
        {
            get { return r_MaximumAirPressure; }
        }

        public Wheel.eInflateStatus Inflate(float i_AmountOfAirToAddToTheWheel, bool i_ThrowProperExceptionOnError = true)
        {
            Wheel.eInflateStatus status;

            if (float.IsNaN(i_AmountOfAirToAddToTheWheel))
            {
                if (i_ThrowProperExceptionOnError)
                {
                    throw new ArgumentNaNException("i_AmountOfAirToAddToTheWheel");
                }
                status = Wheel.eInflateStatus.AmountOfAirToAddToTheWheelIsNan;
            }
            else if (float.IsInfinity(i_AmountOfAirToAddToTheWheel))
            {
                if (i_ThrowProperExceptionOnError)
                {
                    throw new ArgumentInfinityException("i_AmountOfAirToAddToTheWheel");
                }
                status = Wheel.eInflateStatus.AmountOfAirToAddToTheWheelIsInfinity;
            }
            else if (i_AmountOfAirToAddToTheWheel <= 0f)
            {
                if (i_ThrowProperExceptionOnError)
                {
                    throw new ArgumentIsNotPositiveNumberException("i_AmountOfAirToAddToTheWheel", i_AmountOfAirToAddToTheWheel, r_MaximumAirPressure - m_CurrentAirPressure);
                }
                status = Wheel.eInflateStatus.AmountOfAirToAddToTheWheelIsNotPositiveNumber;
            }
            else
            {
                if (m_CurrentAirPressure + i_AmountOfAirToAddToTheWheel > r_MaximumAirPressure)
                {
                    if (i_ThrowProperExceptionOnError)
                    {
                        const bool v_IncludeMin = true;
                        throw new ValueOutOfRangeException("i_AmountOfAirToAddToTheWheel", i_AmountOfAirToAddToTheWheel,
                            0f, r_MaximumAirPressure - m_CurrentAirPressure, not(v_IncludeMin));
                    }
                    status = Wheel.eInflateStatus.Overflow;
                }
                else
                {
                    m_CurrentAirPressure += i_AmountOfAirToAddToTheWheel;
                    status = Wheel.eInflateStatus.Success;
                }
            }

            return status;
        }

        public bool InflateToMaximum()
        {
            bool wasAlreadyFull;
            if (m_CurrentAirPressure < r_MaximumAirPressure)
            {
                wasAlreadyFull = false;
                Inflate(r_MaximumAirPressure - m_CurrentAirPressure);
            }
            else
            {
                wasAlreadyFull = true;
            }

            return wasAlreadyFull;
        }

        public Information Info
        {
            get { return new Information(m_CurrentAirPressure, r_MaximumAirPressure, r_NameOfManufacturer); }
        }

        private bool not(bool i_boolean)
        {
            return !i_boolean;
        }
    }
}
