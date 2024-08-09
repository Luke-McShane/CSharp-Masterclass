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
    throw new Exception("Collection cannot be empty.");
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
      throw new ArgumentException("Please enter a valid year of birth. " +
        "The year of birth must be between 1900 and the current year.");
    }

    Name = name;
    YearOfBirth = yearOfBirth;
  }
}