using System;
using System.Collections.Generic;
using System.Text;

namespace Unit
{
    class Teams
    {
        List<Unit> units = new List<Unit>();
        Unit enumerator;
        
        public int GetCount { get => units.Count; }
        public Teams(int count = 3)
        {
            for (int i = 0; i < 3; i++)
            {
                Random rand = new Random();
                int r = rand.Next(0, 3);
                if (r == 0)
                    units.Add(new Swordsman());
                else if (r == 1)
                    units.Add(new Archer());
                else
                    units.Add(new Mage());
            }
        }
        public Unit GetUnit(Type type)
        {
            foreach (Unit unit in units)
                if (unit.TypeUnit == type)
                    return unit;
            return units[0];
        }
        public void DeadUnit(Unit unit)
        {
            enumerator = unit == units[units.Count - 1] ? units[0] : units[units.IndexOf(unit) + 1];

            units.Remove(unit);
        }
        public void Attacking(Teams teams)
        {
            if (units.Count == 0) return;
            enumerator = units.IndexOf(enumerator) == units.Count - 1 ? units[0] : units[units.IndexOf(enumerator) + 1];
            Unit ret = enumerator;

            Unit victim = teams.GetUnit(ret.TypeUnit);
            ret.Attack(victim);
            if (victim.Hp <= 0)
                teams.DeadUnit(victim);
        }
    }
}
