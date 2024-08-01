namespace Ingredients.WheatFlour;

public class WheatFlour : CommonIngredient, IIngredient
{
  public int Id { get => 1; }
  public string Name { get => "Wheat flour"; }
  public override string PreparationInstructions => $"Sieve. {base.PreparationInstructions}.";
}
