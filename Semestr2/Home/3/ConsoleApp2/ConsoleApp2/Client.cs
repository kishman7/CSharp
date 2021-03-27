using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    class Client
    {
        string Name { get; set; }

        string telephone;
        string Telephone  { get; set; }

       public Client(string name, string telephone) 
        {
            Name = name;
            Telephone = telephone;
        }

        public override string ToString()
        {
            return $"Client: {Name} Telephone: {Telephone}";
        }
    }
}
