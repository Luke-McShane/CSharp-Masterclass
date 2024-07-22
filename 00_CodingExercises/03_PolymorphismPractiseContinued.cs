using Microsoft.VisualBasic;

class PolymorphismPractiseContinued
{
  public void Entry()
  {
    List<int> numbers = new List<int> { 1, 4, 6, 12, -12, 5, 32, -23, 5 };
    bool shallAddPositiveOnly = false;

    NumbersSumCalculator calculator = shallAddPositiveOnly == true ?
                          new PositiveNumbersSumCalculator() :
                          new NumbersSumCalculator();

    int sum = calculator.Calculate(numbers);

    System.Console.WriteLine($"Sum is: {sum}");

    //   if (shallAddPositiveOnly)
    //   {
    //     System.Console.WriteLine(new PositiveNumbersSumCalculator().Calculate(numbers));
    //   }
    //   else
    //   {
    //     System.Console.WriteLine(new NumbersSumCalculator().Calculate(numbers));
    //   }
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

  // In the base class, all number shall be added to the sum
  protected virtual bool ShallBeAdded(int number) => true;
}

// Adding this derived class allows us to define what type of number should be added in the calculator. This helps make code more maintainable as
// we can add as many derived classes as we'd like to determine different criteria of what number should be added.
class PositiveNumbersSumCalculator : NumbersSumCalculator
{
  // In this derived class, we overried the base class method to ensure that only positive numbers are being added.
  protected override bool ShallBeAdded(int number)
  {
    if (number > 0) return true;
    else return false;
  }
}