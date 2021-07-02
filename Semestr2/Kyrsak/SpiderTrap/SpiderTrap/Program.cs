using System;

namespace SpiderTrap
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.BufferWidth = 280;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.CursorVisible = false;
            Settings.Setting.GetType();

            bool play = true;
            while (play)
            {
                Menu.PrintStartLogo();
                play = Menu.ShowMain();
            }
        }

       

    }
}
