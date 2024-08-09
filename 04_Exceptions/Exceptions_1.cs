public static class Exceptions_1
{
  public static void Run()
  {
    int firstNumber = GetFirstElement(new int[0]);
  }

  public static int GetFirstElement(IEnumerable<int> numbers)
  {
    foreach (var number in numbers)
    {
      return number;
    }

    // He were create then throw an exception. It makes sense to throw an exception when:
    // 1. We cannot handle the invalid input in any reasonable way.
    // 2. The fault of the invalid input lies on the user of the method.
    // So here it makes sense to throw an exception, because this method should be only allowed to be passed collections that contain at least one item.

    // We throw the InvalidOperationException here because it is an invalid operation to seek the first element of an empty collection.
    // We could also throw an IndexOutOfRangeException.
    throw new InvalidOperationException("Collection cannot be empty.");
  }

  // If we want our code to compile, but haven't yet finished a method, we can throw the NotImplementedException.
  bool CheckIfContains(int number, int[] numbers)
  {
    throw new NotImplementedException("Not yet implemented. Do not use.")
  }

  bool IsFirstElementPositive(IEnumerable<int> numbers)
  {
    try
    {
      var firstElement = GetFirstElement(numbers);
      return firstElement > 0;
    }
    // Here we are catching the InvalidOperationException that was thrown from the GetFirstElement method.
    catch (InvalidOperationException ex)
    {
      System.Console.WriteLine("The collection is empty. " +
        "Exception mesage: " + ex);
    }
    // If the GetFirstElement throws a NullReferenceException, we can catch that and wrap the exception in our own
    // ArgumentNullException that we throw and wrap the original exception within by passing it as an argument.
    // The difference is that the NullReferenceException states merely that something is null, whereas the ArgumentNullException
    // specifies that it is the argument that is null.
    catch (NullReferenceException ex)
    {
      throw new ArgumentNullException("The collection cannot be null. ", ex);
    }
  }
}

public class Person
{
  string Name { get; }
  int YearOfBirth { get; }

  public Person(string name, int yearOfBirth)
  {
    // Here we are practising handling invalud argument exceptions, which we can throw when the user has passed an invalid argument as a parameter.
    if (name is null)
    {
      throw new ArgumentNullException("The name cannot be null.");
    }
    if (yearOfBirth < 1900 || yearOfBirth > DateTime.Now.Year)
    {
      throw new ArgumentOutOfRangeException("Please enter a valid year of birth. " +
        "The year of birth must be between 1900 and the current year.");
    }

    Name = name;
    YearOfBirth = yearOfBirth;
  }
}

/*
EXCEPTIONS
Remember that it is nearly always a bad idea to catch the Exception type, as we always want to be more specific than this. 
*/