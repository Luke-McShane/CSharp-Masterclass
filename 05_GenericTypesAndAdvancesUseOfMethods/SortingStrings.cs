/*
Here we create a sorted list method that will be able to sort FullName objects because we have implemented the CompareTo
method of the IComparable interface in the FullName class definition.

In the CompareTo function we use the CompareTo method within it to compare the strings. What we are doing is first checking
the order of the lastnames and, if they are the same, we are ordering based on the firstnames.
*/

public class SortedList<T> where T : IComparable<T>
{
  public IEnumerable<T> Items { get; }

  public SortedList(IEnumerable<T> items)
  {
    var asList = items.ToList();
    asList.Sort();
    Items = asList;
  }
}

public class FullName : IComparable<FullName>
{
  public string FirstName { get; init; }
  public string LastName { get; init; }

  public override string ToString() => $"{FirstName} {LastName}";

  public int CompareTo(FullName other)
  {
    if (LastName.CompareTo(other.LastName) > 0) return 1;
    else if (LastName.CompareTo(other.LastName) < 0) return -1;
    else
    {
      if (FirstName.CompareTo(other.FirstName) > 0) return 1;
      else if (FirstName.CompareTo(other.FirstName) < 0) return -1;
      return 0;
    }
  }
}