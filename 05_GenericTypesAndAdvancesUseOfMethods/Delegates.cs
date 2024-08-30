using System;

/*
A delegate is a type whose instances hold a reference to a method (or methods) with a particular parameter list and return type.
The Func and Action types are simply generic delegates.

We can define variables of the delegate defined and provide a method definition, and with this we can pass those methods as arguments
into other methods.
*/

namespace _05_GenericTypesAndAdvancesUseOfMethods;

public class Delegates
{
  public void Main()
  {
    // Since we have defined a delegate below, we can create these methods as the type of delegate as long as they match the delegate signature.
    PrintDelegate print1 = static text => text.ToUpper();
    PrintDelegate print2 = static text => text.ToLower();

    // Here we pass the variables as methods to the Printer method, which takes the PrintDelegate as a parameter.
    Printer(print1, "i am now uppercase");
    Printer(print2, "I AM NOW LOWERCASE");
  }

  public static void Printer(PrintDelegate print, string text)
  {
    print(text);
  }

  // This is the delegate definiton, which tells the developer they can create methods using this delegate and assign them to a variable.
  public delegate void PrintDelegate(string input);
}
