using System;
using System.Security.Cryptography.X509Certificates;

/*
OPEN-CLOSED PRINCIPLE (SOLID PRINCIPLE #2)

The open-closed principle states that modules, classes, and functions should opened for extension but closed for modification.
This states that we should create our code in such a way that its behaviour can be changed by adding new code, not changing existing code.

Reasons we don't want to modify existing code:
- The code works as expected, meaning no surprises for developers who have grown used to the code.
- The code has already been tested manually by developers and automatically through unit testing.
- If the code is part of a library, then by not modifying it we won't need to release a new version of the code to those using the library.
*/

/*
STRATEGY DESIGN PATTERN

The strategy design pattern allows us to define a family of algorithms that perform some tasks. The concrete strategy can be selected at runtime.
*/
namespace _05_GenericTypesAndAdvancesUseOfMethods;

public static class StrategyDesignPattern
{
  public static void Main()
  {
    var numbers = new List<int> { 10, 12, -100, 55, 17, 22 };

    System.Console.WriteLine(@"Select Filter:
    Odd
    Even
    Positive");

    var userInput = Console.ReadLine();
    var filteringStrategySelector = new FilteringStrategySelector();
    var filteringStrategy = filteringStrategySelector.Select(userInput);
    var filterResult = new NumbersFilter().FilterBy(filteringStrategy, numbers);

    Print(filterResult);
  }

  private static void Print(IEnumerable<int> numbers)
  {
    Console.WriteLine(string.Join(',', numbers));
  }
}



public class NumbersFilter
{
  public List<int> FilterBy(Func<int, bool> predicate, List<int> numbers)
  {
    var result = new List<int>();
    foreach (var num in numbers)
    {
      if (predicate(num)) result.Add(num);
    }
    return result;
  }
}

public class FilteringStrategySelector
{
  private readonly Dictionary<string, Func<int, bool>> _filteringStrategies = new Dictionary<string, Func<int, bool>>
  {
    {"Odd", x => x % 2 == 1},
    {"Even", x => x % 2 == 0},
    {"Positive", x => x > 0}
  };
  
  public Func<int, bool> Select(string filteringType)
  {
    if (!_filteringStrategies.ContainsKey(filteringType)) throw new NotSupportedException($"{filteringType} is not a valid filter.");
    return _filteringStrategies[filteringType];
  }
}