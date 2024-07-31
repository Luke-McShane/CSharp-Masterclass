public class CreateObjectFromEnum
{
  public Ingredient? GetIngredient(Ingredients ingredient)
  {
    return (Ingredient?)Activator.CreateInstance(Type.GetType(ingredient.ToString()));
  }
}
