using System;

namespace Coding.Exercise
{
  public static class NumericTypesDescriber
  {
    // The return type is string? because it is possible that we return a null value if we don't get a valid numeric type. 
    // We ask for an object of any type, as object is the class all other objects derive/inherit from
    public static string? DescribeObject(object someObject)
    {
      // Check which type the object is, and return a value accordingly.
      switch (someObject)
      {
        case (int):
          return $"Int of value {someObject}";
        case (double):
          return $"Double of value {someObject}";
        case (decimal):
          return $"Decimal of value {someObject}";
        case (float):
          return $"Float of value {someObject}";
        default: return null;
      }
    }
  }
}