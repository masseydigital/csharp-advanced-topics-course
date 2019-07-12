using System;
using System.Collections.Generic;
using System.Linq;

namespace ExtensionMethods
{
    public static class ExtensionMethodExample
    {
        static void Test(string[] args)
        {
            int[] array = { 5, 3, 5, 7, 12, 15, 19, 30, 101, 1, 6, 81 };

            array.Sort(true);
            array.Reverse();

            Console.WriteLine(string.Join(", ", array));
        }
    }

    public static class Extensions
    {
        public static void Sort(this int[] array)
        {
            int temp = 0;

            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        // Bubble Sort
        public static void Sort(this int[] array, bool reverse = false)
        {
            array.Sort();

            if (reverse)
            {
                Array.Reverse(array);
            }
        }

        public static void Reverse(this int[] array)
        {
            Array.Reverse(array);
        }

        public static Distance DistanceTo(this Point p1, Point p2)
        {
            Console.WriteLine($"The distance between P1 and P2 is:" +
                $"\n{p2.X - p1.X} units in the X direction" +
                $"\n{p2.Y - p1.Y} units in the Y direciton");

            return new Distance() { XDistance = p2.X - p1.X, YDistance = p2.Y - p1.Y };
        }
    }
}