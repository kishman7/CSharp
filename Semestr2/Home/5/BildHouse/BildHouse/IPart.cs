using System;
using System.Collections.Generic;
using System.Text;

namespace BildHouse
{
    interface IPart
    {
        public string Material { get; }
        public char MaterialChar { get; }

        public void Print()
        {
            Console.WriteLine($"Bild {this.GetType().Name} Material: {Material} '{MaterialChar}'");
        }
    }
}
