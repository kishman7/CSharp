using System;
using System.Collections.Generic;
using System.Text;

namespace BildHouse
{
    class Worker : IWorker
    {
        public House House {set; get;}

        public void Working()
        {
            if (Audit(typeof(Basement), 1))
                House.partsHouse.Add(new Basement());
            else if (Audit(typeof(Walls), 4))
                House.partsHouse.Add(new Walls());
            else if (Audit(typeof(Door), 1))
                House.partsHouse.Add(new Door());
            else if (Audit(typeof(Window), 4))
                House.partsHouse.Add(new Window());
            else if (Audit(typeof(Roof), 1))
                House.partsHouse.Add(new Roof());
            else
                House.Finality = false;
        }

        bool Audit( Type type, int count)//перевірка що вже збудовано
        {
            int c = 0;
            foreach (IPart part in House.partsHouse)
                if (part.GetType().Equals(type))
                    c++;
            if (c < count)
                return true;

            return false;
        }

    }
}
