namespace C19_Ex04.Menus.Test
{
    using System;

    using InterfaceMainMenu = Interfaces.MainMenu;
	using DelegateMainMenu = Delegates.MainMenu;

    internal partial struct UI
    {
        internal void Run()
        {
            Console.Title = "Menus";
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            InterfaceMainMenu interfaceMainMenu = InitInterfaceMainMenu();
            DelegateMainMenu delegateMainMenu = InitDelegateMainMenu();

            interfaceMainMenu.Show();
            delegateMainMenu.Show();
        }
    }
}