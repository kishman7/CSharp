using System;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mas1 = { 1, 2, 3, 4, 5 }; 
            int[] mas2 = { 5, 3, 8, 9, 10 };

            Console.WriteLine("Print mas");
            Print(mas1); 
            Print(mas2);

            Console.WriteLine("Print AssociationMas");
            Print(AssociationMas(mas1, mas2));
            Console.WriteLine("Print СommonMas");
            Print(СommonMas(mas1, mas2));
            Console.WriteLine("Print ExclusionMas");
            Print(ExclusionMas(mas1, mas2));
        }

        static int[] AssociationMas(int[] mas1, int[] mas2)
        {
            int[] mas3 = new int[mas1.Length + mas2.Length];
            mas1.CopyTo(mas3, 0);
            mas2.CopyTo(mas3, mas1.Length);
            return mas3;
        }
        static int[] СommonMas(int[] mas1, int[] mas2)
        {
            int[] mas3 = new int[0];

            foreach (int i in mas1)
                if (Array.IndexOf(mas2, i) != -1)
                    if (Array.IndexOf(mas3, i) == -1)
                        {
                            Array.Resize(ref mas3, mas3.Length + 1);
                            mas3[mas3.Length - 1] = i;
                        }
            return mas3;
        }
        static int[] ExclusionMas(int[] mas1, int[] mas2)
        {
            int[] mas3 = new int[0];

            foreach (int i in mas1)
            {
                if (Array.IndexOf(mas2, i) == -1)
                {
                    Array.Resize(ref mas3, mas3.Length + 1);
                    mas3[mas3.Length - 1] = i;
                }
            }
            return mas3;
        }

        static void Print(int[] mas)
        {
            foreach (int i in mas)
                Console.Write(i + " ");
            Console.Write('\n');
        }

    }
}
