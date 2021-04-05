using System;
using System.Collections.Generic;
using System.Text;

namespace Unit
{
    public abstract class Unit
    {
        public int Hp { set; get; } = 0;
        public int Damage { set; get; } = 0;
        public int Dodge { set; get; } = 0;
        public abstract Type TypeUnit {get;}
        public int Attack(Unit unit)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Unit {TypeUnit.Name} attacks {unit.TypeUnit.Name} ({unit.Hp}hp)");
            Console.ForegroundColor = ConsoleColor.White;

            Random rand = new Random();
            if (rand.Next(0, 100) > unit.Dodge)
            {
                unit.Hp -= Damage;
                int life = unit.Hp >= 0 ? unit.Hp : 0;
                Console.WriteLine($"     {unit.TypeUnit.Name} ({life}hp), takes {Damage} damage");
                if (life <= 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine($"{unit.TypeUnit.Name} dead!\n");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine($"Unit {unit.TypeUnit.Name} evades!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            return unit.Hp;
        }
    }
}
