namespace Ingredients;

// Create abstract class to help reduce repition of this very common part of PreparationInstructions
public abstract class CommonIngredient
{
  public virtual string PreparationInstructions => "Add to other ingredients";
}