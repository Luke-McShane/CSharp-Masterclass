using System.Runtime.ConstrainedExecution;

namespace DiceRollGame.GuessingGame;

class GuessingGame
{
  private readonly Dice _dice;
  private const int StartingTries = 3;

  public GuessingGame(Dice dice)
  {
    _dice = dice;
  }


  public GameResult Play()
  {
    int triesLeft = StartingTries;
    string Separator = Environment.NewLine;
    while (triesLeft > 0)
    {
      string? userGuess = Console.ReadLine();
      int userGuessInt;
      if (!ValidateInput.IsValid(userGuess, out userGuessInt))
      {
        System.Console.WriteLine($"{Separator}Incorrect input{Separator}Enter number:");
        continue;
      }
      else if (userGuessInt != _dice.Number)
      {
        --triesLeft;
        System.Console.WriteLine($"{Separator}Wrong number{Separator}Enter number:");
        continue;
      }
      else break;
    }
    return (triesLeft > 0) ? GameResult.Victory : GameResult.Loss;
  }

  public void PrintResults(GameResult gameResult)
  {
    string message = gameResult == GameResult.Victory ? "You win!" : "You lose!";
    System.Console.WriteLine(message);
  }
}