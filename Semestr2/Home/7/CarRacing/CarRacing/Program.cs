using System;
using System.Threading;

namespace CarRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(); 
          
            foreach(Car car in game.Cars)
                Console.WriteLine($"{car.CarIcon} Max.Speed = {car.MaxSpeed} Driver Coefficient = {car.DriverCoeffRand}");
         
            game.Start(7, 1);
            Console.BufferWidth = 120;

          

            while(!game.GameFinish)
            {
                game.MoveCar();
                Thread.Sleep(200);
            }
        }
    }
}
