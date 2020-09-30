using System;
using System.Threading;

public static class ConsoleInput
{
    private static bool not(bool i_boolean)
    {
        return !i_boolean;
    }

    public static ConsoleKeyInfo ReadKey(Func<ConsoleKeyInfo, bool> i_IsInvalidInputKey, bool i_intercept = false, int i_wait = 1000)
    {
        if (i_IsInvalidInputKey == null)
        {
            throw new ArgumentNullException("i_IsInvalid", "i_IsInvalid must not be null.");
        }

        ConsoleKeyInfo key;
        do
        {
            key = Console.ReadKey(i_intercept);
            if (not(i_intercept) && i_wait > 0)
            {
                Thread.Sleep(i_wait);
            }
        }
        while (i_IsInvalidInputKey(key));
        return key;
    }

    public static string ReadLine(Func<string, Action<string, Enum>, bool> i_IsInvalidInputString, Action<string, Enum> o_display)
    {
        if (i_IsInvalidInputString == null)
        {
            throw new ArgumentNullException("i_IsInvalid", "i_IsInvalid must not be null.");
        }

        if (o_display == null)
        {
            throw new ArgumentNullException("o_display", "o_display must not be null");
        }

        string line;
        do
        {
            line = Console.ReadLine();
        }
        while (i_IsInvalidInputString(line, o_display));
        return line;
    }

    public delegate bool IsInvalidInputStringDelegate(string i_string, Action<string, Enum> o_display, out object o_object);

    public static object ReadLine(IsInvalidInputStringDelegate i_IsInvalidInputString, Action<string, Enum> o_display)
    {
        if (i_IsInvalidInputString == null)
        {
            throw new ArgumentNullException("i_IsInvalidInputString", "i_IsInvalidInputString must not be null.");
        }

        if (o_display == null)
        {
            throw new ArgumentNullException("o_display", "o_display must not be null.");
        }

        string line;
        object output;
        do
        {
            line = Console.ReadLine();
        }
        while (i_IsInvalidInputString(line, o_display, out output));
        return output;
    }

    public static string ReadLine(Func<string, Action<string, Enum>, bool> i_IsInvalidInputString)
    {
        return ReadLine(
        i_IsInvalidInputString,
        delegate(string i_message, Enum i_reason)
        {
            Console.Write(i_message);
        });
    }

    public static object ReadLine(IsInvalidInputStringDelegate i_IsInvalidInputString)
    {
        return ReadLine(
        i_IsInvalidInputString,
        delegate(string i_message, Enum i_reason)
        {
            Console.Write(i_message);
        });
    }
}