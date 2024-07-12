
public class CSharpFundementalExercises
{
  private static void Main(string[] args)
  {
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

    // He is the conventional if/else if/else way of handling user input
    // if (input == "S") { Print("See all TODOs"); }
    // else if (input == "A") { Print("Add a TODO"); }
    // else if (input == "R") { Print("Remove a TODO"); }
    // else if (input == "E") { Print("Exit"); } else Print("Unknown user input!");

    // Here is the switch statement way of handling user input
    switch (input)
    {
      case "S":
        Print("See all TODOs");
        break;
      case "A":
        Print("Remove a TODO");
        break;
      case "R":
        Print("Remove a TODO");
        break;
      case "E":
        Print("Exit");
        break;
      default:
        Print("Unknown user input!");
        break;
    }
  }

  // Here we create a method called Print with the *parameter* called choice. An argument will be passed to Print, and the parameter will be initialised
  // to the value of the argument provided.
  static void Print(string choice)
  {
    Console.WriteLine("User's Choice: " + choice);
  }
}