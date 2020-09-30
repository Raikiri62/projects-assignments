namespace C19_Ex04.Menus.Interfaces
{
	// The below using statement is necessary in order to use the Console static class.
	using System;

	// The below using statement is necessary in order to use the Sleep static method of the Thread class.
	using System.Threading;

	// The below using statement is necessary in order to use the Stack generic class.
	using System.Collections.Generic;

	// A class that defines a main menu for console applications only.
	// This is an extension of the Menu class and only instances of this class can invoke the Show method.
    public class MainMenu : Menu
    {
		// The title of the main menu.
        private readonly string r_Title;

		// The constructor to all create, instantiate and initialize new MainMenu instances.
        public MainMenu(string i_Title, params Menu.Item[] i_MenuItems) : base(i_MenuItems)
        {
            r_Title = i_Title;
        }

		// The method Show, as the name suggests, shows the first level of the MainMenu instance and in addition enters into a loop that is left only when the user chooses the "Exit" option.
		// While the "Exit" option is not choosen, the user can interact with the main menu, select other options, show submenus and run console programs similar to how the MS DOS operating system was both functioning and working.
		public void Show()
        {
            Menu currentMenu = this; // "this" is the readonly reference to the main menu. Current menu is initially the main menu.
            Stack<string> currentTitle = new Stack<string>(); // This is the stack of titles as strings of all the menus that the user visited and didn't choose the "Back" option for each in them.
			currentTitle.Push(r_Title); // Current menu title is initially the title of the main menu.

			// Current menu becomes null only when the "Exit" option of the main menu has been chosen by the user.
			// When the user chooses the "Exit" option in the main menu this is the perfect time to exit this while loop and return to the invoker of this Show method.
            while (currentMenu != null) 
            {
				// Remove all text from the console screen and bring the console cursor to the top left most origin point (0,0), because the user have to see only the current menu.
                Console.Clear();

				// The following code prints the title of the current menu, that is either the title of the main menu or the text of the most recent chosen item by the user.
                Console.WriteLine(new string('=', currentTitle.Peek().Length));
                Console.WriteLine(currentTitle.Peek());
                Console.WriteLine(new string('=', currentTitle.Peek().Length));

				// Make exactly 1 space between the title of the current menu and all the options of the current menu.
                Console.WriteLine();

				// The number of the first option is always 0 and the text of the first option is always "Exit" for the main menu and "Back" for all the other submenus.
                Console.WriteLine("0. " + currentMenu.ReturnItemText);

				// Prints all the items (both number and text) of the current menu starting from number 1.
				for (long i = 1; i <= currentMenu.NumberOfItemsExcludingReturn; i++)
				{
					Console.WriteLine(i + ". " + currentMenu[i].Text);
				}

				// Wait for the user to enter an integer that selects an item of the current menu.
                long userInputInteger = currentMenu.GetChoice("Enter your choice: ");

				// When the user has made his or her choice wait 750 milliseconds.
				// In this time the user can see the number of the option that he or she chose.
                Thread.Sleep(750);

				// If the user did not choose option 0 that is "Exit" for the main menu and "Back" for all the other submenus then
                if (userInputInteger > 0)
                {
					// If the item that the user chose opens a submenu then
					if (currentMenu[userInputInteger].HasSubMenu)
					{
						// Current title is the text of the chosen item, but previous titles are remembered in the stack and will be printed again when the user returns back to the previous menus that he or she visited.
                        currentTitle.Push(currentMenu[userInputInteger].Text);

						// Current menu is the submenu that the chosen item opens.
						currentMenu = currentMenu[userInputInteger].SubMenu;
					}
					else
					{
						// The chosen item runs some console program.
						// Before running the console program of the chosen item, clear the console screen.
						Console.Clear();

						// Then print the text of the chosen item as title.
                        Console.WriteLine(new string('=', currentMenu[userInputInteger].Text.Length));
                        Console.WriteLine(currentMenu[userInputInteger].Text);
                        Console.WriteLine(new string('=', currentMenu[userInputInteger].Text.Length));

						// Make exactly 1 space line.
                        Console.WriteLine();

						// Now run the console program of the chosen item.
						currentMenu[userInputInteger].Invoke();
					}
                }
                else
                {
					// The user chose option 0 that is "Exit" for the main menu and "Back" for all the other submenus
					// Current menu is now the previous menu that the "Back" option brings back.
					// If that option was "Exit" instead and current menu was the main menu then currentMenu becomes null so the while loop ends and the method Show returns back to the invoker.
                    currentMenu = currentMenu.SuperMenu;

					// The user goes back to the previous menu, so the title of the current menu is popped, disposed and discarded.
                    currentTitle.Pop();
                }
            }

			// At last or finally clear the main menu before returning back to the invoker of this Show method.
			Console.Clear();
        }
    }
}