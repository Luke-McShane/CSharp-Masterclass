using System;
using System.Numerics;

/*
This is an example of using the generic math interface which allows us to call this method on any valid number,
for every valid number will derive from the INumber interface.
*/

namespace _05_GenericTypesAndAdvancesUseOfMethods;

public class GenericMath
{
  public void Main()
  {
    Console.WriteLine("Square of 2 is: " + Calculator.Square(2));
    Console.WriteLine("Square of 4d is: " + Calculator.Square(4d));
    Console.WriteLine("Square of 6f is: " + Calculator.Square(6f));
    Console.WriteLine("Square of 8m is: " + Calculator.Square(8m));
  }

}

public static class Calculator
{
  public static T Square<T>(T input) where T : INumber<T> => input * input;
}