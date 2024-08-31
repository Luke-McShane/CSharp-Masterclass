using System;

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
    List<int> result = NumbersFilter.FilterBy(userInput, numbers);

    Print(result);
  }

  private static void Print(IEnumerable<int> numbers)
  {
    Console.WriteLine(string.Join(',', numbers));
  }
}

public static class NumbersFilter
{
  public static List<int> FilterBy(string filteringType, List<int> numbers)
  {
    switch (filteringType)
    {
      case "Odd":
        return SelectOdd(numbers);
      case "Even":
        return SelectEven(numbers);
      case "Positive":
        return SelectPositive(numbers);
      default:
        throw new NotSupportedException(
          $"{filteringType} is not a valid filter.");
    }
  }

  private static List<int> SelectOdd(List<int> numbers)
  {
    var result = new List<int>();
    foreach (var num in numbers)
    {
      if (num % 2 == 1) result.Add(num);
    }
    return result;
  }

  private static List<int> SelectEven(List<int> numbers)
  {
    var result = new List<int>();
    foreach (var num in numbers)
    {
      if (num % 2 == 0) result.Add(num);
    }
    return result;
  }

  private static List<int> SelectPositive(List<int> numbers)
  {
    var result = new List<int>();
    foreach (var num in numbers)
    {
      if (num > 0) result.Add(num);
    }
    return result;
  }

}