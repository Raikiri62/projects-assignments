namespace C19_Ex02_BoolPgia
{
	public static partial class BoolPgia
	{
		// An enum that lists all the possible outcomes of the CalculateResult static method.
		public enum eCalculateResultOutcome
		{
			Success,
			ThePasswordWasNotGenerated,
			TheInputGuessIsNull,
			TheInputGuessHasRepetitions,
			TheLengthOfInputGuessIsNotEqualToTheLengthOfThePassword,
			TheInputGuessWasAlreadyGivenAndTried
		}
	}
}