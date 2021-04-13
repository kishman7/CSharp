using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    interface IWatch
    {
        void Watch(); 
        void Watch(Animal animal);
        void Watch(VideoCamera camera);
    }
}
