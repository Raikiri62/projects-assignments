using System;

public static partial class Enum<T> where T : struct
{
    public static T Parse(string i_String)
    {
        return (T)Enum.Parse(typeof(T), i_String);
    }

    public static T Parse(string i_String, bool i_IgnoreCase)
    {
        return (T)Enum.Parse(typeof(T), i_String, i_IgnoreCase);
    }

    public static T[] Values
    {
        get
        {
            return Enum.GetValues(typeof(T)) as T[];
        }
    }

    public static string[] Names
    {
        get
        {
            return Enum.GetNames(typeof(T));
        }
    }

    public static bool TryParse(string i_String, out T o_Enum)
    {
        bool success;

        if (Enum.TryParse<T>(i_String, out o_Enum))
        {
            long dummy;
            if (long.TryParse(i_String, out dummy))
            {
                success = false;
            }
            else
            {
                success = true;
            }
        }
        else
        {
            success = false;
        }

        return success;
    }

    public static bool TryParse(string i_String, bool i_IgnoreCase, out T o_Enum)
    {
        bool success;

        if (Enum.TryParse<T>(i_String, i_IgnoreCase, out o_Enum))
        {
            long dummy;
            if (long.TryParse(i_String, out dummy))
            {
                success = false;
            }
            else
            {
                success = true;
            }
        }
        else
        {
            success = false;
        }

        return success;
    }
}