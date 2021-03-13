using System;

namespace H5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bancomat");
            int a = 1;
            while (Convert.ToBoolean(a))
            {
                Console.WriteLine("Enter password:");
                a = Convert.ToInt32(Console.ReadLine());

                if (a == 12345)
                   {
 		       Console.WriteLine("1. Current balance\n2. Take off money\n0. Exit");
        	       Console.ReadLine();
		   }
                else
                    Console.WriteLine("Password error\nEnter password:");

            }
        }
    }
}
