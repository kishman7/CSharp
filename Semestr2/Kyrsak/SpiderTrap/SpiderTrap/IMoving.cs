using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiderTrap
{
    interface IMoving: IPrint
    {
        public IPixels Pixel { set; get; }
        public Type MType { get; }
        public bool RunThread { set; get; }
        public void StopThread();

        public void Move(object interval);
     

        public delegate void Moveng(IMoving item, int y, int x);
        public event Moveng MovengEvent;
    }
}
