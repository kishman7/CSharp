using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    public class ZooWorker : IWatch
    {
       static int workerCount = 0;
       int workerId = 0;
        public ZooWorker() { workerId = workerCount++; }

        public void FeedAnimal(Animal animal)
        {
            Console.WriteLine($"Worker #{workerId} feed animal");
            animal.Eat();
        }

        public void Watch()
        {
            Console.WriteLine($"Worker {workerId} watch!");
        }
        public void Watch(Animal animal)
        {
            Console.WriteLine($"Worker {workerId} watch whis {animal.AType}!");
        }
        public void Watch(VideoCamera camera)
        {
            Console.WriteLine($"Worker {workerId} watch whis camera {camera.Camera}!");
        }
    }
}
