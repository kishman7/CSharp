using System;

namespace H1
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1;

            while(Convert.ToBoolean(a))
            {
                Console.Write("1. C to F\n2. F to C\n0. Exit\n ->");
                a = Convert.ToInt32(Console.ReadLine());

                double temp = 0;
                if (a == 1)
                {
                    Console.Write("Enter C ->");
                    temp = Convert.ToInt32(Console.ReadLine());
                    Console.Write("{0} C = {1} F\n", temp, temp * 1.8 + 32);
                }
                else if (a == 2)
                {
                    Console.Write("Enter F ->");
                    temp = Convert.ToInt32(Console.ReadLine());
                    Console.Write("{0} F = {1} C\n", temp, (temp - 32) / 1.8);
                }
            }
        }

    }
}
