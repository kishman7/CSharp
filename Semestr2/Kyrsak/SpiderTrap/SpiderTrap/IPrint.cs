using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiderTrap
{
    public interface IPrint
    {
        public PrintData Print();

        public class PrintData : IPrint
        {
            public int Y { set; get; }
            public int X { set; get; }
            public ConsoleColor TextColor { set; get; }
            public ConsoleColor BackgroundColor { set; get; }
            public string Body { set; get; }

            public PrintData Print()
            {
                return this;
            }
        }
    }
}
