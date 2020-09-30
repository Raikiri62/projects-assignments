namespace C19_Ex04.Menus.Test
{
    using System;
    using Interfaces;

    internal struct ShowVersion : IAction
    {
        public void Perform()
        {
            Console.WriteLine("Version: 19.3.4.42");
            Console.WriteLine();
            Console.Write("Press any key to return to the last menu...");
            const bool v_Intercept = true;
            Console.ReadKey(v_Intercept);
        }
    }
}