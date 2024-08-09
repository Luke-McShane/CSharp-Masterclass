// Exceptions are objects, and can therefore be containers for data. All exception objects derive from the System.Exception base class.
public static class ExceptionsRethrowing
{
  public static int GetMaxValue(List<int> numbers)
  {
    try
    {
      return numbers.Max();
    }
    // Here we catch an ArgumentNullException and throw a new exception of the same type, with the orignal exception being the Inner Exception.
    catch (ArgumentNullException ex)
    {
      throw new ArgumentNullException("The numbers list cannot be null.", ex);
    }
    catch (InvalidOperationException ex)
    {
      // If the user, for example, passes an empty collection, this exception will be called, where we will throw the original exception.
      Console.WriteLine("The numbers list cannot be empty.");
      throw;
    }
  }
}