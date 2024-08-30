using System;
using System.Numerics;

namespace _05_GenericTypesAndAdvancesUseOfMethods;

/*
Here we show an advanced use of methods where we use a method as a variable by passing it as an argument.
We can take a method as an argument by using the Func or Action keywords to show that we are expecting a method as an argument.

The 'Func' generic type takes a number of arguments, where the last argument is always the return type. For example:
Func<int, string, bool> - this states that the method will take an int and a string as arguments and will return a bool.

The 'Action' generic type takes a number of arguments but will always be void, so has no return type. For example:
Action<int, string, bool> - this states that the method will take an int, string, and bool as arguments, and will not return anything.
*/

public class FuncAndActionBas
{

  public void Main()
  {
    var numbers = new List<int> { 1, 4, 6, 2, 11, 9 };
    // Here we define two funcs, setting the value of the variable to a method that corresponds with its signature.
    Func<int, bool> predicate1 = IsEven;
    Func<int, bool> predicate2 = IsGreaterThan10;

    var anyEvenNumbers = IsAny(numbers, predicate1);
    var anyNumberGreaterThan10 = IsAny(numbers, predicate2);

    /* 
      We can also use lambda expressions to reduce the amount of code needed. Lambda expressions are anonymous 
      functions that reduce the amount of code we need.
      Notice below how little code we need to do the same thing as when we separately defined the anyEvenNumbers
      and anyNumberGreaterThan10 methods. We can simply do these *inline* using lambda expressions.

      A lambda expression is define by: parameters => expression/statement. Remember that the difference between an expression and
      a statement is that an expression evaluates to a value whereas a statement doesn't.

      If we wanted a parameterless lambda statement we could do so through: () => DoSomethingWithoutArgs;
      If we wanted multiple parameters we would use parenthesis: (x, y) => x + y;
     */

    var anyEvenNumbersLambda = IsAny(numbers, n => n % 2 == 0);
    var anyNumberGreaterThan10Lambda = IsAny(numbers, n => n > 2);

    Console.WriteLine("There is at least one even number in the 'numbers' array: " + anyEvenNumbers);
    Console.WriteLine("There is at least one number greater than 10 in the 'numbers' array: " + anyNumberGreaterThan10);
  }

  public static bool IsAny(IEnumerable<int> numbers, Func<int, bool> predicate)
  {
    foreach (int num in numbers)
    {
      if (predicate(num))
      {
        return true;
      }
    }
    return false;
  }

  public static bool IsEven(int number)
  {
    if (number % 2 == 0) return true;
    return false;
  }

  public static bool IsGreaterThan10(int number)
  {
    if (number > 10) return true;
    return false;
  }
}
