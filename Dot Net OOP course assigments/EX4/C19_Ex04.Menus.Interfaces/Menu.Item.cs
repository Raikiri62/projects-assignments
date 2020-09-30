namespace C19_Ex04.Menus.Interfaces
{
	// The below using statement is necessary in order to throw proper exceptions when necessary.
    using System;

	// SubMenu is an alias for Menu because it is just a menu for everything.
    using SubMenu = Menu;

	// A class that defines a menu for console applications only.
    public partial class Menu
    {
		// A class that defines a menu item for console applications only. Makes sense that this class is member of the Menu class.
        public partial struct Item
        {
			// The text of the menu item.
            private readonly string r_Text;

			// The object of the menu item.
			// This object is either a reference to a SubMenu or IAction interface that only has a Perform method that takes no parameters and returns void.
            private readonly object r_Object;

			// A constructor to all create, instantiate and initialize a new menu item whose object implements the IAction interface.
            public Item(string i_Text, IAction i_IAction)
            {
                if (i_Text == null)
                {
                    throw new ArgumentNullException("i_Text", "i_Text must not be null.");
                }

                if (i_IAction == null)
                {
                    throw new ArgumentNullException("i_IAction", "i_IAction must not be null.");
                }

                r_Text = i_Text;
                r_Object = i_IAction;
            }

			// A constructor to all create, instantiate and initialize a new menu item whose object is SubMenu.
            public Item(string i_Text, SubMenu i_Menu)
            {
                if (i_Text == null)
                {
                    throw new ArgumentNullException("i_Text", "i_Text must not be null.");
                }

                if (i_Menu == null)
                {
                    throw new ArgumentNullException("i_Menu", "i_Menu must not be null.");
                }

                r_Text = i_Text;
                r_Object = i_Menu;
            }

			// A readonly property that simply returns the text of the menu item instance.
            internal string Text
            {
                get { return r_Text; }
            }

			// A readonly property that simply returns the object of the menu item instance as IAction.
            internal IAction IAction
            {
                get { return r_Object as IAction; }
            }

			// A readonly property that simply returns the object of the menu item instance as SubMenu.
            internal SubMenu SubMenu
            {
                get { return r_Object as SubMenu; }
            }

			// A readonly property that simply returns true if and only if the object of the menu item instance is SubMenu.
            internal bool HasSubMenu
            {
                get { return r_Object is SubMenu; }
            }

			// A readonly property that simply returns true if and only if the object of the menu item instance implements the IAction interface.
            internal bool IsIAction
            {
                get { return r_Object is IAction; }
            }

			// A method that invokes the Perform method of the object of the menu item instance and then returns null if the object of the menu item instance implements the IAction interface.
			// Otherwise the object of the menu item instance is submenu and a reference to the submenu is returned. Nothing happen before the return.
            internal SubMenu Invoke()
            {
                SubMenu output;

                if (r_Object is IAction)
                {
                    (r_Object as IAction).Perform();
                    output = null;
                }
                else if (r_Object is SubMenu)
                {
                    output = r_Object as SubMenu;
                }
                else
                {
                    throw new UnreachableCodeReachedException();
                }

                return output;
            }
        }
    }
}