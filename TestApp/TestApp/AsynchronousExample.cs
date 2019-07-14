using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    public class AsynchronousExample
    {
        static void Test()
        {
            int count = 2000000;
            char charToConcat = '1';

            //Task<string> t = Task.Factory.StartNew(() => ConcatenateChars(charToConcat, count));

            Task<string> t = ConcatenateCharsAsync(charToConcat, count);
            Console.WriteLine("In Progress");
            
            //t.Wait();
           
            Console.WriteLine($"The length of the result is {t.Result.Length}");

            ConcatenateChars(charToConcat, count);
        }

        public static string ConcatenateChars(char charToConcat, int count)
        {
            string concatenatedString = String.Empty;

            for (int i = 0; i < count; i++)
            {
                concatenatedString += charToConcat;
            }

            return concatenatedString;
        }

        public async static Task<string> ConcatenateCharsAsync(char charToConcat, int count)
        {
            return await Task<string>.Factory.StartNew(() =>
            {
                return ConcatenateChars(charToConcat, count);
            });
        }
    }
}
