namespace C19_Ex04.Menus.Test
{
	using DelegateMainMenu = Delegates.MainMenu;
    using DelegateSubMenu = Delegates.Menu;
    using DelegateMenuItem = Delegates.Menu.Item;

	internal partial struct UI
	{
		internal DelegateMainMenu InitDelegateMainMenu()
		{
			return new DelegateMainMenu(
			"Delegate Main Menu",
			new DelegateMenuItem("Show Date/Time", new DelegateSubMenu(new DelegateMenuItem("Show Time", new ShowTime().Perform), new DelegateMenuItem("Show Date", new ShowDate().Perform))), 
			new DelegateMenuItem("Version and Digits", new DelegateSubMenu(new DelegateMenuItem("Show Version", new ShowVersion().Perform), new DelegateMenuItem("Count Spaces", new CountSpaces().Perform))));
		}
	}
}