using System;

namespace Home2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Push key ");
            int c = 0;
            while (true)
            {
               c = Console.Read();
                if (c < 97)
                    Console.WriteLine(((char)c).ToString().ToLower());
                else
                    Console.WriteLine(((char)c).ToString().ToUpper());
            }
        }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        