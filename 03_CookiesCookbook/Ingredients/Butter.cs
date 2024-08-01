namespace Ingredients;

public class Butter : IIngredient
{
  public override int Id { get => 3; }
  public string Name { get => "Butter"; }
  public string PreparationInstructions { get => "Melt on low heat. Add to other ingredients."; }
}
