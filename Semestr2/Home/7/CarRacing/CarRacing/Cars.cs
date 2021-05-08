using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing
{
    class SportCar : Car
    {        
        public override string CarIcon => "o>o>";
        public override double MaxSpeed { get;} = 240;

    }
    class TrackCar : Car
    {
        public override string CarIcon => "[O]o";
        public override double MaxSpeed { get; } = 130;
    }
    class HomeCar : Car
    {
        public override string CarIcon => "o*o>";
        public override double MaxSpeed { get; } = 220;
    }
    class BusCar : Car
    {
        public override string CarIcon => "[OO]";
        public override double MaxSpeed { get; } = 90;
    }

}
