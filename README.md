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
    int[] numbers = {5, 6, 12, 34, 99, 106, 23, 5}

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