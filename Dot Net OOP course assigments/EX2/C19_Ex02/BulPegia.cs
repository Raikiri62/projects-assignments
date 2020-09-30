using System;
using System.Text;
using System.Threading;
using System.Diagnostics;

// $G$ DSN-002 (-20) No separation between the logical part of the game and the UI.

public static class BulPegia
{
    public const byte k_MinimumNumberOfRetries = 4;
    public const byte k_MaximumNumberOfRetries = 10;
    public const byte k_PasswordLength = 4;
    public const char k_MinimumRandomCharacter = 'A';
    public const byte k_RandomCharacterRange = 8;
    public const char k_MaximumRandomCharacter = (char)(k_MinimumRandomCharacter + k_RandomCharacterRange - 1);
    public const char k_HiddenPasswordCharacter = '#';
    public const string k_GoodByeMessage = "Good Bye!";
    public const string k_YesNoQuestionAboutStartingANewGame = "Would you like to start a new game?";
    public const string k_LossMessage = "No more guesses allowed. You Lost.";

    private static string s_password = null;

    public static string Password
    {
        get
        {
            return s_password;
        }
    }

    // $G$ CSS-013 (-3) Input parameters names should start with i_PascaleCase.
    public static bool IsInvalidNumberOfRetriesInputString(string i_string, Action<string, Enum> o_display, out object o_NumberOfRetries)
    {
        bool answer;
        sbyte numberOfRetries;
        if (fails(sbyte.TryParse(i_string, out numberOfRetries)))
        {
            o_display("Answer must be an unsigned integer.", eInputStringIsInvalidNumberOfRetriesBecause.ItIsNotAnInteger);
            answer = true;
        }
        else if (numberOfRetries < k_MinimumNumberOfRetries || numberOfRetries > k_MaximumNumberOfRetries)
        {
            o_display(string.Format("An integer between {0} to {1} is expected.", k_MinimumNumberOfRetries, k_MaximumNumberOfRetries), eInputStringIsInvalidNumberOfRetriesBecause.ItIsNotInTheRange);
            answer = true;
        }
        else
        {
            answer = false;
        }

        o_NumberOfRetries = numberOfRetries;
        return answer;
    }

    public enum eInputStringIsInvalidNumberOfRetriesBecause
    {
        ItIsNotAnInteger,
        ItIsNotInTheRange
    }

    private static bool fails(bool i_boolean)
    {
        return not(i_boolean);
    }

    private static bool not(bool i_boolean)
    {
        return !i_boolean;
    }

    // $G$ NTT-007 (-10) There's no need to re-instantiate the Random instance each time it is used.
    private static string generateRandomPassword()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            char[] password = new char[k_PasswordLength];
            bool[] alreadyGenerated = new bool[8];
            for (long i = 0; i < password.Length; i++)
            {
                char randomCharacter;
                long indexOfRandomCharacter;
                do
                {
                    randomCharacter = (char)random.Next(k_MinimumRandomCharacter, k_MaximumRandomCharacter + 1);
                    indexOfRandomCharacter = randomCharacter - k_MinimumRandomCharacter;
                }
                while (alreadyGenerated[indexOfRandomCharacter]);
                password[i] = randomCharacter;
                alreadyGenerated[indexOfRandomCharacter] = true;
            }

