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

var pairOfInts = new Pair<int>(12, 15);
var pairOfStrings = new Pair<string>("first string", "second string");
var pairOfDates = new Pair<DateTime>(new DateTime(2023, 12, 9), new DateTime(2024, 07, 23));

///


PairOfInts minAndMax = GetMinAndMax(new List<int> { 4, 63, 54, 8, 17, 34, 27 });

Console.WriteLine($"Smallest number: {minAndMax.First}, Largest number: {minAndMax.Second}");
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

Console.Read();

// Here we declare we are creating a generic class due to the angled brackets. Using 'T' is by convention, and stands for 'Type', but
// we can have any placeholding name here. We can also have multiple parameters (ListOfItems<T1, T2, T3>) for example, which will act
// as placeholders for different types passed in the parameter list when instantiating an object.
class ListOfItems<T>
{
  // This is how we can use the generic throughout the class.
  private T[] _items = new T[4];
  private int _size = 0;

  public void Add(T item)
  {
    if (_items.Length == _size)
    {
      T[] newArray = new T[_items.Length * 2];
      for (int i = 0; i < _items.Length; ++i)
      {
        newArray[i] = _items[i];
      }
      _items = newArray;
    }

    _items[_size] = item;
    ++_size;
  }

  public void RemoveAt(int index)
  {
    if (index < 0 || index >= _size)
    {
      throw new IndexOutOfRangeException($"Index {index} is out of the range of the list.");
    }

    --_size;

    for (int i = index; i < _size; ++i)
    {
      System.Console.WriteLine(i);
      _items[i] = _items[i + 1];
    }

    // The 'default' keyword gives the default type dependent on the context. So, here, whatever the default value for
    // _items is in this context will be returned and set at _size index.
    // For example, 'int defaultInt = default' will be equal to 0, given the declared type is int.
    _items[_size] = default;

    foreach (var item in _items)
    {
      System.Console.WriteLine(item);
    }
  }

  public T GetAtIndex(int index)
  {
    if (index < 0 || index >= _size)
    {
      throw new IndexOutOfRangeException($"Index {index} is out of the range of the list.");
    }

    return _items[index];
  }
}

// Here we create another generic type and show how we can add a constructor to set default values.
public class Pair<T>
{
  public T First { get; private set; }
  public T Second { get; private set; }

  public Pair(T first, T second)
  {
    First = first;
    Second = second;
  }

  public void ResetFirst()
  {
    First = default;
  }

  public void ResetSecond()
  {
    Second = default;
  }
}

///

// This class is used as a type that we can use to create objects to, for example, store the min and max from a list of ints, as shown above.
// This is showing how we may return two values from a method without using a tuple.
public class PairOfInts
{
  public int First { get; }
  public int Second { get; }

  public PairOfInts(int first, int second)
  {
    First = first;
    Second = second;
  }
}