namespace Coding.Exercise
{
  public static class ExtendInt
  {
    public static List<int> TakeEverySecond(this List<int> ints)
    {
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