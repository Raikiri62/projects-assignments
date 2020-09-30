namespace C19_Ex04.Menus.Test
{
    using System;
    using Interfaces;

    internal struct CountSpaces : IAction
    {
        public void Perform()
        {
            Console.Write("Please write a sentence: ");
            string readLine = Console.ReadLine();
            ulong spaceCounter = 0;

            foreach (char currentCharacter in readLine)
            {
                if (char.IsWhiteSpace(currentCharacter))
                {
                    spaceCounter++;
                }
            }

            Console.WriteLine("Your sentence has " + spaceCounter + " spaces.");
            Console.WriteLine();
            Console.Write("Press any key to return to the last menu...");
            const bool v_Intercept = true;
            Console.ReadKey(v_Intercept);
        }
    }
}