using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpiderTrap
{
    public interface IPixels : IPrint
    {
        public int X { set; get; }
        public int Y { set; get; }
        public ConsoleColor PixelTextColor { set; get; }
        public ConsoleColor PixelBackgroundColor { set; get; }
        public Сollisions Сollision { set; get; }
        public string Body { set; get; }
       
        public List<int[]> GetNeighborsIndex();
        public enum Сollisions
        {
            None, OnlyUser, Impassable
        }
    }

    public abstract class AbstractPixels
    {
        public int X { set; get; }
        public int Y { set; get; }
        public string Body { set; get; } = " ";
        public ConsoleColor PixelTextColor { set; get; } = ConsoleColor.Red;
        public ConsoleColor PixelBackgroundColor { set; get; }
        public IPixels.Сollisions Сollision { set; get; } = IPixels.Сollisions.None;

        public AbstractPixels(int x, int y)
        {
            X = x;
            Y = y;    
        } 
        public List<int[]> GetNeighborsIndex()
        {
            List<int[]> vs = new();
            for (int i = Y - 1; i <= Y + 1; i++)
                for (int t = X - 1; t <= X + 1; t++)
                    vs.Add(new int[] { i, t });

            vs.RemoveAt(4);
            return vs;
        }

        public IPrint.PrintData Print()
        {
            return new IPrint.PrintData()
            {
                X = this.X,
                Y= this.Y,
                TextColor = PixelTextColor,
                BackgroundColor = PixelBackgroundColor,
                Body = this.Body
            };
        }
    }

    public class BorderPixel : AbstractPixels, IPixels
    {
        public BorderPixel(int x, int y) : base(x, y)
        {
            PixelBackgroundColor = PixelTextColor = ConsoleColor.DarkBlue;
            Сollision = IPixels.Сollisions.Impassable;
          
            List<AbstractPixels> AbstractPixelsu = new();
            AbstractPixelsu.Add(this);
        }

        public static void BildBorder(IPixels[][] PixelsFild)
        {
            for (int h = 0; h < PixelsFild.Length; h++)
            {
                if (h == 0 || h == PixelsFild.Length-1)
                    for (int w = 0; w < PixelsFild[h].Length; w++)
                    {
                        PixelsFild[h][w] = new BorderPixel(w,h);
                    }
                else
                {
                    PixelsFild[h][0] = new BorderPixel(0, h);
                    PixelsFild[h][^1] = new BorderPixel(PixelsFild[h].Length - 1, h);
                }
            }
        }
    }

    public class UserPixel : AbstractPixels, IPixels
    {
        public UserPixel(int x, int y) : base(x, y)
        {
            PixelBackgroundColor = PixelTextColor = ConsoleColor.Green;
            Сollision = IPixels.Сollisions.OnlyUser;
        }
        public static void BildUserPixel(IPixels[][] PixelsFild)
        {
            for (int h = 1; h < PixelsFild.Length - 1; h++)
            {
                if (h == 1 || h == PixelsFild.Length - 2)
                    for (int w = 1; w < PixelsFild[h].Length-1; w++)
                    {
                        PixelsFild[h][w] = new UserPixel(w, h);
                    }
                else
                {
                    PixelsFild[h][1] = new UserPixel( 1, h);
                    PixelsFild[h][^2] = new UserPixel(PixelsFild[h].Length - 2, h);
                }
            }
        }
    }

    public class CommonPixel : AbstractPixels, IPixels
    {
        public CommonPixel(int x, int y) : base(x, y)
        {
            PixelBackgroundColor = PixelTextColor = ConsoleColor.DarkGray;
            Сollision = IPixels.Сollisions.None;
        }
        public static void BildCommonPixel(IPixels[][] PixelsFild)
        {
            for (int h = 2; h < PixelsFild.Length - 2; h++)
            {
                for (int w = 2; w < PixelsFild[h].Length - 2; w++)
                {
                    PixelsFild[h][w] = new CommonPixel(w, h);
                }
            }
        }
     }
    public class WebPixel : AbstractPixels, IPixels
    {
        public WebPixel(int x, int y) : base(x, y)
        {
            PixelTextColor = ConsoleColor.White;
            PixelBackgroundColor = ConsoleColor.DarkGray;
           Сollision = IPixels.Сollisions.None;
            Body = "*";
        }
    }
}


