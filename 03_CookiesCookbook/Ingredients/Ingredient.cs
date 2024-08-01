namespace Ingredients;

public abstract class Ingredient
{
  public abstract int Id { get; }
  public abstract string Name { get; }
  public abstract string PreparationInstructions { get; }
}

public enum Ingredients
{
  WheatFlour,
  CoconutFlour,
  Butter,
  Chocolate,
  Sugar,
  Cardamon,
  Cinnamon,
  CocoaPowder
}