using System;
using System.Collections;
using System.Collections.Generic;

namespace BildHouse
{
    class Program
    {
        static void Main(string[] args)
        {
            House house = TeamLeader.CreateProgect();

            List<IWorker> Team = new List<IWorker>
            {
                new Worker{House = house },
                new Worker{House = house },
                new TeamLeader{House = house},
                new Worker{House = house },
            };

            IEnumerator enumerator = Team.GetEnumerator();

            while (house.Finality)
            {
                if (!enumerator.MoveNext())
                {
                    enumerator.Reset();
                    enumerator.MoveNext();
                }
                (enumerator.Current as IWorker).Working();
            }

            Console.WriteLine("Press to Show Bilding....");
            Console.ReadKey();
            Console.Clear();
            house.BildHouse();
        }
    }
}
