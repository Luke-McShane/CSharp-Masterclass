class Dice
{
  public int Number { get; init; }


  private static readonly Random _rnd = new Random();
  private const int SidesOnDice = 6;

  public Dice()
  {
    Number = _rnd.Next(1, SidesOnDice + 1);
    System.Console.WriteLine(Number);
  }
}
