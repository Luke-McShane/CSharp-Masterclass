System.Console.WriteLine("Dice rolled. Guess what number it shows in 3 tries.");
string? userGuess = Console.ReadLine();
bool hasGuesses = true;

while (hasGuesses)
{
  System.Console.WriteLine(ValidateInput.IsValid(userGuess));
}
class Dice
{
  private readonly int Number { get; }
  private static readonly Random _rnd = new Random();

  Dice()
  {
    Number = _rnd.Next(1, 6);
  }
}

class ValidateInput
{
  public static bool IsValid(string? input) => int.TryParse(input, out _);
}