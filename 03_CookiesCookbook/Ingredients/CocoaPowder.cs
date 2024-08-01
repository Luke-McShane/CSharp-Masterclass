namespace Ingredients.CocoaPowder;

public class CocoaPowder : CommonIngredient, IIngredient
{
  public int Id { get => 8; }
  public string Name { get => "Cocoa powder"; }
  public override string PreparationInstructions => $"{base.PreparationInstructions}.";
}
