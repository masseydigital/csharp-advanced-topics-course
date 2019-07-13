using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp
{
    public class DelegatesExample
    {
        public delegate bool Filters(string item);

        public static void Test()
        {
            string[] names = { "Alice", "John", "Bob", "Kyle", "Scott", "Todd", "George", "Sharon", "Kobe", "Becky" };

            // The first inputs (up to 16) are the input types and the last type is the output type
            Func<string, bool> lessThanFive = LessThanFive;

            List<string> lessThanFiveChars = NamesFilter(names, item => item.Length < 5);       //using a lambda expression
            List<string> greaterThanFiveChars = NamesFilter(names, MoreThanFive);               //using delegates
            List<string> lessThanFiveFunc = NamesFilter(names, lessThanFive);                   //using funcs

            Console.WriteLine(string.Join(", ", lessThanFiveChars));
        }

        public static bool LessThanFive(string name)
        {
            return name.Length < 5;
        }

        public static bool MoreThanFive(string name)
        {
            return name.Length > 5;
        }

        public static bool ExactlyFive(string name)
        {
            return name.Length == 5;
        }

        public static List<string> NamesFilter(string[] items, Func<string, bool> filter)
        {
            List<string> result = new List<string>();

            foreach (var item in items)
            {
                if (filter(item))
                {
                    result.Add(item);
                }
            }

            return result;
        }
    }
}
