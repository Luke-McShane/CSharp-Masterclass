namespace Ingredients.Cardamon;

public class Cardamon : CommonIngredient, IIngredient
{
  public int Id { get => 6; }
  public string Name { get => "Cardamon"; }
  public override string PreparationInstructions => $"Take half a teaspoon. {base.PreparationInstructions}.";
}
