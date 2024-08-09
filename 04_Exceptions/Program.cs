// The stack trace is the trace of all the methods that have been called up until the current point in execution.
// Using try-catch blocks isn't always the best way to handle possible exceptions due to how they make the code bulky and have a performance impact.
// We can use try-catch (and 'finally') blocks when we believe it is possible that our code could throw an exception, and we know how we might handle it.

System.Console.WriteLine("Please enter a number: ");
string input = Console.ReadLine();

try
{
  int userInt = ParseStringToInt(input);
  int result = 10 / input;
  System.Console.WriteLine($"10 / {input} = {result}.");
}
// If any code throws an exception in the try block, the catch block will be executed.
// We can pass the exception through as an argument by adding the 'Exception' type followed by the variable name in the parameter list.
// We iedally want to be more specific than just stating a generic Exception, as we can see below.
catch (FormatException ex)
{
  // Here we print the message of the exception to the console to give the user more information about what happened.
  System.Console.WriteLine("Wrong format: cannot parse a string to an int. " +
    "Exception message: " + ex.Message);
}
// We want to catch the exceptions from most specific to most generic, otherwise if we catch the 'Exception' type first, every exception will meet
// this condition and we won't enter any more specific catch statement.
catch (DivideByZeroException ex)
{
  System.Console.WriteLine("Division by zero is an invalid operation. " +
    "Exception message: " + ex.Message);
}
// If the more generic catch statement comes before more specific catch statements, the code will simply not compile.
catch (Exception ex)
{
  System.Console.WriteLine("Unknown exception occurred. " +
    "Exception message: " + ex.Message);
}
// The code in the finally block will always be executed, no matter if there was an exception or not.
// We don't need to add a finally block, and it is usually used to free up resources that we opened in the try block, such as a connection to a database.
finally
{
  System.Console.WriteLine("Finally block is being executed.");
}

int ParseStringToInt(string input)
{
  try
  {
    return int.Parse(input);
  }
  catch
  {
    // Here we return 0 just to show how a try-catch block can be executed when already in a try-catch block.
    System.Console.WriteLine($"Parsing error in the {nameof(ParseStringToInt)} method.");
    return 0;
  }
}

