using System;

namespace H2
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 1;

            while (Convert.ToBoolean(a))
            {
                Console.Write("1. cm to inch\n2. inch to cm\n0. Exit\n ->");
                a = Convert.ToInt32(Console.ReadLine());

                double temp = 0;

                switch (a)
                {
                    case 1:
                        {
                            Console.Write("Enter cm ->");
                            temp = Convert.ToDouble(Console.ReadLine());
                            Console.Write("{0} cm = {1} inch\n", temp, temp * 1.8 + 32);
                            break;
                        }
                    case 2:
                        {
                            Console.Write("Enter inch ->");
                            temp = Convert.ToDouble(Console.ReadLine());
                            Console.Write("{0} inch = {1} cm\n", temp, (temp - 32) / 1.8);
                            break;
                        }
                }

            }
        }
    }
}
