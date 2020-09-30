namespace C19_Ex02
{
    using System;
    using System.Threading;
    using Ex02.ConsoleUtils;


    // $G$ DSN-999 (-20) Its not object oriented programming to write all the code in the same class Program

    public static class Program
    {

        // $G$ CSS-999 (-3) You should have used constants here.
        // $G$ DSN-999 (-5) this method is to long - should be divided to several methods
        // $G$ CSS-999 (-5) main should be short and not interactive with the user
        public static void Main()
        {
            Console.Title = "בול פגיעה";
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            bool playerWantsToStartANewGame = true;
            while (playerWantsToStartANewGame)
            {
                Console.WriteLine("How many tries (between 4 to 10)?");
                Console.Write("Answer: ");
                byte numberOfRetries = readNumberOfRetries();
                s_BoardRows = new TuringMachine<BoardRow>(numberOfRetries, new BoardRow("         ", "       "));
                BulPegia.GenerateRandomPassword();
                string guess = null;
                long headMovement;
                do
                {
                    Screen.Clear();
                    Console.WriteLine("Current board status:" + Environment.NewLine);
                    writeBoard();
                    if (guess != BulPegia.Password)
                    {
                        Console.WriteLine("Enter next guess (4 letters between A to H) or 'Q' to quit");
                        guess = readGuess();
                        headMovement = (long)BulPegia.AppendNewRowToBoard(
                        guess,
                        delegate(string i_pin, string i_result)
                        {
                            return s_BoardRows.Write(new BoardRow(i_pin, i_result));
                        });
                    }
                    else
                    {
                        BulPegia.PlayerSuccessfullyGuessedPassword(Console.WriteLine, (byte)currentBoardRowIndex);
                        goto askPlayerIfHeOrSheWouldLikeToStartANewGame;
                    }
                }
                while (headMovement == 1);
                Screen.Clear();
                Console.WriteLine("Current board status:" + Environment.NewLine);
                const bool v_WritePassword = true;
                writeBoard(v_WritePassword);
                if (guess == BulPegia.Password)
                {
                    BulPegia.PlayerSuccessfullyGuessedPassword(Console.WriteLine, BulPegia.k_PasswordLength);
                    goto askPlayerIfHeOrSheWouldLikeToStartANewGame;
                }

                Console.WriteLine(BulPegia.k_LossMessage);
                askPlayerIfHeOrSheWouldLikeToStartANewGame:
                Console.WriteLine(BulPegia.k_YesNoQuestionAboutStartingANewGame + " (Y/N)");
                const bool v_intercept = true;
                switch (ConsoleInput.ReadKey(isInvalidKey, not(v_intercept)).KeyChar)
                {
                    case 'y':
                    case 'Y':
                        playerWantsToStartANewGame = true;
                        Screen.Clear();
                        break;
                    case 'n':
                    case 'N':
                        playerWantsToStartANewGame = false;
                        Console.WriteLine(Environment.NewLine);
                        Console.WriteLine(BulPegia.k_GoodByeMessage);
                        Console.WriteLine(k_PressAnyKeyToExitMessage);
                        Console.ReadKey(v_intercept);
                        break;
                    default: throw new UnreachableCodeReachedException();
                }
            }
        }

        private const string k_PressAnyKeyToExitMessage = "Press any key to exit . . .";

        private static byte readNumberOfRetries()
        {
            return (byte)(sbyte)ConsoleInput.ReadLine(
                BulPegia.IsInvalidNumberOfRetriesInputString,
                delegate(string i_string, Enum i_reason)
                {
                    Console.WriteLine();
                    Console.WriteLine(i_string);
                    Console.Write("Answer: ");
                });
        }

        private static string readGuess()
        {
            return (string)ConsoleInput.ReadLine(
                BulPegia.IsInvalidGuessInputString,
                delegate(string i_message, Enum i_reason)
                {
                    switch ((BulPegia.eInputStringIsInvalidGuessBecause)i_reason)
                    {
                        case BulPegia.eInputStringIsInvalidGuessBecause.ItIsTheEnglishLetterQ:
                        {
                            Console.WriteLine();
                            Console.Write(i_message);
                            Console.WriteLine();
                            Console.WriteLine(k_PressAnyKeyToExitMessage);
                            const bool v_intercept = true;
                            Console.ReadKey(v_intercept);
                        }

                        break;
                        case BulPegia.eInputStringIsInvalidGuessBecause.HisLengthIsNotEqualToTheLengthOfThePassword:
                            Console.WriteLine(i_message);
                        break;
                    }
                });
        }

        private struct BoardRow
        {
            private string m_pin;
            private string m_result;

            public BoardRow(string i_pin, string i_result)
            {
                m_pin = i_pin;
                m_result = i_result;
            }

            public string Pin
            {
                get
                {
                    return m_pin;
                }

                set
                {
                    m_pin = value;
                }
            }

            public string Result
            {
                get
                {
                    return m_result;
                }

                set
                {
                    m_result = value;
                }
            }

            public void Write()
            {
                Console.WriteLine("|=========|=======|");
                Console.Write('|');
                Console.Write(m_pin);
                Console.Write('|');
                Console.Write(m_result);
                Console.WriteLine('|');
            }
        }

        private static TuringMachine<BoardRow> s_BoardRows = null;

        private static BoardRow currentBoardRow
        {
            get
            {
                return s_BoardRows.CurrentSymbol;
            }

            set
            {
                s_BoardRows.CurrentSymbol = value;
            }
        }

        private static long currentBoardRowIndex
        {
            get
            {
                return s_BoardRows.HeadPosition;
            }

            set
            {
                s_BoardRows.HeadPosition = value;
            }
        }

        private static long indexOfFirstBoardRow
        {
            get
            {
                return s_BoardRows.PositionOfFirstSymbol;
            }
        }

        private static long indexOfLastBoardRow
        {
            get
            {
                return s_BoardRows.PositionOfLastSymbol;
            }
        }

        // $G$ CSS-013 (-3) Input parameters names should start with i_PascaleCase.
        private static bool isInvalidKey(ConsoleKeyInfo i_key)
        {
            bool answer;
            if (char.ToUpper(i_key.KeyChar) != 'Y' && char.ToUpper(i_key.KeyChar) != 'N')
            {
                Console.Write("\b \b");
                answer = true;
            }
            else
            {
                answer = false;
            }

            return answer;
        }

        private static void writeBoard(bool i_WritePassword = false)
        {
            Console.WriteLine("|Pins:    |Result:|");
            Console.WriteLine("|=========|=======|");
            Console.Write('|');
            BulPegia.WritePassword(Console.Write, i_WritePassword);
            Console.WriteLine("|       |");
            foreach (BoardRow boardRow in s_BoardRows)
            {
                boardRow.Write();
            }

            Console.WriteLine("|=========|=======|" + Environment.NewLine);
        }

        // $G$ CSS-013 (-3) Input parameters names should start with i_PascaleCase.
        private static bool not(bool i_boolean)
        {
            return !i_boolean;
        }
    }
}