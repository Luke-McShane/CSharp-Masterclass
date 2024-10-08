// A generic type or method is a type or method that is parameterised by other types. For example, the list type is generic as it
// can house any type within it.

// Every list has an array as its underlying data structure. Each list object has a private array in which it stores its items.
// Whem we run out of room in the private array, a new array is created, double the size of the previous array, and the values
// are copied over and the array is replaced with this new array. The 'size' of the list is the amount of values within the array,
// even though there will most likely be empty spaces in the array. This increases memory usage as there will be some point in time
// when there are two arrays extant (one to be replaced, and the one to do the replacing).

// Removing an item from a list can also be performance heavy because all elements to the right must be moved left so that there are
// no spaces between elements. This can be very performance heavy if the list is very large.

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
