using System.Collections.Generic;
using System.Linq;

namespace LinqAndLambdas
{
    public class LinqTest
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>()
            {
                new Person("Todd", 180, 70, Gender.Male),
                new Person("Jon", 150, 74, Gender.Male),
                new Person("Anna", 135, 65, Gender.Female),
                new Person("Kimberly", 125, 61, Gender.Female),
                new Person("Steve", 175, 76, Gender.Male),
                new Person("Carly", 125, 63, Gender.Female)
            };

            //Selects people who have 4 letters in their name
            var fourCharPeople =    from p in people
                                    where (p.Name.Length == 4)
                                    orderby p.Name descending, p.Height descending
                                    select p;

            //Creates an ordered collection of the names of people
            var peopleNames =   from p in people
                                orderby p.Name
                                select p.Name;
                                    
            foreach(var item in fourCharPeople)
            {
                Console.WriteLine($"Name: {item.Name}, Weight: {item.Weight}");
            }

            foreach(var item in peopleNames)
            {
                Console.WriteLine($"Name: {item}");
            }
        }
    }

    public class Person
    {
        public string Name{get; set;}

        public int Height{get; set;}

        public int Weight{get; set;}

        public Gender Gender {get; set;}

        public Person(string nam, int hgt, int wgt, Gender gdr)
        {
            Name = nam;
            height = hgt;
            Weight = wgt;
            Gender = gdr;
        }
    }

    public enum Gender
    {
        Male,
        Female
    };
}