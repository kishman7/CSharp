using System;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mas = { 1,  2, -4, -55, -7, 10, 100 };
            Print(mas);

            int[] matchedItemsMinus = Array.FindAll(mas, x => x < 0);
            int[] matchedItemsPlus = Array.FindAll(mas, x => x >= 0);

            int[] result = new int[mas.Length];
            matchedItemsMinus.CopyTo(result, 0);
            matchedItemsPlus.CopyTo(result, matchedItemsMinus.Length);

            Print(result);
        }


        static void Print(int[] mas)
        {
            foreach (int i in mas)
                Console.Write(i + " ");
            Console.Write('\n');
        }
    }
}
