using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpiderTrap
{
    [Serializable]
    public class Settings
    { 
       static XmlSerializer serializer = new XmlSerializer(typeof(Settings));

        static Settings setting = null;
        public static Settings Setting { set => setting = value;
            get 
            {
                if (setting == null)
                    setting = DeSerializeSettings();
                return setting;
            }
                }

        public static Settings DeSerializeSettings()
        {
            if (File.Exists(Environment.CurrentDirectory + "\\settings.xml"))
                using (FileStream ms = new FileStream("settings.xml", FileMode.OpenOrCreate))
                {
                    return (Settings)serializer.Deserialize(ms);
                }
            return new Settings();
        }

        public int MinSpiderSpeed { set; get; } = 100;
        public int MaxSpiderSpeed { set; get; } = 25;
        public double MultiplierEnemyUnits { set; get; } = 1;
        static string tem = "                            ";
        public void Print()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.SetCursorPosition(1, 1);
            Console.WriteLine($"     {tem}Settings{tem}    ");
           
            List(); 
        }

        void List()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            SettingMenu main = new(new List<string>
            {
              $"Min Spider Speed          (Delay) {tem}- {MinSpiderSpeed}",
              $"Max Spider Speed          (Delay){tem} - {MaxSpiderSpeed}", 
              $"Multiplier of enemy units (1=100){tem} - {MultiplierEnemyUnits}",
              $"Save",
              $"Exit"
            }, 3, 3);
            main.TextConsoleColor = ConsoleColor.White;
            main.SelctedTextConsoleColor = ConsoleColor.Blue;

           switch(main.Show())
            {
                case 0:
                    {
                        MinSpiderSpeed = int.Parse((string)main.EnterData);
                        break;
                    }
                case 1:
                    {
                        MaxSpiderSpeed = int.Parse((string)main.EnterData);
                        break;
                    }
                case 2:
                    {
                        MultiplierEnemyUnits = double.Parse(((string)main.EnterData).Replace('.', ','));
                        break;
                    }
                case 3:
                    {
                        using (FileStream ms = new FileStream("settings.xml", FileMode.OpenOrCreate))
                        {
                            serializer.Serialize(ms, this);
                        }
                        return;
                    }
                case 4:
                    {
                        return;
                    }
            }

            Print();
        }

        class SettingMenu: Menu.Main
        {
            public SettingMenu(List<string> vs, int x, int y) : base(vs, x, y) { }
            public object EnterData { set; get; }
            public new int Show()
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
                                if (selector < listMenu.Count - 1)
                                    selector++;
                                break;
                            }
                        case ConsoleKey.Enter:
                            {
                                if (selector == listMenu.Count - 1 || selector == listMenu.Count - 2) return selector;
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                Console.CursorLeft = Xstart + 45;
                                Console.Write("                        ");
                                Console.CursorLeft = Xstart + 45;
                                EnterData = Console.ReadLine();
                                return selector;
                            }
                    }
                    Print(true);
                }
            }

        }
    }
}
