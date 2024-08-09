// The stack trace is the trace of all the methods that have been called up until the current point in execution.
// Using try-catch blocks isn't always the best way to handle possible exceptions due to how they make the code bulky and have a performance impact.
// We can use try-catch (and 'finally') blocks when we believe it is possible that our code could throw an exception, and we know how we might handle it.

System.Console.WriteLine("Please enter a number: ");
string input = Console.ReadLine();

try
{
  int userInt = int.Parse(input);
  System.Console.WriteLine("Successfully converted your input to an integer.");
}
catch
{
  System.Console.WriteLine("An exception was thrown.");
}
finally
{
  System.Console.WriteLine("Finally block is being executed.");
}

Console.WriteLine("Hello, World!");

