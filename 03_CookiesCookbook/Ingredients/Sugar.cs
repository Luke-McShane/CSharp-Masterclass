namespace Ingredients.Sugar;
public class Sugar : CommonIngredient, IIngredient
{
  public int Id { get => 5; }
  public string Name { get => "Sugar"; }
  public override string PreparationInstructions => $"{base.PreparationInstructions}.";
}
