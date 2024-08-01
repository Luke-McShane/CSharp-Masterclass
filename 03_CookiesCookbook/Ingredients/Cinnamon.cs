namespace Ingredients.Cinnamon;

public class Cinnamon : CommonIngredient, IIngredient
{
  public int Id { get => 7; }
  public string Name { get => "Cinnamon"; }
  public override string PreparationInstructions => $"Take half a teaspoon. {base.PreparationInstructions}.";
}
