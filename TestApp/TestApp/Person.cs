using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp
{
    public class Person : IComparable<Person>
    {
        public int Age { get; set; }

        /// <summary>
        /// Compares two people by age returns:
        /// </summary>
        /// <param name="other"></param>
        /// <returns>
        /// -1 if first is less than second
        /// 0 if first is equal to second
        /// 1 first is greater than second
        /// </returns>
        public int CompareTo(Person other)
        {
            if(this.Age < other.Age)
            {
                return -1;
            }
            else if(this.Age == other.Age)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }
    }
}
