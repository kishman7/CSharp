using System;
using System.Collections.Generic;
using System.Text;

namespace Unit
{
    public class Swordsman : Unit
    {
        public override Type TypeUnit { get => this.GetType(); }
        public Swordsman() : base()
        {
            Hp = 15;
            Damage = 5;
            Dodge = 60;
        }
    }
    public class Archer : Unit
    {
        public override Type TypeUnit { get => this.GetType(); }
        public Archer() : base()
        {
            Hp = 12;
            Damage = 4;
            Dodge = 40;
        }
    }
    public class Mage : Unit
    {
        public override Type TypeUnit { get => this.GetType(); }
        public Mage() : base()
        {
            Hp = 8;
            Damage = 10;
            Dodge = 30;
        }
    }
}