            return new string(password);
        }

    public static void GenerateRandomPassword()
        {
            s_password = generateRandomPassword();
        }

    public static void WritePassword(Action<char> o_display, bool i_WritePassword = false)
        {
            o_display(' ');
            foreach (char character in s_password)
            {
                o_display(i_WritePassword ? character : k_HiddenPasswordCharacter);
                o_display(' ');
            }
        }


    // $G$ CSS-999 (-3) You should have used constants here.
    public static bool IsInvalidGuessInputString(string i_line, Action<string, Enum> o_display, out object o_guess)
    {
        i_line = i_line.ToUpper();
        if (i_line == "Q")
        {
            o_display(k_GoodByeMessage, eInputStringIsInvalidGuessBecause.ItIsTheEnglishLetterQ);
            Process.GetCurrentProcess().Kill();
        }

        bool answer;
        string guess = extractGuess(i_line);
        if (guess.Length != k_PasswordLength)
        {
            o_display(string.Format("A 4 capital letters between {1} to {2} is expected.", k_PasswordLength, k_MinimumRandomCharacter, k_MaximumRandomCharacter), eInputStringIsInvalidGuessBecause.HisLengthIsNotEqualToTheLengthOfThePassword);
            answer = true;
        }
        else
        {
            answer = false;
        }

        o_guess = guess;
        return answer;
    }

    public enum eInputStringIsInvalidGuessBecause
    {
        ItIsTheEnglishLetterQ,
        HisLengthIsNotEqualToTheLengthOfThePassword
    }

    private static string extractGuess(string i_line)
    {
        if (i_line == null)
        {
            throw new ArgumentNullException("i_line", "i_line must not be null.");
        }

        StringBuilder guess = new StringBuilder();
        foreach (char character in i_line)
        {
            if (character >= k_MinimumRandomCharacter && character <= k_MaximumRandomCharacter)
            {
                guess.Append(character);
            }
        }

        return guess.ToString();
    }

    private static string calculateResult(string i_guess)
        {
            if (i_guess == null)
            {
                throw new ArgumentNullException("i_guess", "i_guess must not be null.");
            }

            TuringMachine<char> result = new TuringMachine<char>((2 * k_PasswordLength) - 1, ' ');
            bool[] v = writeVResult(i_guess, result);
            writeXResult(i_guess, result, v);
            return new string(result.TapeContent);
        }

    private static bool[] writeVResult(string i_guess, TuringMachine<char> o_result)
    {
        if (i_guess == null)
        {
            throw new ArgumentNullException("i_guess", "i_guess must not be null.");
        }

        if (o_result == null)
        {
            throw new ArgumentNullException("o_result", "o_result must not be null.");
        }

        bool[] v = new bool[k_PasswordLength];
        for (int i = 0; i < k_PasswordLength; i++)
        {
            if (i_guess[i] == s_password[i])
            {
                o_result.Write('V', 2);
                v[i] = true;
            }
        }

        return v;
    }

    // $G$ CSS-013 (-3) Input parameters names should start with i_PascaleCase.
    private static void writeXResult(string i_guess, TuringMachine<char> o_result, bool[] i_v)
    {
        if (i_guess == null)
        {
            throw new ArgumentNullException("i_guess", "i_guess must not be null.");
        }

        if (o_result == null)
        {
            throw new ArgumentNullException("o_result", "o_result must not be null.");
        }

        if (i_v == null)
        {
            throw new ArgumentNullException("i_v", "i_v must not be null.");
        }

        for (int i = 0; i < k_PasswordLength; i++)
        {
            if (i_v[i])
            {
                continue;
            }

            if (StringUtils.IsMemberOf(i_guess[i], s_password))
            {
                o_result.Write('X', 2);
            }
        }
    }

    private static string makePin(string i_guess)
    {
        StringBuilder pin = new StringBuilder();
        pin.Append(' ');
        foreach (char currentCharacter in i_guess)
        {
            pin.Append(currentCharacter + " ");
        }

        return pin.ToString();
    }

    public static object AppendNewRowToBoard(string i_guess, Func<string, string, object> o_AppendNewRowToBoard)
    {
        string pin = makePin(i_guess);
        string result = calculateResult(i_guess);
        return o_AppendNewRowToBoard(pin, result);
    }

    public static void PlayerSuccessfullyGuessedPassword(Action<string> o_display, byte i_PlayerNumberOfGuessesBeforeSuccess)
    {
        o_display(string.Format("You guessed after {0} step{1}!", i_PlayerNumberOfGuessesBeforeSuccess, i_PlayerNumberOfGuessesBeforeSuccess != 1 ? "s" : string.Empty));
    }
}