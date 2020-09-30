using System;
using System.Collections;

// This generic struct manages a one dimensional .NET CLI managed array and also his handle (instances of System.Array) and every instance of this generic struct stores a handle to a one dimensional .NET array (or instance of System.Array).
// This generic struct is similar to the template typename std::vector class in C++.
// Using this generic struct is like using C array, except that the equality operator == compares the actual and concrete arrays and not their handles or addresses or pointers or references.
// This generic struct must be used instead of System.Array in every scenario where comparing the actual and concrete arrays is intended and not their handles, addresses, pointers or references.
// One example for such scenario is that there is a list of unique handles to unique arrays and a new array handle is added to the list if and only if both the handle and the array are unique in the list.
// To determine that the array is unique, the array must be compared with all the other arrays and the result of the comparison must say that the array is not equal to any other array.
public struct Array<T> : IEnumerable
{


	// A static method that generates a random sequence as one dimensional array without repetitions.
	// The length of the returned generated sequence is always equal to the given i_LengthOfSequence and each term of the returned generated sequence is always member of the given i_Samples one dimensional array.
	public static T[] GenerateRandomSequenceWithoutRepetitions(long i_LengthOfSequence, params T[] i_Samples)
	{
		if (i_LengthOfSequence <= 0)
		{
			throw new ArgumentOutOfRangeException("i_LengthOfSequence", i_LengthOfSequence, "i_LengthOfSequence must be not negative integer");
		}

		if (i_LengthOfSequence > i_Samples.Length)
		{
			throw new ArgumentOutOfRangeException("i_LengthOfSequence", i_LengthOfSequence, string.Format("i_LengthOfSequence must be not larger than i_Samples.Length ({0})", i_Samples.Length));
		}

		Random random = new Random(DateTime.Now.Millisecond);
		T[] randomSequence = new T[i_LengthOfSequence];
		bool[] alreadyGenerated = new bool[i_Samples.Length];

		for (long i = 0; i < i_LengthOfSequence; i++)
		{
			int indexOfRandomSample;

			do
			{
				indexOfRandomSample = random.Next(i_Samples.Length);
			}
			while (alreadyGenerated[indexOfRandomSample]);

			randomSequence[i] = i_Samples[indexOfRandomSample];
			alreadyGenerated[indexOfRandomSample] = true;
		}

		return randomSequence;
	}

	// Arranges or Sorts the given samples as one dimensional array randomly.
	public static T[] RandomOrderOf(params T[] i_Samples)
	{
		return GenerateRandomSequenceWithoutRepetitions(i_Samples.LongLength, i_Samples);
	}

	// The static equal operator == returns true if and only if the both arrays are equals (NOT THEIR HANDLES!!!)
	public static bool operator ==(Array<T> i_A, Array<T> i_B)
	{
		bool equals = true;

		if (i_A.Length != i_B.Length)
		{
			equals = false;
		}
		else
		{
			for (long i = 0; i < i_A.Length; i++)
			{
				if (not(i_A[i].Equals(i_B[i])))
				{
					equals = false;
					break;
				}
			}
		}

		return equals;
	}

	// This operator simply returns the negation of the operator above.
	public static bool operator !=(Array<T> i_A, Array<T> i_B)
	{
		return not(i_A == i_B);
	}

	// A static implicit operator that returns the handle that this generic struct encapsulates.
	// This static implicit operator is useful in methods that require System.Array parameters.
	public static implicit operator T[](Array<T> i_Array)
	{
		return i_Array.m_Handle;
	}

	// A static implicit operator that invokes the constructor to creates a new instance of this generic struct and then returns the new instance.
	// This static implicit operator can be used to create new instances of this generic struct without invoking the constructor directly and explicitly.
	public static implicit operator Array<T>(T[] i_Handle)
	{
		return new Array<T>(i_Handle);
	}

	// This is a handle to a one dimensional .NET CLI managed array that every instance of this generic struct encapsulates.
	// Like that std::vector encapsulates a C pointer to an array on the heap memory.
	private T[] m_Handle;

	// This is the constructor that must be invoked to create a new instance of this generic struct.
	// Obviously the constructor must get a handle to a one dimensional .NET CLI managed array to encapsulate.
	// Of course that the params can be used to create a new one dimensional .NET CLI managed array in C# without typing the new keyword again in the code and without typing the generic type again in the code.
	public Array(params T[] i_Handle)
	{
		m_Handle = i_Handle;
	}

	// A property that returns the length of the .NET CLI managed array referred by m_Handle.
	public long Length
	{
		get { return m_Handle.LongLength; }
	}

	// An indexer that simply uses the indexer of the System.Array.
	public T this[long i_Index]
	{
		get { return m_Handle[i_Index]; }
		set { m_Handle[i_Index] = value; }
	}

	// This generic struct overrides the Equals method inherited from object to use the equal operator ==.
	public override bool Equals(object i_Object)
	{
		return this == (Array<T>)i_Object;
	}

	// This generic struct implements the System.Collections.IEnumerable interface and that means that this generic struct must implement the GetEnumerator method of the System.Collections.IEnumerable interface.
	// This method simply invokes the GetEnumerator method of the System.Array class through the field m_Handle and returns the System.Array.GetEnumerator returns with m_Handle.
	public IEnumerator GetEnumerator()
	{
		return m_Handle.GetEnumerator();
	}

	// A property that returns the handle that every instance of this generic struct encapsulates.
	public T[] Handle
	{
		get { return m_Handle; }
		set { m_Handle = value; }
	}

	// A method that simply returns the negation of the given boolean value.
	private static bool not(bool i_Boolean)
	{
		return !i_Boolean;
	}
}