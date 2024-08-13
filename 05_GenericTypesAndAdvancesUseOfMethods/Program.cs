// A generic type or method is a type or method that is parameterised by other types. For example, the list type is generic as it
// can house any type within it.

// Every list has an array as its underlying data structure. Each list object has a private array in which it stores its items.
// Whem we run out of room in the private array, a new array is created, double the size of the previous array, and the values
// are copied over and the array is replaced with this new array. The 'size' of the list is the amount of values within the array,
// even though there will most likely be empty spaces in the array. This increases memory usage as there will be some point in time
// when there are two arrays extant (one to be replaced, and the one to do the replacing).

// Removing an item from a list can also be performance heavy because all elements to the right must be moved left so that there are
// no spaces between elements. This can be very performance heavy if the list is very large.

var myList = new ListOfItems();
myList.Add(10);
myList.Add(20);
myList.Add(30);
myList.Add(40);
myList.Add(50);
myList.Add(60);

Console.Read();
class ListOfItems
{
  private int[] _items = new int[4];
  private int _size = 0;

  public void Add(int item)
  {
    if (_items.Length == _size)
    {
      int[] newArray = new int[_items.Length * 2];
      for (int i = 0; i < _items.Length; ++i)
      {
        newArray[i] = _items[i];
      }
      _items = newArray;
    }

    _items[_size] = item;
    ++_size;


  }
}