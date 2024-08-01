namespace Ingredients;

// Create an interface to define the available properties to inheriting members. I chose an interface over an abstract
// class because there is nothing other than property signatures that need to be defined here, and an interface suffices for this.
public interface IIngredient
{
  public int Id { get; }
  public string Name { get; }
  public string PreparationInstructions { get; }
}

// Enum used to evaluate user input and print user choice of ingredient to screen.
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