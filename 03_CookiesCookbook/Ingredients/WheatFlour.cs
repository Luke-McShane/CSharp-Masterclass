namespace Ingredients.WheatFlour;

public class WheatFlour : IIngredient
{
  public int Id { get => 1; }
  public string Name { get => "Wheat flour"; }
  public string PreparationInstructions { get => "Sieve. Add to other ingredients."; }
}
