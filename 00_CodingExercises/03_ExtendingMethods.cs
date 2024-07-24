namespace Practise;

public static class Entry
{
  public static void Main()
  {


    var multiLine = @"aaaa
    bbbb
    cccc
    dddd";

    var spring = Season.Spring;

    System.Console.WriteLine($"Number of lines: {multiLine.CountLines()}");
    System.Console.WriteLine($"The season after Spring is: {spring.NextSeason()}");

  }
}

// Here we show how we can extend a type without modifying the type we are extending from.
// This enables us to call methods on that type as if we were calling directly from the class itself.
// We extend through using the 'this' keyword in the parameter of the method, followed by the type we would like to extend.
// As you can see above, we call the CountLines() method on the string multiLine as if that method belonged to the string class,
// whereas it is actually a method we created to extend the string class, without changing any code in the string class itself.
public static class StringExtensions
{
  public static int CountLines(this string input) =>
    input.Split(Environment.NewLine).Length;
}

public static class SeasonsExtensions
{
  public static Season NextSeason(this Season season) =>
    (Season)(((int)season + 1) % 4);
}

public enum Season
{
  Spring,
  Summer,
  Autumn,
  Winter
}