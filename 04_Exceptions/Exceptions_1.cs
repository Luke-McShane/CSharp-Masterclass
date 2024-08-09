public static class Exceptions_1
{
  public static void Run()
  {
    try
    {
      int firstNumber = GetFirstElement(new int[0]);
    }
    catch (NullReferenceException ex)
    {
      // Here we print the message of the orignal exception.
      System.Console.WriteLine("Exception message: " + ex.InnerException.Message);
    }
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

  static bool IsFirstElementPositive(IEnumerable<int> numbers)
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
      return true;
    }
    // If the GetFirstElement throws a NullReferenceException, we can catch that and wrap the exception in our own
    // ArgumentNullException that we throw and wrap the original exception within by passing it as an argument.
    // The difference is that the NullReferenceException states merely that something is null, whereas the ArgumentNullException
    // specifies that it is the argument that is null.
    catch (NullReferenceException ex)
    {
      // Although we throw a new exception here, the stack trace is still maintained as we can drill into the 'Inner Exception' property
      // to see where the exception was originally thrown from.
      throw new ArgumentNullException("The collection cannot be null. ", ex);

      // We could just use 'throw' or 'throw ex' here. With 'throw' the stack trace is maintained, and when we drill into the exception we can see where the
      // original exception was thrown.
      // When using 'throw ex', we reset the stack trace and it will show that the exception was originally thrown here, which is untrue.
      // throw;
      // throw ex;
    }
  }

  // If we want our code to compile, but haven't yet finished a method, we can throw the NotImplementedException.
  static bool CheckIfContains(int number, int[] numbers)
  {
    throw new NotImplementedException("Not yet implemented. Do not use.");
  }


  public void GetHttpRequest(string url)
  {
    // If, for example, we get an error when trying to make a HTTP request, the error type may simply be of 'HttpRequestException', so we can
    // differentiate between the different errors using the 'when' keyword and specifying some criteria to help us specify the error.
    try
    {
      var request = SendHttpRequest(url);
    }
    catch (HttpRequestException ex) when (ex.Message == "403")
    {
      System.Console.WriteLine("It was forbidden to access the resource.");
      throw;
    }
    catch (HttpRequestException ex) when (ex.Message == "404")
    {
      System.Console.WriteLine("The resource could not be found.");
      throw;
    }
    catch (HttpRequestException ex) when (ex.Message == "500")
    {
      System.Console.WriteLine("The server has experienced an internal error.");
      throw;
    }
    // We can use the StartsWith method to catch the remaining errors that begin with '4', and we place this after the other '403' and '404' catch
    // statements as we want to catch the most specific errors first.
    catch (HttpRequestException ex) when (ex.Message.StartsWith("4"))
    {
      System.Console.WriteLine("Some kind of client error was experienced.");
      throw;
    }
  }

  private string SendHttpRequest(string url)
  {
    throw new NotImplementedException("Not yet implemented");
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
- Remember that it is nearly always a bad idea to catch the Exception type, as we always want to be more specific than this. 
- It can be okay to catch a base Exception object when we don't know specifically what exceptions we may be catching and when we want to log the
  exception and rethrow it.
- We can also wrap the entire program in a try-catch block, so that if any sort of exception is thrown that we are unable to catch, it will at
  least be caught by the global try-catch block, and we can print this exception to the user and gracefully end the program.
- The code within the catch block should be as simple as possible, and it should be very unlikely to throw an exception.
- If an exception is thrown within a catch block, it will not go to the remaining catch blocks, it will instead throw an exception within that
  catch block itself, so you will need to catch it within that catch statement. 
*/