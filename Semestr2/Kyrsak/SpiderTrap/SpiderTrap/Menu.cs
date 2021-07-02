using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpiderTrap
{
    public class Menu
    {
        public static string[] Logovs = new string[]
        {
            "   #####    #######    ##   #####      ########   ###### ",
            " ##    ##   ##    ##   ##   ##   ##    ##         ##   ##",
            " ##         ##    ##   ##   ##    ##   ##         ##   ##",
            "  #####     ######     ##   ##    ##   #######    #####  ",
            "      ##    ##         ##   ##    ##   ##         ## ##  ",
            "##    ##    ##         ##   ##   ##    ##         ##  ## ",
            " #####      ##         ##   #####      ########   ##   ##"
        };

        public static string[] Logo = new string[]
        {
                                                                       "##########  ######        ##    ####### ",
                                                                       "    ##      ##   ##      ###    ##    ##",
                                                                       "    ##      ##   ##     ## ##   ##    ##",
                                                                       "    ##      #####      ##  ##   ####### ",
                                                                       "    ##      ## ##      ######   ##      ",
                                                                       "    ##      ##  ##    ##    ##  ##      ",
                                                                       "    ##      ##   ##  ##     ##  ##      "
        };

        public static void PrintLMsg()
        {
            Console.SetCursorPosition(20, 20);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Now it is recommended to manually expand the window! Press button... ");
            Console.ReadKey(true);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.SetCursorPosition(20, 20);
            Console.WriteLine("Now it is recommended to manually expand the window! Press button... ");
        }

        public static void PrintStartLogo()
        {
            Menu.PrintLogo(Menu.Logovs, 1, 2);
            Menu.PrintLogo(Menu.Logo, 10, 5);
            Console.BackgroundColor =ConsoleColor.Black;
        }

        public static void PrintLogo(string[] vs, int y, int x)
        {
            Console.BackgroundColor = ConsoleColor.Yellow; 
            Console.ForegroundColor = ConsoleColor.Yellow;

            for (int t = 0; t < vs.Length; t++)
            {
                Console.CursorTop = y++;

                for (int i = 0; i < vs[t].Length; i++)
                {
                    if (vs[t][i] == '#')
                    {
                        Console.CursorLeft = x + i;
                        Console.Write(vs[t][i]);
                    }
                }
            }
        }

        public static bool ShowMain()
        {
            Main main = new(new List<string> {"Start Game", "Settings", "Exit" }, 60, 12);
           switch( main.Show())
            {
                case 0:
                    {
                        main.Hide();
                        Main main1 = new Main(new List<string>() { "Easy", "Normal", "Hard", "Back" }, 60, 12);
                       int res = main1.Show();
                        if (res == 3)
                        {
                            main1.Hide();
                            ShowMain(); 
                        }
                        else
                        {
                            Game game = new((Game.Difficulty)Enum.ToObject(typeof(Game.Difficulty), res));
                            game.RunGame();
                        }
                        break;
                    }
                case 1:
                    {
                        Settings.Setting.Print();
                        break;
                    }
                case 2:
                    {
                        return false;
                    }
            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();
            return true;
        }

        public class Main
        {
            public List<string> listMenu = new();
            public int Xstart { set; get; } = 0;
            public int Ystart { set; get; } = 0;
            public ConsoleColor TextConsoleColor { set; get; } = ConsoleColor.Gray;
            public ConsoleColor SelctedTextConsoleColor { set; get; } = ConsoleColor.DarkYellow;
            public int selector = 0;

            public Main(List<string> vs, int x, int y)
            {
                Xstart = x;
                Ystart = y;
                listMenu = vs;
            }
            public  int Show()
            {
                foreach (string item in listMenu)
                {
                    selector = listMenu.IndexOf(item);
                    Print(false);
                }
                selector = 0;
                Print(true);

                while (true)
                {
                    Thread.Sleep(100);
                    ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
                  
                    Print(false);
                    switch (consoleKeyInfo.Key)
                    {
                        case ConsoleKey.W:
                            {
                                if (selector > 0)
                                    selector--;
                                break;
                            }
                        case ConsoleKey.S:
                            {
                                if (selector < listMenu.Count-1)
                                    selector++;
                                break;
                            }
                        case ConsoleKey.Enter:
                            {
                                return selector;
                            }
                    }
                    Print(true);
                }
            }

            public void Print(bool sel)
            {
                Console.SetCursorPosition(Xstart, Ystart + selector);
                Console.ForegroundColor = sel == true ?SelctedTextConsoleColor : TextConsoleColor;
                Console.Write(listMenu[selector]);
            }

            public void Hide()
            {
                ConsoleColor temp = TextConsoleColor;
                TextConsoleColor = ConsoleColor.Black;
                foreach (string item in listMenu)
                {
                    selector = listMenu.IndexOf(item);
                    Print(false);
                }
                selector = 0;
                TextConsoleColor = temp;
            }
        }
    }
}
