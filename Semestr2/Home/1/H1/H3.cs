using System;
namespace H3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calculator");

            int a = 1;

            double A = 0;
            double B = 0;

            while (Convert.ToBoolean(a))
            {
                A = Convert.ToDouble(Console.ReadLine());

                ConsoleKeyInfo ck = Console.ReadKey(true);
                Console.WriteLine(ck.KeyChar);

                B = Convert.ToDouble(Console.ReadLine());
                try
                {
                    switch (ck.Key)
                    {
                        case ConsoleKey.Subtract: // -
                            {
                                Console.WriteLine("=\n{0}", A - B);
                                break;
                            }
                        case ConsoleKey.Add: // +
                            {
                                Console.WriteLine("=\n{0}", A + B);
                                break;
                            }
                        case ConsoleKey.Multiply: // *
                            {
                                Console.WriteLine("=\n{0}", A * B);
                                break;
                            }
                        case ConsoleKey.Divide: // /
                            {
                                Console.WriteLine("=\n{0}", A / B);
                                break;
                            }
                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
