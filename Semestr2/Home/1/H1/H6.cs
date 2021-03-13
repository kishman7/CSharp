using System;

namespace H6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Elevator");
            Console.WriteLine("Enter maximum weight->");
            double S = Convert.ToDouble(Console.ReadLine());

            int count = 0;
            double mas = 0;
            while(true)
            {
                Console.WriteLine("Enter the weight of the new passenger");
                count++;
                mas += Convert.ToDouble(Console.ReadLine());
                if(mas > S)
                {
                    Console.WriteLine("The passenger will suffer №{0}", count);
                    break;
                }
            }
            Console.ReadLine();
        }
    }
}
