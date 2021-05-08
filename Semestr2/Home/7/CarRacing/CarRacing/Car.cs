using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing
{
    abstract class Car
    {
        public abstract string CarIcon { get; }
        public delegate void Finish(Car car);
        public event Finish FinishEvent;
        public double DriverCoeffRand = 1; //Навики водіння водія(випадковий вибір) добавить шансів повільним машинам

        int X { set; get; } = 0; 
        int Y { set; get; } = 0;

        double speed = 1;
        public double Speed 
        { 
            set => speed = value > MaxSpeed ? MaxSpeed : value;
            get => speed;
        }
        const int speedCoefficient = 100; //для емуляції тривалої гонки speed/speedCoefficient
        public abstract double MaxSpeed { get; }

        double distanse = 1;
        public double Distance
        {
            set 
            { 
                distanse = value;
                if (value >= 100)
                    FinishEvent(this);
            }
            get => distanse;
        }

        public Car()
        {
            Random random = new Random();
            DriverCoeffRand= random.Next(10, 20);
        }

        public void Move(double[] Track)
        {
            SpeedCorrection(Track[(int)Distance]);

            Distance += Speed / speedCoefficient;
            Print();
        }
        void SpeedCorrection(double correct)
        {
            Speed = Speed + (DriverCoeffRand * correct);
            if (Speed >= MaxSpeed)
                Speed *= correct;
        }
        public void OnStart(int y, int x)
        {
            this.X = x;
            this.Y = y;
            Console.SetCursorPosition(x, y);
            Console.Write(CarIcon);
        }
        public void Print()
        {
            try
            {
                Console.SetCursorPosition(X, Y);
                Console.Write("....................................................................................................");


                Console.SetCursorPosition(X, Y-1);
                Console.Write("                                                                                                    ");
               
                Console.SetCursorPosition(X + (int)Distance - 1, Y - 1);
                Console.Write($"{Math.Round(Speed, 2)} km/h");

                Console.SetCursorPosition(X + (int)Distance, Y);
                Console.Write(CarIcon);
            }
            catch { }
        }

    }
}
