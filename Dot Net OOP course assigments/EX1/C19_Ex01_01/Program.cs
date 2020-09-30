namespace C19_Ex01_1
{


    using System;

	public static class Program
	{
        private const string k_MessageStringMustEncodeABinaryNumber = "i_BinaryNumber must be a string that encodes a binary number.";
		private static uint s_index;
        
		public static void Prologue(ulong i_SectionNumber)
		{
			Console.Title = "C19_Ex01_" + i_SectionNumber;
			Console.ForegroundColor = ConsoleColor.White;
			Console.BackgroundColor = ConsoleColor.Black;
			Console.WriteLine();
		}

		public static void Epilogue()
		{
			Console.WriteLine();
			Console.Write("Press any key to exit . . .");
			const bool v_Intercept = true;
			Console.ReadKey(v_Intercept);
		}

        // $G$ DSN-999 (-5) The Main method should only be an access point to the program. Should look something like:
        // public static void Main() { new UI().Run(); } 
        // $G$ NTT-001 (-10) You should have used string.Format here.
		public static void Main()
		{
			Prologue(1);

			Console.WriteLine("Enter 4 binary numbers with 7 digits each:" + Environment.NewLine);
			string[] binaryNumbers = ReadLines(4, isInvalid);
			long[] decimalIntegers = ToDecimalNumbers(binaryNumbers);
			Console.WriteLine("The 4 numbers in decimal form are:" + Environment.NewLine);
			WriteLines(decimalIntegers);
			Console.WriteLine();
			Console.WriteLine();
			Console.WriteLine("Statistics:");
			Console.WriteLine("==========");
			Console.WriteLine();

			long[] numberOfZeroes = GetNumbersOfOccurencesOf('0', binaryNumbers);
			long[] numberOfOnes   = GetNumbersOfOccurencesOf('1', binaryNumbers);

			decimal averageNumberOfZeroes = Average(numberOfZeroes);
			decimal averageNumberOfOnes   = Average(numberOfOnes);

			Console.WriteLine("Average number of 'zeroes' is " + averageNumberOfZeroes);
			Console.WriteLine("Average number of 'ones'   is " + averageNumberOfOnes);

			ulong numberOfNumbersThatArePowerOfTwo = GetNumberOfNumbersThatArePowerOfTwo(binaryNumbers);

			Console.WriteLine("Number of numbers that are power of two is " + numberOfNumbersThatArePowerOfTwo);

			ulong numberOfNumbersWhoseDecimalDigitsAreIncreasing = GetNumberOfNumbersWhoseDecimalDigitsAreIncreasing(decimalIntegers);

			Console.WriteLine("Number of numbers whose decimal digits are increasing is " + numberOfNumbersWhoseDecimalDigitsAreIncreasing);
			Console.WriteLine("The average of the input numbers is " + Average(decimalIntegers));

			Epilogue();
		}


        // $G$ CSS-013 (-5) Bad variable name (should be in the form of i_PascalCase).
		private static bool isInvalid(string i_input)
		{
			bool answer;
			if (IsNotBinaryNumber(i_input))
			{
				Console.Write("Not a binary number. Try again:{0}{0}{1}) ", Environment.NewLine, s_index + 1);
                ////Another possibility is to invoke string.Format exactly the same way as Console.Write is invoked above and then pass the returned string to Console.Write, but Console.Write already invokes string.Format behind the scenes.
				answer = true;
			}
			else if (i_input.Length != 7)
			{
				Console.Write("Not 7 digits. Try again:{0}{0}{1}) ", Environment.NewLine, s_index + 1);
				answer = true;
			}
			else
			{
				answer = false;
			}

			return answer;
		}

		public static string[] ReadLines(uint i_NumberOfLinesToRead, Func<string, bool> i_isInvalid)
		{
            if (i_isInvalid == null)
            {
                throw new ArgumentNullException("i_isInvalid", "i_isInvalid must not be null");
            }

			string[] lines = new string[i_NumberOfLinesToRead];

			for (s_index = 0; s_index < i_NumberOfLinesToRead; ++s_index)
			{
				Console.Write("{0}) ", s_index + 1);
				lines[s_index] = ReadLine(i_isInvalid);
				Console.WriteLine();
			}

			return lines;
		}


        // $G$ CSS-013 (-5) Bad variable name (should be in the form of i_PascalCase).
		public static string ReadLine(Func<string, bool> i_isInvalid)
		{
            if (i_isInvalid == null)
            {
                throw new ArgumentNullException("i_isInvalid", "i_isInvalid must not be null");
            }

			string line;

			do
			{
				line = Console.ReadLine();
			}
			while (i_isInvalid(line));

			return line;
		}

		public static bool IsNotBinaryNumber(string i_string)
		{
			return !IsBinaryNumber(i_string);
		}

		public static bool IsBinaryNumber(string i_string)
		{
			return AllCharactersAreBinaryDigits(i_string);
		}

		public static bool AllCharactersAreBinaryDigits(string i_string)
		{
			return NotExistsNonBinaryDigit(i_string);
		}

		public static bool NotExistsNonBinaryDigit(string i_string)
		{
			return !ExistsNonBinaryDigit(i_string);
		}

		public static bool ExistsNonBinaryDigit(string i_string)
		{
            if (i_string == null)
            {
                throw new ArgumentNullException("i_string", "i_string must not be null.");
            }

			bool answer = false;

			foreach (char currentCharacter in i_string)
			{
				if (IsNotBinaryDigit(currentCharacter))
				{
					answer = true;
					break;
				}
			}

			return answer;
		}

		public static bool IsNotBinaryDigit(char i_character)
		{
			return !IsBinaryDigit(i_character);
		}

		public static bool IsBinaryDigit(char i_character)
		{
			return i_character == '0' || i_character == '1';
		}

		public static long ToDecimalNumber(string i_BinaryNumber)
		{
            if (i_BinaryNumber == null)
            {
                throw new ArgumentNullException("i_BinaryNumber", "i_BinaryNumber must not be null.");
            }

            if (IsNotBinaryNumber(i_BinaryNumber))
            {
                throw new ArgumentException(k_MessageStringMustEncodeABinaryNumber, "i_BinaryNumber");
            }

			long result = 0;

			for (int i = 0; i < i_BinaryNumber.Length; ++i)
			{
				if (i_BinaryNumber[i] == '1')
				{
					result += Power(2, i_BinaryNumber.Length - (i + 1));
					////This is also possible to invoke Math.Pow instead, but then explicit casts from integer to double and from double to integer are required.
				}
			}

			return result;
		}

		public static long Power(long i_base, long i_exponent)
		{
			long result = 1;

			for (long i = 0; i < i_exponent; ++i)
			{
				result *= i_base;
			}

			return result;
		}

		public static long[] ToDecimalNumbers(string[] i_BinaryNumbers)
		{
            if (i_BinaryNumbers == null)
            {
                throw new ArgumentNullException("i_BinaryNumbers", "i_BinaryNumbers must not be null.");
            }

			long[] result = new long[i_BinaryNumbers.Length];

			for (uint i = 0; i < result.Length; ++i)
			{
				result[i] = ToDecimalNumber(i_BinaryNumbers[i]);
			}

			return result;
		}

		public static void WriteLines(long[] i_integers)
		{
            if (i_integers == null)
            {
                throw new ArgumentNullException("i_integers", "i_integers must not be null.");
            }

			for (long i = 0; i < i_integers.Length; ++i)
			{
				Console.WriteLine("{0}) {1}", i + 1, i_integers[i]);
			}
		}

		public static long GetNumberOfOccurencesOf(char i_character, string i_string)
		{
            if (i_string == null)
            {
                throw new ArgumentNullException("i_string", "i_string must not be null.");
            }

			long counter = 0;

			foreach (char current_character in i_string)
			{
				if (current_character == i_character)
				{
					counter++;
				}
			}

			return counter;
		}

		public static long[] GetNumbersOfOccurencesOf(char i_character, string[] i_strings)
		{
            if (i_strings == null)
            {
                throw new ArgumentNullException("i_strings", "i_strings must not be null.");
            }

			long[] counters = new long[i_strings.Length];

			for (long i = 0; i < counters.Length; ++i)
			{
				counters[i] = GetNumberOfOccurencesOf(i_character, i_strings[i]);
			}

			return counters;
		}

		public static decimal Average(long[] i_integers)
		{
            if (i_integers == null)
            {
                throw new ArgumentNullException("i_integers", "i_integers must not be null.");
            }

			return Sum(i_integers) / (decimal)i_integers.Length;
		}

		public static ulong Sum(long[] i_integers)
		{
            if (i_integers == null)
            {
                throw new ArgumentNullException("i_integers", "i_integers must not be null.");
            }

			ulong sum = 0;

			foreach (ulong currentInteger in i_integers)
			{
				sum += currentInteger;
			}

			return sum;
		}

		public static bool IsPowerOfTwo(string i_BinaryNumber)
		{
            if (IsNotBinaryNumber(i_BinaryNumber))
            {
                throw new ArgumentException(k_MessageStringMustEncodeABinaryNumber, "i_BinaryNumber");
            }

			return GetNumberOfOccurencesOf('1', i_BinaryNumber) == 1;
		}

		public static ulong GetNumberOfNumbersThatArePowerOfTwo(string[] i_BinaryNumbers)
		{
            if (i_BinaryNumbers == null)
            {
                throw new ArgumentNullException("i_BinaryNumbers", "i_BinaryNumbers must not be null.");
            }

			ulong counter = 0;

			foreach (string currentBinaryNumber in i_BinaryNumbers)
			{
				if (IsPowerOfTwo(currentBinaryNumber))
				{
					counter++;
				}
			}

			return counter;
		}

		public static bool IsIncreasing(long i_number)
		{
			string inputNumberAsString = i_number.ToString();
			bool answer = true;

			for (int i = 0; i < inputNumberAsString.Length - 1; ++i)
			{
				if (inputNumberAsString[i] >= inputNumberAsString[i + 1])
				{
					answer = false;
					break;
				}
			}

			return answer;
		}

		public static ulong GetNumberOfNumbersWhoseDecimalDigitsAreIncreasing(long[] i_numbers)
		{
            if (i_numbers == null)
            {
                throw new ArgumentNullException("i_numbers", "i_numbers must not be null.");
            }

			ulong counter = 0;

			foreach (long currentNumber in i_numbers)
			{
				if (IsIncreasing(currentNumber))
				{
					counter++;
				}
			}

			return counter;
		}
	}
}