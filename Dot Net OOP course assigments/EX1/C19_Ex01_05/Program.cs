namespace C19_Ex01_5
{
	using System;
	
	public static class Program
	{
		private const string k_InputMessage = "Enter 7 digits positive integer: ";
		private static long s_InputInteger;

        // $G$ DSN-999 (-5) The Main method should only be an access point to the program. Should look something like:
        // public static void Main() { new UI().Run(); } 
		public static void Main()
		{
			C19_Ex01_1.Program.Prologue(5);

			Console.Write(k_InputMessage);
			C19_Ex01_1.Program.ReadLine(isInvalid);
			////NOTE: The returned string object from the instruction above (C19.Ex01.Program.ReadLine(isInvalid)) is both ignored and not used because of the same reason stated in "C19_Ex01_03" project, "Program.cs" file, in the "Main" method of the "Program" class.
			////s_InputInteger is now the user's input in integer form and not string, modified by the instruction above.

			Console.WriteLine("The input number is " + s_InputInteger + '.' + Environment.NewLine);
			string inputIntegerAsString = s_InputInteger.ToString();

            char largestDecimalDigit = GetLargestDecimalDigit(inputIntegerAsString);
            char smallestDecimalDigit = GetSmallestDecimalDigit(inputIntegerAsString);
            ulong numberOfDecimalDigitsThatAreMultipleOf4 = getNumberOfDecimalDigitsThatAreMultipleOf4(inputIntegerAsString);
            ulong numberOfDecimalDigitsThatAreLargerThanTheOnesDecimalDigit = getNumberOfDecimalDigitsThatAreLargerThanTheOnesDecimalDigit(inputIntegerAsString);
			
			Console.WriteLine("Largest decimal digit is " + largestDecimalDigit + '.');
			Console.WriteLine("Smallest decimal digit is " + smallestDecimalDigit + '.');
			Console.WriteLine("Number of decimal digits that are multiple of 4 is " + numberOfDecimalDigitsThatAreMultipleOf4 + '.');
			Console.WriteLine("Number of decimal digits that are larger than the ones decimal digit is " + numberOfDecimalDigitsThatAreLargerThanTheOnesDecimalDigit + '.');

			C19_Ex01_1.Program.Epilogue();
		}


        // $G$ NTT-001 (-10) You should have used string.Format here.
        // $G$ CSS-013 (-5) Bad variable name (should be in the form of i_PascalCase).
		private static bool isInvalid(string i_input)
		{
			bool answer;
			if (fails(long.TryParse(i_input, out s_InputInteger)))
			{
				Console.Write("Not a valid integer. Try again." + Environment.NewLine + Environment.NewLine + k_InputMessage);
				answer = true;
			}
			else if (s_InputInteger <= 0)
			{
				Console.Write("Integer must be positive. Try again." + Environment.NewLine + Environment.NewLine + k_InputMessage);
				answer = true;
			}
			else if (i_input.Length != 7)
			{
				Console.Write("Not a 7 digits integer. Try again." + Environment.NewLine + Environment.NewLine + k_InputMessage);
				answer = true;
			}
			else
			{
				answer = false;
			}

			return answer;
		}

		private static bool fails(bool i_boolean)
		{
			return C19_Ex01_3.Program.Fails(i_boolean);
		}

        public static char GetLargestDecimalDigit(string i_DecimalInteger)
        {
            if (i_DecimalInteger == null)
            {
                throw new ArgumentNullException("i_DecimalInteger", "i_DecimalInteger must not be null.");
            }

            char largestDecimalDigit = '0';
            foreach (char currentDecimalDigit in i_DecimalInteger)
            {
                if (largestDecimalDigit < currentDecimalDigit)
                {
                    largestDecimalDigit = currentDecimalDigit;
                }
            }

            return largestDecimalDigit;
        }

        public static char GetSmallestDecimalDigit(string i_DecimalInteger)
        {
            if (i_DecimalInteger == null)
            {
                throw new ArgumentNullException("i_DecimalInteger", "i_DecimalInteger must not be null.");
            }

            char smallestDecimalDigit = '9';
            foreach (char currentDecimalDigit in i_DecimalInteger)
            {
                if (smallestDecimalDigit > currentDecimalDigit)
                {
                    smallestDecimalDigit = currentDecimalDigit;
                }
            }

            return smallestDecimalDigit;
        }

        private static ulong getNumberOfDecimalDigitsThatAreMultipleOf4(string i_DecimalInteger)
        {
            if (i_DecimalInteger == null)
            {
                throw new ArgumentNullException("i_DecimalInteger", "i_DecimalInteger must not be null.");
            }

            ulong numberOfDecimalDigitsThatAreMultipleOf4 = 0;
            foreach (char currentDecimalDigit in i_DecimalInteger)
            {
                if (currentDecimalDigit % 4 == 0)
                {
                    numberOfDecimalDigitsThatAreMultipleOf4++;
                }
            }

            return numberOfDecimalDigitsThatAreMultipleOf4;
        }

        private static ulong getNumberOfDecimalDigitsThatAreLargerThanTheOnesDecimalDigit(string i_DecimalInteger)
        {
            if (i_DecimalInteger == null)
            {
                throw new ArgumentNullException("i_DecimalInteger", "i_DecimalInteger must not be null.");
            }

            ulong numberOfDecimalDigitsThatAreLargerThanTheOnesDecimalDigit = 0;
            foreach (char currentDecimalDigit in i_DecimalInteger)
            {
                if (currentDecimalDigit > GetOnesDecimalDigit(i_DecimalInteger))
                {
                    numberOfDecimalDigitsThatAreLargerThanTheOnesDecimalDigit++;
                }
            }

            return numberOfDecimalDigitsThatAreLargerThanTheOnesDecimalDigit;
        }

        public static char GetOnesDecimalDigit(string i_number)
        {
            return i_number[i_number.Length - 1];
        }
	}
}