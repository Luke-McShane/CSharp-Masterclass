// A generic type or method is a type or method that is parameterised by other types. For example, the list type is generic as it
// can house any type within it.

// Every list has an array as its underlying data structure. Each list object has a private array in which it stores its items.
// Whem we run out of room in the private array, a new array is created, doubles the size of the previous array, and the values
// are copied over and the array is replaced with this new array. The 'size' of the list is the amount of values within the array,
// even though there will most likely be empty spaces in the array. This increases memory usage as there will be some point in time
// when there are two arrays extant (one to be replaced, and the one to do the replacing).

// Removing an item from a list can also be performance heavy because all elements to the right must be moved left so that there are
// no spaces between elements. This can be very performance heavy if the list is very large.

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

  // default is the default for the specific type.
  public void ResetFirst()
  {
    First = default;
  }

  public void ResetSecond()
  {
    Second = default;
  }
}
