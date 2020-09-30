namespace C19_Ex01_4
{
	using System;
	using System.Text;

	internal enum eInputType
	{
		Letters,
		Number
	}


    // $G$ CSS-999 (-5) Each class/struct/enum/interface should be placed in a separate file.
	public static class Program
	{
		private static ulong s_InputNumber;
		private static eInputType s_InputType;

		public static void Main()
		{
			C19_Ex01_1.Program.Prologue(4);

			Console.WriteLine("Enter a 10 characters string composed of all letters or all digits:" + Environment.NewLine);
			string input = C19_Ex01_1.Program.ReadLine(isInvalid);
			Console.WriteLine();

			Console.WriteLine("Is palindrome? {0}", IsPalindrome(input) ? "Yes" : "No");

			switch (s_InputType)
			{
				case eInputType.Letters:
                    Console.WriteLine("Input string has {0} lower case letters", GetNumberOfLowerCaseLettersIn(input));
                    break;
				case eInputType.Number:
                    Console.WriteLine("Is multiple of 4? {0}", s_InputNumber % 4 == 0 ? "Yes" : "No");
                    break;
			}

			C19_Ex01_1.Program.Epilogue();
		}


        // $G$ CSS-013 (-5) Bad variable name (should be in the form of i_PascalCase).
		private static bool isInvalid(string i_input)
		{
			bool answer = false;
			if (i_input.Length != 10)
			{
				Console.WriteLine("Not a 10 characters string. Try again:" + Environment.NewLine);
				answer = true;
			}
			else if (ulong.TryParse(i_input, out s_InputNumber))
			{
				s_InputType = eInputType.Number;
				answer = false;
			}
			else if (AllCharactersAreLetters(i_input))
			{
				s_InputType = eInputType.Letters;
				answer = false;
			}
			else
			{
				Console.WriteLine("String must be composed of all letters or all digits. Try again:" + Environment.NewLine);
				answer = true;
			}

			return answer;
		}

		public static bool AllCharactersAreLetters(string i_input)
		{
			return NotExistsNonLetterCharacter(i_input);
		}

		public static bool NotExistsNonLetterCharacter(string i_input)
		{
			return !ExistsNonLetterCharacter(i_input);
		}

		public static bool ExistsNonLetterCharacter(string i_input)
		{
			bool answer = false;
			foreach (char currentCharacter in i_input)
			{
				if (!char.IsLetter(currentCharacter))
				{
					answer = true;
					break;
				}
			}

			return answer;
		}

		public static bool IsPalindrome(string i_string)
		{
			bool answer;
			if (i_string.Length <= 1)
			{
				answer = true;
			}
			else if (FirstCharacterOf(i_string) != LastCharacterOf(i_string))
			{
				answer = false;
			}
			else
			{
				answer = IsPalindrome(ExcludeBothFirstAndLastCharactersFrom(i_string));
                ////Another possibility:
				////answer = IsPalindrome(i_string.Substring(1, i_string.Length - 2));
			}

			return answer;
		}

		public static char FirstCharacterOf(string i_string)
		{
			return i_string[0];
		}

		public static char LastCharacterOf(string i_string)
		{
			return i_string[i_string.Length - 1];
		}

		public static string ExcludeBothFirstAndLastCharactersFrom(string i_string)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 1; i < i_string.Length - 1; ++i)
			{
				stringBuilder.Append(i_string[i]);
			}

			return stringBuilder.ToString();
		}

		public static ulong GetNumberOfLowerCaseLettersIn(string i_string)
		{
			ulong counter = 0;
			foreach (char currentCharacter in i_string)
			{
				if (char.IsLower(currentCharacter))
				{
					counter++;
				}
			}

			return counter;
		}
	}
}