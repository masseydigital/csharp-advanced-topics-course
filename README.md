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

The input does not need to explicitly state its type, but you can add it along with surrounding parenthesis to make it explicit.  You can also have multiple input types that can be defined with parenthesis, as well as no inputs
in the case of Actions.


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

## Generics
_Generics_ are methods, classes, variables that can apply to more than one type.  You can use them to create methods which apply to more common functionality
that different types might have, i.e. comparing two ints, strings, objects, etc.

_T_ is an accepted type name for generics.

The _IComparable_ interface can be used in conjunction with the _where_ keyword to make a generic method have the ability to use the CompareTo extension method.

_List_ is an example of where generic types are used.

The _dynamic_ keyword allows you to provide runtime type checking instead of having to check at compile time.


## Delegates
_Delegates_ are methods as variables.  Methods that use a delegate must have the same signature.

Delegates can be chained together to perform more complex operations.

_func_ is a built-in delegate type that allows you to pass in inputs and have an output into a single line.

_Action_ is another built-in delegate type.  Actions only take inputs (no return types, void).

_Anonymous Methods_ allow you to define more complex delegate (actions/funcs) behavior using a lambda expression.  You can chain anonymous methods by calling anonymous methods within anonymous methods.

## Events
_Events_ enable a class or object to notify other classes or objects when something of interest occurs.  Events follow the _publisher-subscriber_ model where the sending class 
is called the _publisher_ and the receiving class is called the _subscriber_.

Anatomy of an event:
1) Delegate matching the Event signature
2) Event of the same type as the Delegate
3) Raise the Event at some point

Best practice is to use the suffix, _Handler_, for delegates associated with events.

With events, we can use the _EventHandler_ to replace the delegate keyword.  You can pass event args with EventHandler by using triangle brackets to pass in the args object.

You can put a _?_ at the end of event to check if it has subscribers before firing the event.  This replaces the if(event != null) code.