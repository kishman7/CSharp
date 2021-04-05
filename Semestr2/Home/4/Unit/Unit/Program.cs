using System;

namespace Unit
{
    class Program
    {
        static void Main(string[] args)
        {
            Teams red = new Teams();
            Teams blue = new Teams();

            while (red.GetCount > 0 && blue.GetCount > 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Red Attack!");
                red.Attacking(blue);
                
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(" Blue Attack!");
                blue.Attacking(red);

                Console.ReadKey();
            }

            if (red.GetCount == 0)
                Console.WriteLine($"Blue Team Victory!!!");
            else
                Console.WriteLine($"Red Team Victory!!!");

            Console.ReadLine();
        }
    }
}
