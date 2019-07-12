# csharp-advanced-topics-course
This is a learning repo for C# Advanced Topics Udemy course.

## LINQ - Language Integrated Query
LINQ is a .net library that allows a programmer to write code which queries collections in a similar manner to SQL.

There are three basic operations:
1) Get the Source
2) Create the Query
3) Execute the Query

The anatomy of a Query is:
1) Define the source - from ... in ...
2) Define some conditions - where ...
3) Take the filtered output - select ...

```csharp
    using System.Collections.Generic;
    using System.Linq;

    string sentence = "I love cats";
    string[] catNames = {"Lucky", "Bella", "Luna", "Oreo", "Simba", "Toby", "Loki" };
    int[] numbers = {5, 6, 12, 34, 99, 106, 23, 5, 7, 17, 9, 54, 35, 28}

    var getNumbers =    from number in numbers
                        where number < 5
                        orderby number
                        select number;

    var getCatsWithA =  from cat in catNames
                        where cat.Contains("a")
                        where cat.Length < 5
                        select cat;

    System.Console.WriteLine(string.Join(", ", getNumbers));
    System.Console.WriteLine(string.Join(", ", getCatsWithA));
```

**Queries with LINQ are only run when the collection is used somewhere**

Multiple _where_ classes can be used for multiple checked conditions.

The _orderby_ keyword can be used to order the elemnts in the query.  Multiple _orderby_ clauses can be used for elements with similar properties.

The _descending_ keyword can be used to perform less than to greater than ordering.  The _ascending_ keyword can be used to perform the opposite functionality.

## Lambda Expressions
Lambda expressions are used to do some operation on an input.  They are used in the place of methods when the body is short and they are not used a lot.  LINQ operations are perfect for utilizing lambda expressions.
Lambda Operator: =>
(Input) => Work on the Input
i.e. N => ((N%2)==1);

```csharp
    using System.Collections.Generic;
    using System.Linq;
    
    int[] numbers = {5, 6, 12, 34, 99, 106, 23, 5, 7, 17, 9, 54, 35, 28}
    string[] catNames = {"Lucky", "Bella", "Luna", "Oreo", "Simba", "Toby", "Loki" };
    object[] mix = {1, "string", 'd', new List<int>(){1,2,3,4}, "dd", 's', 1, 5, 3};
    List<Warrior> warriros = new List<Warrior>()
    {
        new Warrior(){ Height = 100 },
        new Warrior(){ Height = 125 },
        new Warrior(){ Height = 115 },
        new Warrior(){ Height = 120 },
        new Warrior(){ Height = 100 }
    }

    var oddNumbers = from n in numbers
                     where n % == 1
                     select n;
    
    var lambdaOddNumbers = numbers.Where(n => (n % 2 == 1));

    System.Console.WriteLine(string.Join(", ", oddNumbers));
    System.Console.WriteLine(string.Join(", ", lambdaOddNumbers));

    // math functions such as .Average can be used in conjunction with lamda expressions
    double average = catNames.Average(cat => cat.Length);
    System.Console.WriteLine(average);

    // .OfType can be used to call out a specific type
    var allIntegers = mix.OfType<int>().Where(i => i < 3);
    System.Console.WriteLine(string.Join(", ", allIntegers));

    // .Select will return a collection of heights that meet the lambda criteria
    var shortWarriors = warriors.Where(wh => wh.Height == 100)
                                .Select(wh => (wh.Height));

    // .ForEach can be used to print out items with a single line of code
    warriors.ForEach(w => Console.WriteLine(w.Height));
```

## Extension Methods
Extension methods allow you to extend the functionality of a type by adding a .Method() to the type.

The _this_ keyword in the method parameters makes the method an extension method.

Extension method generally live in their own class.