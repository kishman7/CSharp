using System;

namespace Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            Zoo.animals.Add(new Bear());
            Zoo.animals.Add(new Rebit()); 
            Zoo.animals.Add(new Hourse());

            for (int i = 0; i < 10; i++)
                Zoo.zooWorkers.Add(new ZooWorker());

            for (int i = 0; i < 15; i++)
                Zoo.videoCameras.Add(new VideoCamera());

            while(true)
            {
                ShowAnimal();
                ShowWorker();
                Console.ReadLine();
            }

        }
       static Random rand = new Random();
        static void ShowAnimal()
        {
            Animal animal = Zoo.animals[rand.Next(0, Zoo.animals.Count)];

            int i = rand.Next(0, 3);
            if (i == 0)
                animal.Eat();
            else if (i == 1)
                animal.Sleep();
            else
                animal.Walk();
        }

        static void ShowWorker()
        {
            ZooWorker zooWorker = Zoo.zooWorkers[rand.Next(0, Zoo.zooWorkers.Count)];

            int t = rand.Next(0,2);

            if (t == 0)
            {
                int i = rand.Next(0, 3);
                if (i == 0)
                    zooWorker.Watch(Zoo.animals[rand.Next(0, Zoo.animals.Count)]);
                else if (i == 1)
                    zooWorker.Watch(Zoo.videoCameras[rand.Next(0, Zoo.videoCameras.Count)]);
                else
                    zooWorker.Watch();
            }
            else
                zooWorker.FeedAnimal(Zoo.animals[rand.Next(0, Zoo.animals.Count)]);
        }
    }
}