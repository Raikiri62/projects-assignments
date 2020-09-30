using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;



namespace C19_Ex05_WindowsUI
{
    // $G$ DSN-999 (-5) The entry point of the application should be public

	// An internal static class that defines the main entry point for the application.
	internal static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new NumberOfChances());
		}
	}
}
