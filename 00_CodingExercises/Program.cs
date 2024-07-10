using System;

internal class Program
{
  private static void Main(string[] args)
  {
    Console.WriteLine("Hello, user!");
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("[S]ee all todos.");
    Console.WriteLine("[A]dd a todo.");
    Console.WriteLine("[R]emove a todo.");
    Console.WriteLine("[E]xit");

    var input = Console.ReadKey().ToString();
    Console.WriteLine("\nYour inputs: ", input);
    Console.ReadKey();

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