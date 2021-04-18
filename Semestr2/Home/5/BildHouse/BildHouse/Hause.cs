using System;
using System.Collections.Generic;
using System.Text;

namespace BildHouse
{
    class House
    {
        public List<IPart> partsHouse = new List<IPart>();
        public bool Finality = true;

        public void BildHouse()
        {
            BildBasement();
            System.Threading.Thread.Sleep(400);
            BildWalls(); 
            System.Threading.Thread.Sleep(400);
            BildDoor(); 
            System.Threading.Thread.Sleep(400);
            BildWindow(); 
            System.Threading.Thread.Sleep(400);
            BildRoof();   
            
            Console.CursorTop = 0;
            Console.WriteLine("The house is built!");

            Console.CursorTop = 25;
        }
    
        void BildBasement()
        {
            for (int y = 20; y > 19; y--)
            {
                Console.CursorTop = y;
                Console.CursorLeft = 4;
                for (int x = 0; x < 30; x++)
                    Console.Write((Char)Basement.MaterialStyle.GetHashCode());
            }
        }
        void BildWalls()
        {
            for(int y = 19; y > 9; y--)
            {
                Console.CursorTop = y;
                Console.CursorLeft = 4;
                Console.Write((Char)Walls.MaterialStyle.GetHashCode()); 
                Console.CursorLeft = 33;
                Console.Write((Char)Walls.MaterialStyle.GetHashCode());
            }
        }
        void BildDoor()
        {
            for (int y = 19; y > 12; y--)
            {
                Console.CursorTop = y;
                Console.CursorLeft = 26;
                for (int x = 0; x < 5; x++)
                    Console.Write((Char)Door.MaterialStyle.GetHashCode());
            }
        }
        void BildWindow()
        {
            for (int y = 12; y < 16; y++)
            {
                Console.CursorTop = y;
                Console.CursorLeft = 7;
                for (int x = 0; x < 6; x++)
                    Console.Write((Char)Window.MaterialStyle.GetHashCode());
            }
        }
        void BildRoof()
        {
            int rx1 = 0;
            int rx2 = 37;
            for (int y = 9; y > 0; y--)
            {
                Console.CursorTop = y;
                Console.CursorLeft = rx1 += 2;
                Console.Write((Char)Roof.MaterialStyle.GetHashCode());
                Console.CursorLeft = rx2 -= 2;
                Console.Write((Char)Roof.MaterialStyle.GetHashCode());
            }
            Console.CursorTop = 9;
            Console.CursorLeft = 3;
            for (int i = 0; i < 32; i++)
                Console.Write((Char)Roof.MaterialStyle.GetHashCode());
        }
    }
}
