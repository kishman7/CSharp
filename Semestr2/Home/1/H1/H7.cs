using System;

namespace H7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of rows->");
            int n = Convert.ToInt32(Console.ReadLine());
          
            int S = 0;
            int i = 1;

            while(i <= n)
            {
                S += i;
                i++;
            }

            Console.WriteLine("Number of grandmothers - {0}", S);

            Console.WriteLine("Enter the number of rows of desks");
            int Kr = Convert.ToInt32(Console.ReadLine()); 
            Console.WriteLine("Enter the number of computers");
            int Sr = Convert.ToInt32(Console.ReadLine());

            if (Kr * Sr < S)
                Console.WriteLine("There was not enough computer in the classroom");
            else
                Console.WriteLine("Vacancies in the classroom {0}", Kr * Sr - S);

            Console.ReadLine();
        }
    }
}
