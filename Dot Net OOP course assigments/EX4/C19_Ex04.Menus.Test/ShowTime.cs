namespace C19_Ex04.Menus.Test
{
    using System;
    using Interfaces;

    internal struct ShowTime : IAction
    {
        public void Perform()
        {
            Console.WriteLine(DateTime.Now.TimeOfDay);
            Console.WriteLine();
            Console.Write("Press any key to return to the last menu...");
            const bool v_Intercept = true;
            Console.ReadKey(v_Intercept);
        }
    }
}