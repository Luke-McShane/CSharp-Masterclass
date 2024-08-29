// A generic type or method is a type or method that is parameterised by other types. For example, the list type is generic as it
// can house any type within it.

// Every list has an array as its underlying data structure. Each list object has a private array in which it stores its items.
// Whem we run out of room in the private array, a new array is created, double the size of the previous array, and the values
// are copied over and the array is replaced with this new array. The 'size' of the list is the amount of values within the array,
// even though there will most likely be empty spaces in the array. This increases memory usage as there will be some point in time
// when there are two arrays extant (one to be replaced, and the one to do the replacing).

// Removing an item from a list can also be performance heavy because all elements to the right must be moved left so that there are
// no spaces between elements. This can be very performance heavy if the list is very large.

// Here we create a class (must be static) that will house a method to extend the list class.
public static class ListExtension
{
  // Here is our first example of a generic method. We show that it's generic by adding the <T> after the method name.
  public static void AddToFront<T>(this List<T> list, T item)
  {
    list.Insert(0, item);
  }

  // Here we show how we can convert a list of one type to a list of another type. We have two generic types passed in the parameter
  // list to store what the source list type is and then what the target list type is.
  // public static List<TTarget> ConvertTo<TSource, TTarget>(this List<TSource> list)
  // {
  //   var result = new List<TTarget>();

  //   foreach (var item in list)
  //   {
  //     result.Add((TTarget)item);
  //   }
  //   return result;
  // }

  public static List<TTarget> ConvertTo<TSource, TTarget>(this List<TSource> list)
  {
    var result = new List<TTarget>();

    foreach (var item in list)
    {
      TTarget itemAfterCasting = (TTarget)Convert.ChangeType(item, typeof(TTarget));
      result.Add(itemAfterCasting);
    }

    return result;

  }
}