using System;
using System.Text;
using System.Collections.Generic;

public static class StringUtils
{
    public static bool IsMemberOf(char i_character, string i_string)
    {
        if (i_string == null)
        {
            throw new ArgumentNullException("i_string", "i_string must not be null.");
        }

        bool answer = false;
        foreach (char currentCharacter in i_string)
        {
            if (i_character == currentCharacter)
            {
                answer = true;
                break;
            }
        }

        return answer;
    }

    public static string Concatenate(params string[] i_strings)
    {
        return Concatenate((IEnumerable<string>)i_strings);
    }

    public static string Concatenate(IEnumerable<string> i_strings)
    {
        if (i_strings == null)
        {
            throw new ArgumentNullException("i_strings", "i_strings must not be null.");
        }

        StringBuilder stringBuilder = new StringBuilder();
        foreach (string currentString in i_strings)
        {
            stringBuilder.Append(currentString);
        }

        return stringBuilder.ToString();
    }
}