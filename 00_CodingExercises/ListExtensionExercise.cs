namespace Coding.Exercise
{
  public static class ExtendInt
  {
    // Extend the List class using the 'this' keyword in the parameter list.
    public static List<int> TakeEverySecond(this List<int> ints)
    {
      // Create temporary list and iterate through each item, checking if it the second (and so on) item in the list using the modulo operator.
      // Also check if the item is already in the list to be returned.
      List<int> res = new List<int>();
      for (int i = 0; i < ints.Count; ++i)
      {

        {
          if ((i + 1) % 2 == 1 && (!res.Contains(ints[i])))
            res.Add(ints[i]);
        }
      }
      return res;
    }
  }
}