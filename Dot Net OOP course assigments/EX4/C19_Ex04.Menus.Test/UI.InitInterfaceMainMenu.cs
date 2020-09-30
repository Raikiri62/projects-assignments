namespace C19_Ex04.Menus.Test
{
	using InterfaceMainMenu = Interfaces.MainMenu;
    using InterfaceSubMenu = Interfaces.Menu;
    using InterfaceMenuItem = Interfaces.Menu.Item;

	internal partial struct UI
	{
		internal InterfaceMainMenu InitInterfaceMainMenu()
		{
			return new InterfaceMainMenu(
            "Interface Main Menu",
            new InterfaceMenuItem("Show Date/Time", new InterfaceSubMenu(new InterfaceMenuItem("Show Time", new ShowTime()), new InterfaceMenuItem("Show Date", new ShowDate()))),
            new InterfaceMenuItem("Version and Digits", new InterfaceSubMenu(new InterfaceMenuItem("Show Version", new ShowVersion()), new InterfaceMenuItem("Count Spaces", new CountSpaces()))));
		}
	}
}