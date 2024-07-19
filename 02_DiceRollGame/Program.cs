using System.Diagnostics;
using System.Xml.Schema;

System.Console.WriteLine("Dice rolled. Guess what number it shows in 3 tries.");

int userGuesses = 3;
var dice = new Dice();
string Separator = Environment.NewLine;

while (userGuesses > 0)
{
  string? userGuess = Console.ReadLine();
  int userGuessInt;
  if (!ValidateInput.IsValid(userGuess, out userGuessInt))
  {
    System.Console.WriteLine($"{Separator}Incorrect input{Separator}Enter number:");
    continue;
  }
  else if (userGuessInt != dice.Number)
  {
    --userGuesses;
    System.Console.WriteLine($"{Separator}Wrong number{Separator}Enter number:");
    continue;
  }
  else break;
}
if (userGuesses > 0) { System.Console.WriteLine($"{Separator}You win"); }
else { System.Console.WriteLine($"{Separator}You lose"); }
Console.ReadKey();

// class ProcessData {
//   public static Process(string? userGuess) { 

//   }
// }