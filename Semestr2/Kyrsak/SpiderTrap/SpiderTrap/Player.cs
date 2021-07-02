using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpiderTrap
{
    class Player: IMoving
    {
        public ConsoleColor PlayerColor { set; get; } = ConsoleColor.DarkRed;
        public IPixels Pixel { set; get; }
        public string PlayerChar { set; get; } = "X";
        public Web UserWeb { set; get; } = new Web();
        public Type MType { get => typeof(Player); }

        int lives = 3;
        public int Lives 
        { 
            set 
            { 
                lives = value;
                if (lives == 0) PlayerDead(this, null);
            }
            get => lives;
        }

        public bool RunThread { get; set; } = true;
        public void StopThread() => RunThread = false;

        public delegate void PlayerWebActive(Player aweb);
        public event PlayerWebActive PlayerWebActiveEvent;
        public event IMoving.Moveng MovengEvent;
        public event EventHandler PlayerDead; 
        public event EventHandler StopGame_NotSave;
        public Player(ConsoleColor playerColor)
        {
            PlayerColor = playerColor;
        }
     
        public IPrint.PrintData Print()
        {
            return new IPrint.PrintData()
            {
                X = this.Pixel.X,
                Y = this.Pixel.Y,
                TextColor = PlayerColor,
                BackgroundColor = ConsoleColor.White,
                Body = this.PlayerChar
            };
        }
        public IPrint.PrintData PrintLives()
        {
            IPrint.PrintData printData = new IPrint.PrintData()
            {
                BackgroundColor = ConsoleColor.Black,
                TextColor = ConsoleColor.DarkRed,
                Y = -1,
                X = 0,
                Body = "Live: "
            };

            for (int i = 0; i < lives; i++)
                printData.Body += "*";
            printData.Body += "     ";
            return  printData;
        }

        public void Move(object interval)
        {
            while (RunThread)
            {
                Thread.Sleep((int)interval);
                ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);

                switch (consoleKeyInfo.Key)
                {
                    case ConsoleKey.W:
                        {
                            MovengEvent(this, Pixel.Y - 1, Pixel.X);
                            break;
                        }
                    case ConsoleKey.S:
                        {
                            MovengEvent(this, Pixel.Y + 1, Pixel.X);
                            break;
                        }
                    case ConsoleKey.A:
                        {
                            MovengEvent(this, Pixel.Y, Pixel.X - 1);
                            break;
                        }
                    case ConsoleKey.D:
                        {
                            MovengEvent(this, Pixel.Y, Pixel.X + 1);
                            break;
                        }
                    case ConsoleKey.Spacebar:
                        {
                            if (Pixel.GetType() == typeof(UserPixel))
                            {
                                this.UserWeb.ActiveWeb = UserWeb.ActiveWeb == true ? false : true;
                            }
                            else
                                UserWeb.ActiveWeb = false;

                            PlayerWebActiveEvent(this);
                            break;
                        }
                    case ConsoleKey.Escape:
                        {
                            StopGame_NotSave?.Invoke(this, null);
                            break;
                        }
                }
            }
        }

      
        public class Web
        {
            public bool ActiveWeb { set; get; } = false;
            public bool CreateWeb { set; get; } = false;

            public List<IPixels> ListWebPixels = new();

            public void AddWeb(IPixels webPixel) => ListWebPixels.Add(webPixel);
            public void CleanList()
            {
                ListWebPixels.Clear();
                ActiveWeb = CreateWeb = false;
            }
        }
    }
}
