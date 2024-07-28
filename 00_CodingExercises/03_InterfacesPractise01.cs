using System;

namespace Coding.Exercise
{
  public static class Interfaces
  {

    // Create a method that takes an int, performs three operations on it consecutively, then returns the result.
    public static int Transform(
        int number)
    {
      // Create a list of type INumericTransformation, which is an interface which each item of the list will inherit from.
      var transformations = new List<INumericTransformation>
            {
                new By1Incrementer(),
                new By2Multiplier(),
                new ToPowerOf2Raiser()
            };

      var result = number;
      // Iterate through each interface-derived object in the list and perform the method that the interface states each deriving child must have.
      foreach (var transformation in transformations)
      {
        result = transformation.Transform(result);
      }
      // Return the result after all Transformations have happened.
      return result;
    }
  }

  // This is the interface, which contains signatures of properties and methods that derivatives must provide definitions for.
  // The sole purpose of the interface is to provide signatures for properties and methods, and every class that derives from
  // the interface *MUST* provide definitions for *ALL* these signatures.
  // The naming convention states that interfaces must start with an 'I'.
  // Interfaces cannot have constructors, as they are not used to create objects.
  public interface INumericTransformation
  {
    // Here we provide the signature for a method. We do not need an access modifier as it is public by default, and we cannot use the
    // 'private' modifer since we are unable to provide a definition for the method here, and a private modifer would necessitate
    // its definition within the Interface.
    int Transform(int val);
  }

  public class By1Incrementer : INumericTransformation
  {
    public int Transform(int val) => ++val;
  }

  public class By2Multiplier : INumericTransformation
  {
    public int Transform(int val) => val * 2;
  }

  public class ToPowerOf2Raiser : INumericTransformation
  {
    public int Transform(int val) => val * val;
  }


}
