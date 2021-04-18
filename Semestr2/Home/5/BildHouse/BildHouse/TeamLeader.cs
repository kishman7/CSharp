using System;
using System.Collections.Generic;
using System.Text;

namespace BildHouse
{
    class TeamLeader : IWorker
    {
        public House House { get; set; }

        public static House CreateProgect()
        {
            Basement.MaterialStyle = RandomEnumValue<Basement.Style>();
            Walls.MaterialStyle = RandomEnumValue<Walls.Style>();
            Door.MaterialStyle = RandomEnumValue<Door.Style>();
            Window.MaterialStyle = RandomEnumValue<Window.Style>();
            Roof.MaterialStyle = RandomEnumValue<Roof.Style>();
            return new House();
        }

        public static T RandomEnumValue<T>()
        {
            Random random = new Random();
            Array values = (typeof(T)).GetEnumValues();
            return (T)values.GetValue(random.Next(values.Length));
        }

        public void Working()
        {
            foreach (IPart part in House.partsHouse)
                part.Print();

            Console.WriteLine($"Progress at the moment ({ 1 + (100 / 11) * House.partsHouse.Count}%)");
            //Console.ReadKey();
            //Console.Clear();
        }
    }
}
