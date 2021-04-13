using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
   public class VideoCamera : IWatch
    {
        int cameraId = 0;
        static int cameraCount = 0;
        public int Camera { get => cameraId; }
        public VideoCamera() { cameraId= cameraCount++; }
        public void Watch()
        {
            Console.WriteLine($"Camera {cameraId} watch!");
        }
        public void Watch(Animal animal)
        {
            Console.WriteLine($"Camera {cameraId} watch whis {animal.AType}!");
        }

        public void Watch(VideoCamera camera)
        {
            throw new NotImplementedException();
        }
    }
}
