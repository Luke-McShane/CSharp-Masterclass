public class IComparableDemo
{
  public void Main()
  {
    var numbers = new List<int> { 1, 5, 2, 7, 8, 2, 3 };
    numbers.Sort();

    var words = new List<string> { "ddd", "bbb", "ccc", "aaa" };
    words.Sort();

    var people = new List<Person> {
      new Person {Name = "Tony", YearOfBirth = 1993},
      new Person {Name = "Mary", YearOfBirth = 1976},
      new Person {Name = "Mark", YearOfBirth = 1954},
    };

    people.Sort();

    var anna = new Person { Name = "Anna", YearOfBirth = 2002 };
    var steven = new Person { Name = "Steven", YearOfBirth = 1983 };

    // We can print these in order because we have created a generic PrintInOrder method that is constrained by
    // type T that must derive from IComparable, meaning it must have access to the CompareTo function.
    PrintInOrder(4, 2);
    PrintInOrder("ccc", "bbb");
    PrintInOrder(steven, anna);

  }

  // We extend from the IComparable interface and define the CompareTo method it outlines, which enables us to use the
  // .Sort() method on the 'people' variable. The Sort method calls CompareTo as much as is needed until the list is sorted,
  // and our definition of CompareTo supplies the rules for sorting.
  public class Person : IComparable<Person>
  {
    public string Name { get; set; }
    public int YearOfBirth { get; set; }

    public int CompareTo(Person other)
    {
      if (YearOfBirth < other.YearOfBirth) return 1;
      else if (YearOfBirth > other.YearOfBirth) return -1;
      return 0;

    }
  }

  // Setting a constraint so that the type passed must derive from the IComparable class, and therefore be sortable.
  public void PrintInOrder<T>(T first, T second) where T : IComparable<T>
  {
    if (first.CompareTo(second) > 0)
    {
      System.Console.WriteLine($"{second} {first}");
    }
    else
    {
      System.Console.WriteLine($"{first} {second}");
    }
  }
}