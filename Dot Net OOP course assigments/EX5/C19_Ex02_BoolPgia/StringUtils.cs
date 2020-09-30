using System;
using System.Text;
using System.Collections.Generic;

public static class StringUtils
{
    public static bool IsMemberOf(char i_character, string i_String)
    {
        if (i_String == null)
        {
            throw new ArgumentNullException("i_string", "i_string must not be null.");
        }

        bool answer = false;
        foreach (char currentCharacter in i_String)
        {
            if (i_character == currentCharacter)
            {
                answer = true;
                break;
            }
        }

        return answer;
    }

    public static string Concatenate(params string[] i_Strings)
    {
        return Concatenate((IEnumerable<string>)i_Strings);
    }

    public static string Concatenate(IEnumerable<string> i_Strings)
    {
        if (i_Strings == null)
        {
            throw new ArgumentNullException("i_strings", "i_strings must not be null.");
        }

        StringBuilder stringBuilder = new StringBuilder();
        foreach (string currentString in i_Strings)
        {
            stringBuilder.Append(currentString);
        }

        return stringBuilder.ToString();
    }

	public static bool ContainsDuplicates(string i_String)
	{
	}
}