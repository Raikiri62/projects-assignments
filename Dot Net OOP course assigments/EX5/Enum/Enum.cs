using System;

// A general generic static class that has static methods related to enums.
public static class Enum<T> where T : struct
{
	// A static method that converts a string to an enum.
	// If the given string is invalid then a proper exception is thrown.
	public static T Parse(string i_String)
	{
		return (T)Enum.Parse(typeof(T), i_String);
	}

	// Another overload of the method above that allows the invoker to tell whether case should be ignored or not in the given string.
	public static T Parse(string i_String, bool i_IgnoreCase)
	{
		return (T)Enum.Parse(typeof(T), i_String, i_IgnoreCase);
	}

	// A static property that returns all the values of the generic enum.
	public static T[] Values
	{
		get { return Enum.GetValues(typeof(T)) as T[]; }
	}

	// A static property that returns all the names of the generic enum.
	public static string[] Names
	{
		get { return Enum.GetNames(typeof(T)) as string[]; }
	}

	// A static property that returns a random value from the generic enum.
	public static T RandomValue
	{
		get { return Values[new Random(DateTime.Now.Millisecond).Next(Values.Length)]; }
	}

	// A static property that returns a random name from the generic enum.
	public static string RandomName
	{
		get { return Names[new Random(DateTime.Now.Millisecond).Next(Names.Length)]; }
	}

	// A static method that generates random values from the generic enum without repetitions.
	public static T[] GenerateRandomValuesWithoutRepetitions(long i_NumberOfRandomValuesToGenerate)
	{
		return Array<T>.GenerateRandomSequenceWithoutRepetitions(i_NumberOfRandomValuesToGenerate, Values);
	}

	// A static method that generates random names from the generic enum without repetitions.
	public static string[] GenerateRandomNamesWithoutRepetitions(long i_NumberOfRandomNamesToGenerate)
	{
		return Array<string>.GenerateRandomSequenceWithoutRepetitions(i_NumberOfRandomNamesToGenerate, Names);
	}

	// A static property that returns all the values of the generic enum in a random order as a handle to a new one dimensional array.
	public static T[] RandomOrderedValues
	{
		get { return Array<T>.RandomOrderOf(Values); }
	}

	// A static property that returns all the names of the generic enum in a random order as a handle to a new one dimensional array.
	public static string[] RandomOrderedNames
	{
		get { return Array<string>.RandomOrderOf(Names); }
	}
}