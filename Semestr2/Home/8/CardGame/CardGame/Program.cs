using System;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = 2;
            while (true)
            {
                Console.WriteLine("Enter Players Count (Count % 2 and < 7 ");
                count = int.Parse(Console.ReadLine());
                if (count % 2 == 0 && count > 1 && count < 7)
                    break;
            }
            Game game = new Game();
            game.GenDeck();
            game.CreatePlayers(count);
            game.CardDistribution();

            while(true)
            {
                Player player = game.Move();
                if (player != null)
                {
                    Console.WriteLine($"------ Player{player.PlayerId} Winner!!!-------");
                    break;
                }

                System.Threading.Thread.Sleep(5);
                Console.WriteLine("--------------------------");
            }
        }
    }
}
