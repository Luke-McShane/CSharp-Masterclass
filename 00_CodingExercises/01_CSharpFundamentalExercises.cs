
public class CSharpFundementalExercises
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
    if (input is not null) input = input.ToUpper();

    // Here we pass the *argument* called choice as a parameter into the Print method (a method is the same as a function in other languages)
    // If we wanted the user input to be an integer, we could convert the result of .ReadLine() (which returns a string?) to an integer using
    // the int.Parse(input) method. 
    if (input == "S") { Print("See all TODOs"); }
    else if (input == "A") { Print("Add a TODO"); }
    else if (input == "R") { Print("Remove a TODO"); }
    else if (input == "E") { Print("Exit"); } else Print("Unknown user input!");
  }

  // Here we create a method called Print with the *parameter* called choice. An argument will be passed to Print, and the parameter will be initialised
  // to the value of the argument provided.
  static void Print(string choice)
  {
    Console.WriteLine("User's Choice: " + choice);
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

    if (a > b)
    {
      Console.WriteLine("a is larger than b");
    }
    else if (a < b)
    {
      Console.WriteLine("b is larger than a");
    }
    else Console.WriteLine("a is equal to b");

    /*
    Booleans:
    var isLargerOrEqualTo = a >= b;
    var isSmallerOrEqualTo = a <= b;
    var isLarger = a > b;
    var isSmaller = a < b;
    var isEven = 10 % 2 == 0;
    var isOdd = 10 % 3 == 1;
    */

    /*
    And/Or
    var isSmallerThan5AndEven = a < 5 && a % 2 = 0;
    var isSmallerThan5OrOdd = a < 5 || a % 2 = 1;
    */
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

