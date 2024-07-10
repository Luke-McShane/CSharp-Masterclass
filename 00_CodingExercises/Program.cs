using System;

namespace _00_CodingExercises
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      // Operators();

      Console.WriteLine("Hello, user!");
      Console.WriteLine("What would you like to do?");
      Console.WriteLine("[S]ee all todos.");
      Console.WriteLine("[A]dd a todo.");
      Console.WriteLine("[R]emove a todo.");
      Console.WriteLine("[E]xit");

      var input = Console.ReadLine();
      Console.WriteLine("\nYour input: " + input);

    }
    private static void Operators()
    {
      int a = 5, b = 10; // Declaring and initialising variables of the same type on one line
      // var a = 5, b = 10; this is using implicit types, where the compiler determines the types based on the values declared.
      // Declaration must happen on the same line as initialisation however, as otherwise the compiler won't know what type to assign the variable.

      Console.WriteLine("Addition: " + (a + b));
      Console.WriteLine("Subtraction: " + (a - b));
      Console.WriteLine("Division: " + b / a);
      Console.WriteLine("Multiplication: " + a * b);

      a++; //Increment the value by 1
      --b; //Decrement the value by 1

      /*
      Booleans:
      var isLargerOrEqualTo = a >= b;
      var isSmallerOrEqualTo = a <= b;
      var isLarger = a > b;
      var isSmaller = a < b;
      var isEven = 10 % 2 == 0;
      var isOdd = 10 % 3 == 1;
      */
    }
  }
}


/*
NAMING CONVENTIONS & RESERVED KEYWORDS

We can use the '@' symbol preceding a reserved keyword to use it as a variable.
For example, @class, @string, @int may be used as variable names, whereas class, string, and into would not

We should always use lower camel case when naming variables, and never start a variable name with a number.

thisIsAGoodVariable, for example. Also this_variable works, but this-variable doesn't work.

Also, count != Count, as the capital letter differentiates these variables.

Use CTRL+R+R to rename all variables of the same name, if you have a poorly-named variable.


*/