namespace Ingredients.CoconutFlour;

public class CoconutFlour : CommonIngredient, IIngredient
{
  public int Id { get => 2; }
  public string Name { get => "Coconut flour"; }
  public override string PreparationInstructions => $"Sieve. {base.PreparationInstructions}.";
}
