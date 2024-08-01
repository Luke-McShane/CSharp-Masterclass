namespace Ingredients.Chocolate;

public class Chocolate : CommonIngredient, IIngredient
{
  public int Id { get => 4; }
  public string Name { get => "Chocolate"; }
  public override string PreparationInstructions => $"Melt in a water bath. {base.PreparationInstructions}.";
}
