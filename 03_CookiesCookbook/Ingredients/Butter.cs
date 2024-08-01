namespace Ingredients;

// Inherit from IIngredient interface and define all necessary properties.
public class Butter : CommonIngredient, IIngredient
{
  public int Id { get => 3; }
  public string Name { get => "Butter"; }
  public override string PreparationInstructions => $"Melt on low heat. {base.PreparationInstructions}.";
}
