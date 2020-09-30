using System;

public static partial class EnumUtils
{
    public static T Parse<T>(string i_String) where T : struct
    {
        return (T)Enum.Parse(typeof(T), i_String);
    }

    public static T Parse<T>(string i_String, bool i_IgnoreCase) where T : struct
    {
        return (T)Enum.Parse(typeof(T), i_String, i_IgnoreCase);
    }

    public static bool TryParse<T>(string i_String, out T o_Enum) where T : struct
    {
        return Enum<T>.TryParse(i_String, out o_Enum);
    }

    public static bool TryParse<T>(string i_String, bool i_IgnoreCase, out T o_Enum) where T : struct
    {
        return Enum<T>.TryParse(i_String, out o_Enum);
    }

    public static T[] GetValues<T>() where T : struct
    {
        return Enum.GetValues(typeof(T)) as T[];
    }

    public static string[] GetNames<T>() where T : struct
    {
        return Enum.GetNames(typeof(T));
    }
}