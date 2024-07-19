class Dice
{
  public int Number { get; init; }


  private readonly Random _rnd;
  private const int SidesOnDice = 6;

  public Dice(Random random)
  {
    _rnd = random;
    Number = _rnd.Next(1, SidesOnDice + 1);
  }
}
