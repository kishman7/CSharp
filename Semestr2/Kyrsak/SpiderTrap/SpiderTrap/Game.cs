using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpiderTrap
{
    class Game
    {
        public GameFild GameFild { set; get; }
        public Difficulty GameDifficulty { set; get; } = Game.Difficulty.normal;

        public Player Player1 { set; get; }

        List<Spider> Spiders = new();

        public delegate void StopAllThread();
        public StopAllThread StopAllThreads;

        public Game(Difficulty difficulty)
        {
            Console.Clear();
            GameDifficulty = difficulty;

            GameFild = new GameFild(GetFildSize(difficulty)[0], GetFildSize(difficulty)[1]);
            GameFild.GenerateFild();
            
            for (int y = 0; y < GameFild.FildHeight; y++)
                for (int x = 0; x < GameFild.FilddWidth; x++)
                    Print(GameFild.PixelsFild[y][x]);
            
            Player1 = new Player(ConsoleColor.DarkGreen)
            {
                Pixel = GameFild.PixelsFild[GameFild.PixelsFild.Length / 2][1]
            };
            Print(Player1);
            Print(Player1.PrintLives());
            Player1.MovengEvent += Player1_PlayerMoveEvent;
            Player1.PlayerWebActiveEvent += Player1_PlayerWebActiveEvent;
            Player1.PlayerDead += Player1_PlayerDead;
            Player1.StopGame_NotSave += Player1_StopGame_NotSave;
            StopAllThreads += Player1.StopThread;


            int spidersCount = (int)((double)((GetFildSize(GameDifficulty)[0] * GetFildSize(GameDifficulty)[1]) / 100 - 10) * Settings.Setting.MultiplierEnemyUnits);

            for (int i = 0; i < spidersCount; i++)
            {
                Spider spider = new();
                spider.Pixel = GameFild.PixelsFild[GetFildSize(GameDifficulty)[0] / 2][GetFildSize(GameDifficulty)[1] / 2];
                spider.MovengEvent += Spider_MovengEvent;
                spider.SpiderInTrap += Spider_SpiderInTrap;
                StopAllThreads += spider.StopThread;
                spider.ID = i;
                Spiders.Add(spider);
            }
            Spider_SpiderInTrap(null, null); //print lives spiders
        }

        private void Player1_StopGame_NotSave(object sender, EventArgs e)
        {
            AbortThreads();
        }

        public void AbortThreads()
        {
            StopAllThreads.Invoke();
        }

        private void Player1_PlayerDead(object sender, EventArgs e)
        {
            EndGame(false);
        }

        private void Player1_PlayerWebActiveEvent(Player aweb)
        {
            if (!aweb.UserWeb.ActiveWeb)
            {
                aweb.UserWeb.CreateWeb = false;
                CancleUserCelection(aweb);
            }
        }

        static object locker = new object();
        public void Print(IPrint print)
        {
            lock (locker)
            {
                IPrint.PrintData printData = print.Print();
                Console.SetCursorPosition(printData.X+2, printData.Y+2);
                Console.BackgroundColor = printData.BackgroundColor;
                Console.ForegroundColor = printData.TextColor;
                Console.Write(printData.Body);
            }
        }

        private void Player1_PlayerMoveEvent(IMoving playerEv, int y, int x)
        {
            Player player = (Player)playerEv;
            lock (locker)
            {
                if (GameFild.CheckMove(player, y, x))
                {
                    if (player.UserWeb.ActiveWeb == false)
                    {
                        Print(player.Pixel);
                        player.Pixel = GameFild.PixelsFild[y][x];
                    }
                    else
                    {
                        if (player.UserWeb.CreateWeb == false)
                            if (player.Pixel.GetType() == GameFild.PixelsFild[y][x].GetType())
                            {
                                Print(player.Pixel);
                                player.Pixel = GameFild.PixelsFild[y][x];
                            }
                            else
                            {
                                player.UserWeb.CreateWeb = true;
                                Print(player.Pixel);
                                player.Pixel = GameFild.ReplacePixel(GameFild.PixelsFild[y][x], typeof(WebPixel));
                                Print(player.Pixel);
                                player.UserWeb.AddWeb(player.Pixel);
                            }
                        else
                        {
                            if (GameFild.PixelsFild[y][x].GetType() == typeof(UserPixel))
                            {
                                Print(player.Pixel);
                                player.Pixel = GameFild.PixelsFild[y][x];
                                CreateUserCelection(player);

                            }
                            else if (GameFild.PixelsFild[y][x].GetType() == typeof(WebPixel))
                            {
                                
                                CancleUserCelection(player);
                                Print(player.Pixel);
                                player.Pixel = GameFild.PixelsFild[y][x];
                            }
                            else
                            {
                                Print(player.Pixel);
                                player.Pixel = GameFild.ReplacePixel(GameFild.PixelsFild[y][x], typeof(WebPixel));
                                Print(player.Pixel);
                                player.UserWeb.AddWeb(player.Pixel);

                            }
                        }
                    }
                    Print(player);
                }
            }
        }

        void CreateUserCelection(Player player)
        {
            List<CommonPixel> pixelslist = GameFild.GetAllFreePixels();
            List<CommonPixel> resultCommonPixels = new();

            GameFild.HelloNeighbor(pixelslist, resultCommonPixels, GameFild.GetFirstFreePixel());

            if (pixelslist.Count + player.UserWeb.ListWebPixels.Count >= resultCommonPixels.Count + player.UserWeb.ListWebPixels.Count)
                foreach (IPixels pixels1 in resultCommonPixels)
                    Print(GameFild.ReplacePixel(pixels1, typeof(UserPixel)));
            else
                foreach (IPixels pixels1 in pixelslist)
                    Print(GameFild.ReplacePixel(pixels1, typeof(UserPixel)));
            foreach (IPixels pixels1 in player.UserWeb.ListWebPixels)
                Print(GameFild.ReplacePixel(pixels1, typeof(UserPixel)));

            player.UserWeb.CleanList();

            if (GameFild.GetCountFreePixels() < 22)
                EndGame(true);
        }
        void CancleUserCelection(Player player)
        {
            foreach (WebPixel webPixel in player.UserWeb.ListWebPixels)
                Print(GameFild.ReplacePixel(webPixel, typeof(CommonPixel)));
            player.UserWeb.CleanList();
            player.Pixel = GameFild.PixelsFild[player.Pixel.Y][player.Pixel.X];
            Print(player);
        }

        public void RunGame()
        {
            List<Thread> threads = new List<Thread>();
            Thread Player1Thread = new Thread(new ParameterizedThreadStart(Player1.Move));
            Player1Thread.Start(20); // запускаем поток
            Random random = new();
            foreach (Spider spider in Spiders)
            {
                Thread MyThread = new Thread(new ParameterizedThreadStart(spider.Move));
                MyThread.IsBackground = true;
                threads.Add(MyThread);
                Spider.SpiderParameters parameters = new();
                parameters.CheckMoved = GameFild.CheckMove;

               // int minparam = GameDifficulty == Difficulty.easy ? Settings.Setting.MaxSpiderSpeed+ : Settings.Setting.MaxSpiderSpeed;
                parameters.Interval = random.Next(Settings.Setting.MaxSpiderSpeed, Settings.Setting.MinSpiderSpeed);
                MyThread.Start(parameters);
            }

            foreach (Thread thread in threads)
                thread.Join();
            Player1Thread.Join();
        }

        public void EndGame(bool res)
        {
            AbortThreads();

            IPrint.PrintData printData = new()
            {
                BackgroundColor = ConsoleColor.Black,
                TextColor = ConsoleColor.DarkMagenta,
                Body = res == true ? "You Win!!" : "You Lost!!",
                Y = GameFild.PixelsFild.Length / 2
            };
            printData.X = GameFild.PixelsFild[0].Length / 2 - printData.Body.Length / 2;

            Print(printData);
            Console.Beep();
            Console.ReadLine();
        }
        private void Spider_SpiderInTrap(object sender, EventArgs e)
        {  
            if (sender != null) Spiders.Remove((Spider)sender);

            IPrint.PrintData printData = new()
            {
                BackgroundColor = ConsoleColor.Black,
                TextColor = ConsoleColor.DarkMagenta,
                Body = $"Live Spiders: {Spiders.Count}",
                Y = -1
            };
            printData.X = GameFild.PixelsFild[0].Length - printData.Body.Length;
            Print(printData); 

            if (Spiders.Count == 0) EndGame(true);
        }

        private void Spider_MovengEvent(IMoving item, int y, int x)
        {
            Print(item.Pixel);
            IPixels temp = item.Pixel;

            item.Pixel = GameFild.PixelsFild[y][x];
            Print(GameFild.PixelsFild[temp.Y][temp.X]);
            Print(item);

            if (Player1.Pixel == item.Pixel)
            {
                if (Player1.UserWeb.ListWebPixels.Count > 0)
                    CancleUserCelection(Player1);

                Player1.Lives--;
                Print(Player1.PrintLives());

                Player1.Pixel = GameFild.PixelsFild[GameFild.PixelsFild.Length / 2][1];
                Print(Player1);
            }
            else if (Player1.UserWeb.ListWebPixels.IndexOf(item.Pixel) >= 0)
                if (Player1.UserWeb.ListWebPixels.Count > 0)
                {
                    CancleUserCelection(Player1);
                    Player1.Lives--;
                    Print(Player1.PrintLives());
                }
        }

        static int[] GetFildSize(Difficulty difficulty)
        {
            if (difficulty == Difficulty.easy)
                return new int[] { 24, 80 };
            else if (difficulty == Difficulty.hard)
                return new int[] { 45, 150 };
            else
                return new int[] { 30, 120 };
        }
        public enum Difficulty
        {
            easy, normal, hard
        }


        public void DebagConsole(string msg)
        {
            Console.SetCursorPosition(1,GetFildSize(this.GameDifficulty)[0] +2);
         //   Console.WriteLine(msg);
        }
    }
}
