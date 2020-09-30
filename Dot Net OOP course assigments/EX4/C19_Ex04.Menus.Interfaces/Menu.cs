namespace C19_Ex04.Menus.Interfaces
{
	// The below using statement is necessary to both use the static class Console and throw proper exceptions when necessary
	using System;

	// The below using statement is necessary to implement the interface IEnumerable in the Menu class.
    using System.Collections;

	// The below using statement is necessary to use the IndexerName attribute.
    using System.Runtime.CompilerServices;

	// SuperMenu is an alias for Menu because it is just a menu for everything.
    using SuperMenu = Menu;

	// ZeroBasedIndex is in fact an integer.
    using ZeroBasedIndex = System.Int64;

	// OneBasedIndex is in fact an integer.
    using OneBasedIndex = System.Int64;

	// A class that defines a menu for console applications only.
	// This class implements the interface IEnumerable, because theoretically every theoretical menu is both enumerable and iterable and this is possible to enumerate all the items of any given menu and iterate over all of them.
    public partial class Menu : IEnumerable
    {
		// All the items of the menu
        private readonly Menu.Item[] r_MenuItems;

		// The previous menu called "super".
		// This is the most recent menu that the user was in before he or she brought himself or herself to this menu.
		// This field is nullable and therefore it can have null value. If this field is null then this menu is necessarily the main menu.
        private SuperMenu m_SuperMenu;

		// A readonly property that just returns the preceding menu.
		internal SuperMenu SuperMenu
		{
			get { return m_SuperMenu; }
		}

		// The constructor to all create, instantiate, and initialize new Menu instances.
        public Menu(params Menu.Item[] i_MenuItems)
        {
            if (i_MenuItems == null)
            {
                throw new ArgumentNullException("i_MenuItems", "i_MenuItems must not be null.");
            }

            m_SuperMenu = null;
            r_MenuItems = i_MenuItems;

            for (long i = 0; i < i_MenuItems.LongLength; i++)
            {
                if (i_MenuItems[i].HasSubMenu)
                {
                    i_MenuItems[i].SubMenu.m_SuperMenu = this;
                }
            }
        }

		// A readonly property, as the name suggests, simply returns the number of items excluding the return option of the menu instance.
        internal long NumberOfItemsExcludingReturn
        {
            get { return r_MenuItems.LongLength; }
        }

		// A readonly property, as the name suggests, simply returns the number of items including the return option of the menu instance.
        private long NumberOfItemsIncludingReturn
        {
            get { return NumberOfItemsExcludingReturn + 1; }
        }

		// The indexer of the Menu class allows to access particular item by a one based index as an integer.
		// The attribute IndexerName was used here to call this indexer "Indexer".
		// By default every indexer is called "Item" and because of that the usage of the IndexerName attribute is necessary here, because
		// this is not possible to call the indexer "Item" while the Menu class has a member class also called "Item".
		// This causes an ambiguity and the compilation fails.
		// Of course that another solution was to call the member class of the Menu class by different name not "Item", but the member class should be called by this name,
		// to make the code more readable for the readers, so this solution is not carried out.
        [IndexerName("Indexer")]
        internal Menu.Item this[OneBasedIndex i_OneBasedIndex]
        {
            get
            {
                if (i_OneBasedIndex < 1 || i_OneBasedIndex > NumberOfItemsExcludingReturn)
                {
                    throw new IndexOutOfRangeException(string.Format("1 <= i_OneBasedIndex ({0}) <= NumberOfItemsExcludingReturn ({1})", i_OneBasedIndex, NumberOfItemsExcludingReturn));
                }

                return r_MenuItems[i_OneBasedIndex - 1];
            }
        }

		// This method returns true if and only if given zero based index is out of range and does not refer to any option of this menu instance.
        private bool IsZeroBasedIndexOutOfRangeIncludingReturnItem(ZeroBasedIndex i_ZeroBasedIndex)
        {
            return i_ZeroBasedIndex < 0 || i_ZeroBasedIndex >= NumberOfItemsIncludingReturn;
        }

		// A readonly property that the user of this class can use to determine for every instance of the Menu whether the Menu instance is MainMenu instance or not.
		// Of course that this readonly property is unnecessary since the "is" statement can be used instead to ask the exactly same question.

		// This readonly property can be implemented by using the "is" statement.

		// Another possible implementation is to make this property virtual and always return false in the Menu class and in the MainMenu class
		// override this property and always return true.

		// But the implementation of this readonly property uses the private readonly m_SuperMenu field only because maybe this implementation has the best performance.
        private bool IsMain
        {
            get { return m_SuperMenu == null; }
        }

		// A readonly property that returns the string "Exit" if the Menu instance is MainMenu instance and otherwise returns the string "Back".

		// The "is" statement can be used to implement this readonly property.
		// Another possible implementation is to make this property virtual and in the Menu class always return "Back" and in the MainMenu class always return "Exit".
		// But the implementation is to use the IsMain readonly property only that uses the m_SuperMenu private readonly field only maybe for best performance.
        internal string ReturnItemText
        {
            get { return IsMain ? "Exit" : "Back"; }
        }

		// The only method of the interface IEnumerable. The Menu class implements the IEnumerable interface and thus must implement the GetEnumerator method of the interface as well.
        public IEnumerator GetEnumerator()
        {
            return r_MenuItems.GetEnumerator();
        }

		// A method that prints a given prompt as input string parameter to the user and waits for the user to enter a valid integer that selects any option of the Menu instance.
        internal long GetChoice(string i_Prompt)
        {
			// Make exactly 1 space line
            Console.WriteLine();

			// Print the given prompt as input string parameter
			Console.Write(i_Prompt);
            
			// This variable is initially uninitialized and later stores the number that the user chooses.
			long userInputInteger;

			// If the number of items excluding the 0 "return" option of the current menu is at most 9 then the static method ReadLine of the static class Console is unnecessary and the static method ReadKey of the static class Console can be used here.
			if (NumberOfItemsExcludingReturn <= 9)
			{
				// Remember where is the cartesian discrete horizontal coordinate of the console cursor position.
				// This is good to remember this, because the static method ReadKey of the static class Console changes the cartesian discrete horizontal coordinate of the console cursor position, but never changes the other cartesian discrete coordinate that is the vertical.
				// That's why the cartesian discrete vertical coordinate of the console cursor position is not remembered.
				// This memory is used to bring the console cursor back to where it was before the invocation of the static method ReadKey of the static class Console.
                int consoleCursorLeftBeforeReadKey = Console.CursorLeft;

				// The convention requires defining this local constant boolean. not(v_Intercept) is passed as parameter to the static method ReadKey of the static class Console, because this is desired that ReadKey prints the character that the user entered where the cursor of the console currently is in the screen of the console.
				const bool v_Intercept = true;

				// Wait for the user to enter any key. Then subtract the returned key as 16 bit unsigned integer by the ascii number of the zero character and this is may be the number that the user chose.
				readKey:
				userInputInteger = Console.ReadKey(not(v_Intercept)).KeyChar - '0';

				// Verify that the chosen number selects any option of the current menu
				if (IsZeroBasedIndexOutOfRangeIncludingReturnItem(userInputInteger))
				{
					// If no then bring the console cursor back to where it was before the most recent invocation of the static method ReadKey of the static class Console.
					// This can be done because this algorithm remembers the cartesian discrete horizontal coordinate of the console cursor position before invoking the static method ReadKey of the static class Console.
					// This is unnecessary to remember the cartesian discrete vertical coordinate of the console cursor position, because the static method ReadKey of the static class Console either moves the console cursor only 1 character to the right or brings it to the beginning of the current line (or to the left most side of the console screen in other words) but it never changes the height of the console cursor at all.
					Console.CursorLeft = consoleCursorLeftBeforeReadKey;

					// Then remove from the console screen the wrong number that the user entered.
					Console.Write(" \b");

					// Invoke again the static method ReadKey of the static class Console until the user enters a valid number that selects any option of the current menu.
					goto readKey;
				}
			}
			else
			{
				// The number of items excluding the 0 "return" option of the current menu is at least 10 and the static method ReadKey of the static class Console cannot be used here to let the user to choose all possible options of the current menu, so the static method ReadLine of the static class Console is necessarily used instead.
				// Remember where is the cartesian discrete horizontal coordinate of the console cursor position, because the static method ReadLine of the static class Console also moves the cursor of the console to a different location.
				// Note that the cartesian discrete vertical coordinate of the console cursor position is not remembered, because the static method ReadLine of the static class Console always moves the cursor of the console to the beginning of the next line,
				// so to bring the cursor of the console back to the height it was before the invocation of the static method ReadLine of the static class Console, all what have to be done is to move the console cursor just 1 character up and that's it.
                int consoleCursorLeftBeforeReadLine = Console.CursorLeft;

				// Wait for the user to enter any string.
				readLine:
				string line = Console.ReadLine();

				// Verify that the user entered an integer.
				if (succeed(long.TryParse(line, out userInputInteger)))
				{
					// If yes then verify that this integer in range and selects any option of the current menu
					if (IsZeroBasedIndexOutOfRangeIncludingReturnItem(userInputInteger))
					{
						// If no then the same logic happen when user entered invalid integer when the static method ReadKey of the static class Console was invoked,
						// but the same code do not happen, because the static method ReadLine of the static class Console does more changes than the static method ReadKey of the static class Console.
						// Therefore more actions have to be performed to undo all the changes that the static method ReadLine of the static class Console did.

						// The static method SetCursorPosition of the static class Console is invoked to bring the cursor back to where it was exactly before the most recent invocation of the static method ReadLine of the static class Console.
						// The memory of where the cursor of the console was from left to right is used, but there is no memory where the cursor of the console was from top to bottom, because the static method ReadLine of the static class Console always brings the cursor to the beginning of the next line, so simply moves it to the previous line that is just 1 character up and that's it.
						Console.SetCursorPosition(consoleCursorLeftBeforeReadLine, Console.CursorTop - 1);

						// After the cursor of the console has been brough back to where it was before the most recent invocation of the static method ReadLine of the static class Console
						// Write N space characters where N is the number of characters that the user entered and his or her input has been proven invalid.
						// This ensures that the text that the user entered is both completely and entirely erased by spaces. 
						Console.Write(new string(' ', line.Length));

						// But this action also moves the cursor of the console N characters to the right, so after the erase this algorithm have to move the console cursor N characters to the left
						// to ensure that the cursor of the console is where it was exactly before the most recent invocation of the static method ReadLine of the static class Console.
						Console.CursorLeft -= line.Length;

						// Invoke again the static method ReadLine of the static class Console until the user enters a valid number that selects any option of the current menu.
						goto readLine;
					}
				}
				else
				{
					// User did not enter an integer
					// Do exactly the same thing that has to be done when the user did enter an integer, but this integer is out of range and does not select any option of the current menu.
					// In short undo all the changes that the static method ReadLine of the static class Console did by moving the cursor of the console back to where it was exactly before the invocation of the static method ReadLine of the static class Console
					// and delete the invalid text that the user entered by printing N spaces where N is the length of the string that the user entered in characters. At last move the cursor of the console N characters to the left.
					Console.SetCursorPosition(consoleCursorLeftBeforeReadLine, Console.CursorTop - 1);
					Console.Write(new string(' ', line.Length));
					Console.CursorLeft -= line.Length;
					goto readLine;
				}
			}

			// At this point the user entered a valid integer so it can be returned to the invoker of this GetChoice method safely.
            return userInputInteger;
        }

		// This method is used to tell if other methods succeed or fail. These other methods must return a boolean value that indicates whether the method succeed or failed.
		// This method is unnecessary to make the Menu class functioning properly, but it is used to make the code more readable for the readers.
        private bool succeed(bool i_Boolean)
        {
            return i_Boolean;
        }

		// Functions like the boolean exclamation operator ! but this method is used instead of the operator to make the code more readable for the readers.
        private bool not(bool i_Boolean)
        {
            return !i_Boolean;
        }
    }
}