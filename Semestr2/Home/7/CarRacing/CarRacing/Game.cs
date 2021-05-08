using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing
{
    class Game
    {
        public List<Car> Cars = null;
        public delegate void AllStart(int y, int x);
        public AllStart AllStartCar; 
        public delegate void Move(double[] Track);
        public Move AllMove;
        public bool GameFinish = false;
        readonly double[] Track;
        public Game()
        {
            Track = GenerateTrack(100);

            Cars = new List<Car>
            {
                new SportCar(),  
                new SportCar(),
                new TrackCar(),
                new HomeCar(),
                new BusCar(),
                new BusCar()
            };

            foreach (Car c in Cars)
            {
                c.FinishEvent += Finish;
                AllStartCar += c.OnStart;
                AllMove += c.Move;
            }
        }
        public void Start(int y, int x)
        {
            foreach (var f in AllStartCar.GetInvocationList())
            {
                f.DynamicInvoke(y += 2, x);
            }
        }

        public bool MoveCar()
        {
            AllMove.Invoke(Track);
            return GameFinish;
        }

        public void Finish(Car car)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(25, 30);
            Console.WriteLine(car.CarIcon + " WIN!!!");
            Console.ForegroundColor = ConsoleColor.White;
            GameFinish = true;
        }

        public double[] GenerateTrack(int size)
        {
            Random random = new Random();

            double[] track = new double[size];

            double step = 1 / (size / 2);
            for(int i =0; i< size; i++)
            {
                if (i < size / 2)
                {
                    step += 1.5 / ((double)size / 2);
                    track[i] = step; }
                else
                    track[i] = 1.0 + (random.NextDouble() * (0.2 - (-0.2))) + -0.2;
            }
            return track;
        }
    }
}
