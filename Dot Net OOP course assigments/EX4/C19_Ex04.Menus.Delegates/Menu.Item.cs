namespace C19_Ex04.Menus.Delegates
{
	// The below using statement is necessary in order to throw proper exceptions when necessary
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
			// This object is either a reference to a SubMenu or Action delegate (references to methods that take no parameters and returns void)
            private readonly object r_Object;

			// A constructor to all create, instantiate and initialize a new menu item that performs some actions when chosen by the user
            public Item(string i_Text, Action i_Action)
            {
                if (i_Text == null)
                {
                    throw new ArgumentNullException("i_Text", "i_Text must not be null.");
                }

                if (i_Action == null)
                {
                    throw new ArgumentNullException("i_Action", "i_Action must not be null.");
                }

                r_Text = i_Text;
                r_Object = i_Action;
            }

			// A constructor to all create, instantiate and initialize a new menu item that shows a submenu when chosen by the user
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

			// A readonly property that simply returns the text of the menu item instance
            internal string Text
            {
                get { return r_Text; }
            }

			// A readonly property that simply returns the Action of the menu item if the object of the menu item is Action. Otherwise returns null.
            internal Action Action
            {
                get { return r_Object as Action; }
            }

			// A readonly property that simply returns a reference to the SubMenu of the menu item if the object of the menu item is SubMenu. Otherwise returns null.
            internal SubMenu SubMenu
            {
                get { return r_Object as SubMenu; }
            }

			// A readonly property that simply returns true if and only if the menu item instance opens a submenu when chosen by the user.
            internal bool HasSubMenu
            {
                get { return r_Object is SubMenu; }
            }

			// A readonly property that simply returns true if and only if the menu item instance performs any action when chosen by the user.
            internal bool IsAction
            {
                get { return r_Object is Action; }
            }

			// A method that performs the Action of the menu item instance and then returns null if the menu item instance owns an Action delegate.
			// Otherwise the menu item instance owns a submenu and a reference to the submenu is returned. Nothing happen before the return.
            internal SubMenu Invoke()
            {
                SubMenu output;

                if (r_Object is Action)
                {
                    (r_Object as Action)();
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