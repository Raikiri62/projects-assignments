using System;
using System.IO;
using System.Collections.Generic;

// A general generic static class that have static methods that operate on System.Collections.Generic.IEnumerable instances.
public static class Enumerable<T> where T : struct
{
	// Returns true if and only if i_Object as T is member of i_Objects as IEnumerable<T>.
	public static bool IsMemberOf(T i_Object, IEnumerable<T> i_Objects)
	{
		bool answer = false;
		foreach (T currentObject in i_Objects)
		{
			if (i_Object.Equals(currentObject))
			{
				answer = true;
				break;
			}
		}

		return answer;
	}

	// Every IEnumerable<T> instance may have repetitions. This methods returns true if and only if the given instance of IEnumerable<T> has repetitions.
	public static bool HasRepetitions(IEnumerable<T> i_Objects)
	{
		bool answer = false;
		ulong i = 0;
		foreach (T a in i_Objects)
		{
			ulong j = 0;
			foreach (T b in i_Objects)
			{
				if (i != j && a.Equals(b))
				{
					answer = true;
					goto returnAnswer;
				}

				j++;
			}

			i++;
		}

		returnAnswer:
		return answer;
	}

	// As the name of this method suggests inserts before each object and after the last object a sequence of objects.
	public static IEnumerable<T> InsertBeforeEachAndAfterLast(IEnumerable<T> i_Objects, IEnumerable<T> i_TheObjectsToInsert)
	{
		foreach (T currentObject in i_Objects)
		{
			foreach (T currentObjectToInsert in i_TheObjectsToInsert)
			{
				yield return currentObjectToInsert;
			}
			
			yield return currentObject;
		}

		foreach (T currentObjectToInsert in i_TheObjectsToInsert)
		{
			yield return currentObjectToInsert;
		}
	}

	// Same as above, but the sequence of objects can be written and implicitly create a new one dimensional array without giving any handle.
	public static IEnumerable<T> InsertBeforeEachAndAfterLast(IEnumerable<T> i_Objects, params T[] i_TheObjectsToInsert)
	{
		return InsertBeforeEachAndAfterLast(i_Objects, i_TheObjectsToInsert as IEnumerable<T>);
	}

	// Returns all object that satisfy some predicate.
	public static IEnumerable<T> AllThatSatisfy(IEnumerable<T> i_Objects, Func<T, bool> i_Predicate)
	{
		foreach (T currentObject in i_Objects)
		{
			if (i_Predicate(currentObject))
			{
				yield return currentObject;
			}
		}
	}

	// Remove all objects from i_Objects except these that are member of i_ObjectsToKeep.
	public static IEnumerable<T> RemoveAllExcept(IEnumerable<T> i_Objects, IEnumerable<T> i_ObjectsToKeep)
	{
		foreach (T currentObject in i_Objects)
		{
			if (IsMemberOf(currentObject, i_ObjectsToKeep))
			{
				yield return currentObject;
			}
		}
	}

	// Same as above, but i_ObjectsToKeep can be written in the code as an argument list, implicitly create a new one dimensional array and without giving any handle at all.
	public static IEnumerable<T> RemoveAllExcept(IEnumerable<T> i_Objects, params T[] i_ObjectsToKeep)
	{
		return RemoveAllExcept(i_Objects, i_ObjectsToKeep as IEnumerable<T>);
	}

	// Determines whether there is a null value or not.
	public static bool AllHasValue(IEnumerable<T?> i_NullableStructs)
	{
		bool answer = true;
		foreach (T? currentNullableStruct in i_NullableStructs)
		{
			if (not(currentNullableStruct.HasValue))
			{
				answer = false;
				break;
			}
		}

		return answer;
	}

	// Returns all values that are not null.
	public static IEnumerable<T> ToNotNullable(IEnumerable<T?> i_NullableStructs)
	{
		foreach (T? currentNullableStruct in i_NullableStructs)
		{
			if (currentNullableStruct.HasValue)
			{
				yield return currentNullableStruct.Value;
			}
		}
	}

	// Converts an IEnumerable<T> instance to an IList<T> instance.
	public static IList<T> ToList(IEnumerable<T> i_Objects)
	{
		List<T> list = new List<T>();
		foreach (T currentObject in i_Objects)
		{
			list.Add(currentObject);
		}

		return list;
	}

	// Converts an IEnumerable<T> instance to a string instance.
	public static string ToString(IEnumerable<T> i_Objects)
	{
		StringWriter stringWriter = new StringWriter();
		foreach (T currentObject in i_Objects)
		{
			stringWriter.Write(currentObject);
		}

		return stringWriter.ToString();
	}

	// Returns the negation of the given boolean value.
	private static bool not(bool i_Boolean)
	{
		return !i_Boolean;
	}
}