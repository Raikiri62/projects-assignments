namespace C19_Ex01_2
{
    using System;

	public static class Program
	{
		public static void Main()
		{
			C19_Ex01_1.Program.Prologue(2);

			WriteSandClock(5, '*');

			C19_Ex01_1.Program.Epilogue();
		}

		public static bool WriteSandClock(long i_height, char i_character)
		{
			bool success;
			if (i_height >= 1)
			{
				WriteTopDownIsoscelesTriangle(i_height, i_character);

				if (i_height % 2 == 1)
				{
					MoveConsoleCursorBy(-1, -1);
				}
				else
				{
					Console.CursorLeft--;
				}

				WriteBottomUpIsoscelesTrapezoid(i_height % 2 == 1 ? 1 : 2, i_height, i_character);
				success = true;
			}
			else
			{
				success = false;
			}

			return success;
		}

		public static void WriteTopDownIsoscelesTriangle(long i_width, char i_character)
		{
			if (i_width <= 0)
			{
				return;
			}

			int consoleCursorLeftBeforeWrite = Console.CursorLeft;
			WriteRepeatedly(i_character, i_width);
			Console.WriteLine();
			int newValueForConsoleCursorLeft = consoleCursorLeftBeforeWrite + 1;
			if (newValueForConsoleCursorLeft < Console.BufferWidth)
			{
				Console.CursorLeft = newValueForConsoleCursorLeft;
				WriteTopDownIsoscelesTriangle(i_width - 2, i_character);
			}
		}

		public static void MoveConsoleCursorBy(int i_cols, int i_rows)
		{
			Console.SetCursorPosition(Console.CursorLeft + i_cols, Console.CursorTop + i_rows);
		}

		public static void WriteBottomUpIsoscelesTrapezoid(long i_LengthOfTopEdge, long i_LengthOfBottomEdge, char i_character)
		{
			if (i_LengthOfTopEdge > i_LengthOfBottomEdge)
			{
				return;
			}

			int consoleCursorLeftBeforeWrite = Console.CursorLeft;
			WriteRepeatedly(i_character, i_LengthOfTopEdge);
			Console.WriteLine();
			int newValueForConsoleCursorLeft = consoleCursorLeftBeforeWrite - 1;
			if (newValueForConsoleCursorLeft >= 0)
			{
				Console.CursorLeft = newValueForConsoleCursorLeft;
				WriteBottomUpIsoscelesTrapezoid(i_LengthOfTopEdge + 2, i_LengthOfBottomEdge, i_character);
			}
		}

		public static void WriteRepeatedly(object i_object, long i_repeat)
		{
			for (long i = 0; i < i_repeat; ++i)
			{
				Console.Write(i_object);
			}
		}
	}
}