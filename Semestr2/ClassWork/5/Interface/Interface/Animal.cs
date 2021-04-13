using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
   abstract public class Animal : IWalk, IEat, ISleep
    {
        public string AType { get; set; }
        public Animal(string animal) { AType = animal; }
        public void Eat()
        {
            Console.WriteLine($"{AType} is Eat!");
        }

        public void Sleep()
        {
            Console.WriteLine($"{AType} is Sleep!");
        }

        public void Walk()
        {
            Console.WriteLine($"{AType} is Walk!");
        }
    }
}
