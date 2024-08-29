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

  }

  // We extend from the IComparable interface and define the CompareTo method it outlines, which enables us to use the
  // .Sort() method on the 'people' variable. The Sort method calls CompareTo as much as is needed until the list is sorted,
  // and our definition of CompareTo supplies the rules for sorting.
  public class Person : IComparable<Person>
  {
    public string Name { get; set; } = name;
    public int YearOfBirth { get; set; } = year;

    public int CompareTo(Person other)
    {
      if (YearOfBirth < other.YearOfBirth) return 1;
      else if (YearOfBirth > other.YearOfBirth) return -1;
      return 0;

    }
  }