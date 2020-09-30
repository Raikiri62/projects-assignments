namespace C19_Ex01_3
{
	using System;

	public static class Program
	{
		private const string k_InputMessage = "Enter sand clock height: ";
		private static int s_SandClockHeight;

		public static void Main()
		{
			C19_Ex01_1.Program.Prologue(3);

			Console.Write(k_InputMessage);
			C19_Ex01_1.Program.ReadLine(isInvalid);
			////NOTE: The returned string object from the instruction above (C19_Ex01_1.Program.ReadLine(isInvalid)) is both ignored and not used,
			////because when the user enters a valid integer then int.TryParse (invoked inside isInvalid method) sets s_SandClockHeight to the value that the user entered

			Console.WriteLine();
			C19_Ex01_2.Program.WriteSandClock(s_SandClockHeight, '*');

			C19_Ex01_1.Program.Epilogue();
		}


        // $G$ CSS-013 (-5) Bad variable name (should be in the form of i_PascalCase).
		private static bool isInvalid(string i_input)
		{
			bool answer;
			if (Fails(int.TryParse(i_input, out s_SandClockHeight)))
			{
				Console.WriteLine("Not a valid integer. Try again." + Environment.NewLine);
				Console.Write(k_InputMessage);
				answer = true;
			}
			else if (s_SandClockHeight <= 0)
			{
				Console.WriteLine("Positive integer required. Try again." + Environment.NewLine);
				Console.Write(k_InputMessage);
				answer = true;
			}
			else
			{
				answer = false;
			}

			return answer;
		}

		public static bool Fails(bool i_boolean)
		{
			return !i_boolean;
		}
	}
}