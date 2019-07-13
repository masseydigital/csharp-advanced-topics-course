using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp
{
    public class AnonymousMethodsExample
    {
        public static void Test()
        {
            #region Lecture 1
            Func<int, int, bool> checkIntegers = (i,j) => i < 8;

            Action printSomething = () => Console.WriteLine("Printing");

            Console.WriteLine(checkIntegers(5,7));

            printSomething();

            Action<int, int> sumTwoNumbers = (i, j) =>
            {
                Console.WriteLine($"The i number is: {i}");
                Console.WriteLine($"The j number is: {j}");
                Console.WriteLine($"The sum of i + j number is: {i+j}");
            };
            #endregion Lecture 1

            #region Lecture 2
            string[] names = { "Alice", "John", "Bobby", "Kyle", "Harmony", "Grace", "Allen", "Ted", "Monty" };

            Func<string[], Func<string, bool>, List<string>> extractStrings = (array, filter) =>
            {
                List<string> result = new List<string>();

                foreach(var item in array)
                {
                    if (filter(item))
                    {
                        result.Add(item);
                    }
                }

                return result;
            };

            Func<string, bool> lessThanFive = x => x.Length < 5;
            Func<string, bool> moreThanFive = x => x.Length > 5;
            Func<string, bool> equalToFive = x => x.Length == 5;

            List<string> namesLessThanFive = extractStrings(names, lessThanFive);
            List<string> namesMoreThanFive = extractStrings(names, moreThanFive);
            List<string> namesEqualToFive = extractStrings(names, equalToFive);

            Console.WriteLine(string.Join(", ", namesLessThanFive));
            #endregion Lecture 2
        }
    }
}
