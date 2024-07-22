using Microsoft.VisualBasic;

class PolymorphismPractiseContinued
{
  public void Entry()
  {
    List<int> numbers = new List<int> { 1, 4, 6, 12, -12, 5, 32, -23, 5 };
    bool shallAddPositiveOnly = true;

    if (shallAddPositiveOnly)
    {
      System.Console.WriteLine(new PositiveNumbersSumCalculator().Calculate(numbers));
    }
    else
    {
      System.Console.WriteLine(new NumbersSumCalculator().Calculate(numbers));
    }
  }

}

class NumbersSumCalculator
{
  public virtual int Calculate(List<int> numbers)
  {
    int sum = 0;
    foreach (int number in numbers)
    {
      if (ShallBeAdded(number)) sum += number;
    }
    return sum;
  }

  protected virtual bool ShallBeAdded(int number) => true;
}

class PositiveNumbersSumCalculator : NumbersSumCalculator
{
  protected override bool ShallBeAdded(int number)
  {
    if (number > 0) return true;
    else return false;
  }
}