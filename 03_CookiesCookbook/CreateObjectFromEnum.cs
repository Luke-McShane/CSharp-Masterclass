using Ingredients;

public class CreateObjectFromEnum
{
  public Ingredient? GetIngredient(Ingredients.Ingredients ingredient)
  {
    return (Ingredient?)Activator.CreateInstance(Type.GetType(ingredient.ToString()));
  }
}
