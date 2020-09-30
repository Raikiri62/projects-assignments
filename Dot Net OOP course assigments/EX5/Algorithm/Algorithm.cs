// A general generic static class of general static methods that each does a specific task and each solves a specific problem by using some algorithm.
// This general generic static class can be used by many different applications and class libraries.
public static class Algorithm<T> where T : struct
{
	// This is a static method that swaps/exchanges two objects.
	public static void Swap(ref T i_A, ref T i_B)
	{
		T temporary = i_A;
		i_A = i_B;
		i_B = temporary;
	}

	// Same as above, but also works with nullable structs.
	public static void Swap(ref T? i_A, ref T? i_B)
	{
		T? temporary = i_A;
		i_A = i_B;
		i_B = temporary;
	}
}