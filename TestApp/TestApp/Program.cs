using System;
using ExtensionMethods;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Point pointOne = new Point(20, 30);
            Point pointTwo = new Point(10, 15);

            Distance distance = pointOne.DistanceTo(pointTwo);

            Console.WriteLine(distance.XDistance);
        }
    }
}
