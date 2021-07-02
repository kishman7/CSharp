using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpiderTrap
{
    class Spider : IMoving
    {
        public string Body { set; get; } = "X";
        public int ID { set; get; } = 0;
        public IPixels Pixel { get; set; }
        public Type MType => typeof(Spider);
        public ConsoleColor SpiderColor { set; get; } = ConsoleColor.DarkRed; 
        public ConsoleColor SpiderBackgroundColor { set; get; } = ConsoleColor.White;
        public Directions Direction { set; get; } = Directions.DW;
        public bool RunThread { get; set; } = true;
        public void StopThread() => RunThread = false;

        public event IMoving.Moveng MovengEvent;
        public event EventHandler SpiderInTrap;
        public Spider()
        {
        }

        public IPrint.PrintData Print()
        {
            return new IPrint.PrintData()
            {
                X = this.Pixel.X,
                Y = this.Pixel.Y,
                TextColor = SpiderColor,
                BackgroundColor = SpiderColor,
                Body = this.Body
            };
        }
        public void Move(object paramets)
        {
            SpiderParameters spiderParameters = (SpiderParameters)paramets;

            if (spiderParameters.Interval <= 40) SpiderColor =ConsoleColor.Black;
            else if (spiderParameters.Interval > 40 && spiderParameters.Interval <= 80) SpiderColor =  ConsoleColor.DarkMagenta;
            else
                SpiderColor = ConsoleColor.DarkYellow ;


            while (RunThread)
            {
                Thread.Sleep(spiderParameters.Interval);
                
                int y = Pixel.Y;
                int x = Pixel.X;

                switch(Direction)
                {
                    case Directions.LU:
                        {
                            y = Pixel.Y - 1;
                            x = Pixel.X - 1;
                            break;
                        }
                    case Directions.UP:
                        {
                            y = Pixel.Y - 1;
                            break;
                        }
                    case Directions.RU:
                        {
                            y = Pixel.Y - 1;
                            x = Pixel.X + 1;
                            break;
                        }
                    case Directions.LF:
                        {
                            x = Pixel.X - 1;
                            break;
                        }
                    case Directions.RG:
                        {
                            x = Pixel.X + 1;
                            break;
                        }
                    case Directions.LD:
                        {
                            y = Pixel.Y + 1;
                            x = Pixel.X - 1;
                            break;
                        }
                    case Directions.DW:
                        {
                            y = Pixel.Y + 1;
                            break;
                        }
                    case Directions.RD:
                        {
                            y = Pixel.Y + 1;
                            x = Pixel.X + 1;
                            break;
                        }
                }

                if (spiderParameters.CheckMoved.Invoke(this, y, x))
                    MovengEvent(this, y, x);
                else
                {
                    List<int[]> allP = Pixel.GetNeighborsIndex();
                    List<int[]> alp = new();

                    foreach (int[] vs in allP)
                        if (spiderParameters.CheckMoved.Invoke(this, vs[0], vs[1]))
                            alp.Add(vs);

                    if (alp.Count == 0) 
                    {
                        SpiderInTrap(this, null);
                        return;
                    }

                    Random random = new();

                    int[] item = alp[random.Next(0, alp.Count)];

                    MovengEvent(this, item[0], item[1]);

                    Directions[] Direction1 = (Directions[])Enum.GetValues(typeof(Directions));

                    int t = allP.IndexOf(item);
                    Direction = Direction1[t];
                
                }
            }
        }

        public enum Directions
        {
           LU=0, UP, RU,
             LF,     RG,
             LD, DW, RD
        }

        public class SpiderParameters
        {
            public int Interval { set; get; } = 50;
            public delegate bool CheckMove(IMoving moving, int newY, int newX);
            public CheckMove CheckMoved;
        }
    }
}
