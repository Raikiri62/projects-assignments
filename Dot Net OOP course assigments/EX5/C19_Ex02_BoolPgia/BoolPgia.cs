namespace C19_Ex02_BoolPgia
{
	using System;
	using System.IO;
	using System.Collections.Generic;

	// The static class of the Bool Pgia game.
	// This static class has only all the logic of the Bool Pgia game.
	public static partial class BoolPgia
	{
		// The minimum number of chances.
		public const byte k_MinimumNumberOfChances = 4;

		// The maximum number of chances.
		public const byte k_MaximumNumberOfChances = 10;

		// The length of the random generated password.
		public const byte k_LengthOfPassword = 4;

		// A static property that returns to the application a string to display to the user what does he or she can enter and what not as input guess.
		public static string StringEachPasswordCharacterIsEither
		{
			get
			{
				StringWriter stringWriter = new StringWriter();
				stringWriter.WriteLine("Each character in the password is either:");
				stringWriter.WriteLine();
				foreach (string currentName in Enum<BoolPgia.eCharacter>.Names)
				{
					stringWriter.WriteLine(currentName);
				}

				return stringWriter.ToString();
			}
		}

		// A message to the player that no repetitions is allowed if the user did repetitions in the input guess.
		public const string k_StringNoRepetitionsAllowed = "No repetitions is allowed.";

		// A message to the player if he or she repeated a guess.
		public const string k_StringThisGuessHasAlreadyBeenTried = "This guess has already been tried.";

		// A message to the player when the user exits the game.
		public const string k_StringGoodBye = "Good Bye!";

		// A static method that returns to the application a string to display to the user when he or she wins the game.
		public static string GetStringPlayerSuccessfullyGuessedPassword(byte i_PlayerNumberOfGuessesBeforeSuccess)
		{
			return string.Format("You guessed after {0} step{1}!", i_PlayerNumberOfGuessesBeforeSuccess, i_PlayerNumberOfGuessesBeforeSuccess != 1 ? "s" : string.Empty);
		}

		// A message to the player when he or she loses the game.
		public const string k_StringLoss = "No more guesses allowed. You Lose.";

		// A question to the player if he or she would like to start a new game.
		public const string k_StringYesNoQuestionAboutStartingANewGame = "Would you like to start a new game?";

		// A handle to the password that have to be guessed.
		private static BoolPgia.eCharacter[] s_Password;

		// The list that remembers all the guesses that the player guessed since the beginning of the game to the present.
		private static List<Array<BoolPgia.eCharacter>> s_TriedGuesses = new List<Array<BoolPgia.eCharacter>>();

		// A static property that returns the handle to the password that have to be guessed.
		public static BoolPgia.eCharacter[] Password
		{
			get { return s_Password; }
		}    

		// A static property that both generates and returns a new handle to a new password.
		private static BoolPgia.eCharacter[] randomPassword
		{
			get { return Enum<BoolPgia.eCharacter>.GenerateRandomValuesWithoutRepetitions(k_LengthOfPassword); }
		}

		// A static method that invokes the randomPassword property and assigns s_Password.
		// In addition clears s_TriedGuesses.
		public static void GenerateRandomPassword()
		{
			s_Password = randomPassword;
			s_TriedGuesses.Clear();
		}

		// A static method that is invoked after the player entered some guess.
		// Firstly the static method checks that the input guess of the player is valid and if it is valid then outputs number of boolim and number of pgiot.
		public static BoolPgia.eCalculateResultOutcome CalculateResult(BoolPgia.eCharacter[] i_Guess, out byte o_NumberOfBoolim, out byte o_NumberOfPgiot, bool i_ThrowProperExceptionOnError = true)
		{
			o_NumberOfBoolim = 0;
			o_NumberOfPgiot = 0;

			BoolPgia.eCalculateResultOutcome status;
			if (s_Password == null)
			{
				if (i_ThrowProperExceptionOnError)
				{
					throw new Exception("The password must be generated first");
				}

				status = BoolPgia.eCalculateResultOutcome.ThePasswordWasNotGenerated;
			}
			else if (i_Guess == null)
			{
				if (i_ThrowProperExceptionOnError)
				{
					throw new ArgumentNullException("i_Guess", "i_Guess must not be null.");
				}

				status = BoolPgia.eCalculateResultOutcome.TheInputGuessIsNull;
			}
			else if (Enumerable<BoolPgia.eCharacter>.HasRepetitions(i_Guess))
			{
				if (i_ThrowProperExceptionOnError)
				{
					throw new ArgumentException("i_Guess must not have repetitions", "i_Guess");
				}

				status = BoolPgia.eCalculateResultOutcome.TheInputGuessHasRepetitions;
			}
			else if (i_Guess.Length != s_Password.Length)
			{
				if (i_ThrowProperExceptionOnError)
				{
					throw new ArgumentOutOfRangeException("i_Guess.Length", i_Guess.Length, string.Format("i_Guess.Length must be equal to k_LengthOfPassword ({0})", k_LengthOfPassword));
				}

				status = BoolPgia.eCalculateResultOutcome.TheLengthOfInputGuessIsNotEqualToTheLengthOfThePassword;
			}
			else if (s_TriedGuesses.Contains(i_Guess))
			{
				if (i_ThrowProperExceptionOnError)
				{
					throw new ArgumentException("This guess has already been tried.", "i_Guess");
				}
			
				status = BoolPgia.eCalculateResultOutcome.TheInputGuessWasAlreadyGivenAndTried;
			}
			else
			{
				for (long i = 0; i < i_Guess.Length; i++)
				{
					if (i_Guess[i] == s_Password[i])
					{
						o_NumberOfBoolim++;
					}
					else if (Enumerable<BoolPgia.eCharacter>.IsMemberOf(i_Guess[i], s_Password))
					{
						o_NumberOfPgiot++;
					}
				}

				s_TriedGuesses.Add(i_Guess);
				status = BoolPgia.eCalculateResultOutcome.Success;
			}

			return status;
		}

		// A static method that determines if player's guess is repeating.
		// Obviously that s_TriedGuesses is used in this static method.
		public static bool AlreadyTried(BoolPgia.eCharacter[] i_Guess)
		{
			return s_TriedGuesses.Contains(i_Guess);
		}

		// A static method that returns true if and only if some other method failed and returned false.
		private static bool fails(bool i_boolean)
		{
			return not(i_boolean);
		}

		// A static method that returns the negation of the given boolean value.
		private static bool not(bool i_boolean)
		{
			return !i_boolean;
		}
	}
}