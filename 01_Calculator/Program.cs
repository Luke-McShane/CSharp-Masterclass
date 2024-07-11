public static class Calculator
{
  private static void Main(string[] args)
  {
    Console.WriteLine("Hello>\nInput the first number:");
    var firstInput = Console.ReadLine();
    int firstInputInt = int.Parse(firstInput);

    Console.WriteLine("Input the second number:");
    var secondInput = Console.ReadLine();
    int secondInputInt = int.Parse(secondInput);

    Console.WriteLine("What do you want to do with those numbers?\n[A]dd\n[S]ubtract\n[M]ultiply");
    var userChoice = Console.ReadLine();

    // if (userChoice is not null) { userChoice = userChoice.ToUpper(); }
    if (userChoice.ToUpper() == "A")
    {
      Print(firstInputInt, secondInputInt, firstInputInt + secondInputInt, "+");
    }
    else if (userChoice.ToUpper() == "S")
    {
      Print(firstInputInt, secondInputInt, firstInputInt - secondInputInt, "-");
    }
    else if (userChoice.ToUpper() == "M")
    {
      Print(firstInputInt, secondInputInt, firstInputInt * secondInputInt, "*");
    }
    else Console.WriteLine("Invalid option");

    Console.WriteLine("Press any key to close");
    Console.ReadKey();
  }
  static void Print(int a, int b, int result, string @operator)
  {
    Console.WriteLine($"{a} {@operator} {b} = {result}");
  }
}
