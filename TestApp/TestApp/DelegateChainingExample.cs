using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TestApp
{
    public class DelegateChainingExample
    {
        public delegate void Printer(string message);
        public delegate bool CheckLengthOfString(string item);
        public delegate int GetLengths(string message);

        public static void Test()
        {
            #region Lecture1
            Printer p = Print;

            p += Print;
            p += PrintTwice;
            p += Print;
            p += PrintTwice;
            p += Print;

            p -= Print;

            p("Message");

            Delegate[] delegates = p.GetInvocationList();

            foreach (var del in delegates)
            {
                //Console.WriteLine(del.Method);
            }
            #endregion Lecture1

            #region Lecture2
            CheckLengthOfString d = LessThanFive;
            d += MoreThanFive;
            d += ExactlyFive;

            /* Hard Way
            List<bool> results = new List<bool>();

            foreach(var del in d.GetInvocationList())
            {
                results.Add((bool)del.DynamicInvoke("Message")); 
            }
            */

            /* Static Way 
            List<bool> results = d.GetInvocationList().Select(del => (bool)del.DynamicInvoke("Message")).ToList();
            */

            /* Generic Way */
            List<bool> results = GottaCatchEmAll<bool>(d, "Message");
            Console.WriteLine(string.Join(", ", results));

            GetLengths g = x => x.Length;
            g += x => x.Length + 1;
            g += x => x.Length + 2;

            List<int> lengths = GottaCatchEmAll<int>(g, "Message");
            Console.WriteLine(string.Join(", ", g));

            Console.WriteLine(d("Message"));
            #endregion Lecture2

            #region Lecture 3
            Action<string> printer = Print;
            printer += PrintTwice;
            printer("Message");
            #endregion Lecture 3
        }

        public static List<T> GottaCatchEmAll<T>(Delegate del, object parameter = null)
        {
            List<T> result = del.GetInvocationList()
                                .Select(d => (T)d.DynamicInvoke(parameter))
                                .ToList();

            return result;
        }

        public static void PrintTwice(string message)
        {
            Console.WriteLine(message + "1");
            Console.WriteLine(message + "1");
        }

        public static void Print(string message)
        {
            Console.WriteLine(message);
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
    }
}
