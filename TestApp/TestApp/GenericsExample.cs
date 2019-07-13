using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp
{
    public class GenericsExample
    {
        static void Test()
        {
            int[] array = { 3, 4, 2, 1, 5, 6, 7, 8, 12, 13, 4, 22, 15, 30, 76 };
            string[] sArray = { "a", "v", "c", "t", "g", "k", "l", "t", "w", "t", "c", "c" };

            int[] sortedArray = SelectionSort(array); ;

            Person p1 = new Person() { Age = 10 };
            Person p2 = new Person() { Age = 15 };

            Console.WriteLine(AreEqual(2, 2));
            Console.WriteLine(p1.CompareTo(p2));

            TestList<int> firstIntList = new TestList<int>();
            TestList<int> secondIntList = new TestList<int>();
            TestList<int> resultIntList = new TestList<int>();

            firstIntList.Add(1);
            firstIntList.Add(3);
            firstIntList.Add(5);

            firstIntList.Add(7);
            firstIntList.Add(3);
            firstIntList.Add(1);

            Console.WriteLine(firstIntList.Capacity);
            Console.WriteLine(firstIntList.Count);
            Console.WriteLine(firstIntList[0]);

            resultIntList = firstIntList + secondIntList;

            Console.WriteLine(resultIntList.ToString());
        }

        public static bool AreEqual<T>(T obj1, T obj2) where T : IComparable<T>
        {
            return obj1.CompareTo(obj2) == 0;
        }

        public static T[] SelectionSort<T>(T[] array) where T : IComparable<T>
        {
            for(int i=0; i<array.Length; i++)
            {
                for(int j= i + 1; j < array.Length; j++)
                {
                    if(array[i].CompareTo(array[j]) > 0)
                    {
                        T temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }

            return array;
        }
    }
}
