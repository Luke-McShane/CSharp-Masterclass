// A generic type or method is a type or method that is parameterised by other types. For example, the list type is generic as it
// can house any type within it.

// Every list has an array as its underlying data structure. Each list object has a private array in which it stores its items.
// Whem we run out of room in the private array, a new array is created, double the size of the previous array, and the values
// are copied over and the array is replaced with this new array. The 'size' of the list is the amount of values within the array,
// even though there will most likely be empty spaces in the array. This increases memory usage as there will be some point in time
// when there are two arrays extant (one to be replaced, and the one to do the replacing).

// Removing an item from a list can also be performance heavy because all elements to the right must be moved left so that there are
// no spaces between elements. This can be very performance heavy if the list is very large.

using System.Runtime.CompilerServices;
using _05_GenericTypesAndAdvancesUseOfMethods;

StrategyDesignPattern.Main();

var myIntList = new ListOfItems<int>();
myIntList.Add(10);
myIntList.Add(20);
myIntList.Add(30);
myIntList.Add(40);
myIntList.Add(50);
myIntList.Add(60);
myIntList.Add(70);
myIntList.Add(80);

myIntList.RemoveAt(4);

var myStringList = new ListOfItems<string>();
myStringList.Add("aaa");
myStringList.Add("bbb");
myStringList.Add("ccc");

var myDateList = new ListOfItems<DateTime>();
myDateList.Add(new DateTime(2024, 08, 14));
myDateList.Add(new DateTime(2023, 09, 13));
myDateList.Add(new DateTime(2022, 10, 12));

///
///
///

// This class can take two parameters of the same type, specific within angled brackets.
var pairOfInts = new Pair<int>(12, 15);
var pairOfStrings = new Pair<string>("first string", "second string");
var pairOfDates = new Pair<DateTime>(new DateTime(2023, 12, 9), new DateTime(2024, 07, 23));

///
///
///

// Here we create a PairOfInts object using the GetMindAndMax method, because this returns the PairOfInts type
PairOfInts minAndMax = GetMinAndMax(new List<int> { 4, 63, 54, 8, 17, 34, 27 });
Console.WriteLine($"Smallest number: {minAndMax.First}, Largest number: {minAndMax.Second}");

///
///
///

// Here is an example of making the most of the generic class we created to create objects with different data types in them.
// But what if we want a tuple with more than two parameters?
var tuple1 = new TupleExample<string, bool>("222", false);
var tuple2 = new TupleExample<DateTime, float>(new DateTime(2014, 12, 31), 12.01f);
var tuple3 = new TupleExample<decimal, int>(23.42m, 245);

// We can use C#'s built in type, Tuple, to have as many parameters as we'd like.
var builtInTuple1 = new Tuple<int, bool, string>(124, true, "example");

///
///
///

// Here we make use of the list conversion method we created in the ListExtension class which extends the list class.
var decimalList = new List<decimal> { 1.3m, 2.4m, 34.5m };
List<int> intList = decimalList.ConvertTo<decimal, int>();
foreach (var item in intList)
{
  System.Console.WriteLine(item);
}

///
///
///

// This method takes a collection of ints and rtturns the smallest and largest from the list as a PairOfInts object.
// As you can see, this is restrictive because it can only take a collection of ints and can only return a 'PairOfInts' object,
// but what if we wanted to return two strings or dates.
PairOfInts GetMinAndMax(IEnumerable<int> input)
{
  if (!input.Any())
  {
    throw new InvalidOperationException("The collection cannot be empty.");
  }

  int min = input.First();
  int max = input.First();
  foreach (int num in input)
  {
    if (num > max)
    {
      max = num;
    }
    if (num < min)
    {
      min = num;
    }
  }
  return new PairOfInts(min, max);
}

TupleExample<int, int> GetMinAndMaxTuple(IEnumerable<int> input)
{
  if (!input.Any())
  {
    throw new InvalidOperationException("The collection cannot be empty.");
  }

  int min = input.First();
  int max = input.First();
  foreach (int num in input)
  {
    if (num > max)
    {
      max = num;
    }
    if (num < min)
    {
      min = num;
    }
  }
  return new TupleExample<int, int>(min, max);
}

// Here is a method that swaps the types of a tuple around and returns this new tuple.
static Tuple<T2, T1> SwapTupleItems<T1, T2>(Tuple<T1, T2> tupleSource)
              => new Tuple<T2, T1>(tupleSource.Item2, tupleSource.Item1);

///

// Here we make use of a type constraint, ensuring that the type we are passing has a parameterless constructor.
// If we didn't have this constraint we wouldn't be able to 'Add(new T())' because we couldn't be certain that the
// type being passed has a parameterless constructor.
IEnumerable<T> CreateCollectionOfRandomLength<T>(int maxLength) where T : new()
{
  var length = new Random().Next(0, maxLength + 1);
  var result = new List<T>();

  for (int i = 0; i < maxLength; ++i)
  {
    result.Add(new T());
  }
  return result;
}

Console.Read();