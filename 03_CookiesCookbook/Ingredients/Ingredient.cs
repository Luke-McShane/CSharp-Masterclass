namespace Ingredients;

public interface IIngredient
{
  public int Id { get; }
  public string Name { get; }
  public string PreparationInstructions { get; }
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