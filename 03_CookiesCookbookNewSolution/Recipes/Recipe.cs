namespace CookieCookbook.Recipes;

public class Recipe
{
  // Angled brackets indicate that a generic is used to encapsulate some type. A generic is something that can store
  // multiple types. Here the generic is holding the Ingredient type.

  // The IEnumerable interface allows us to iterate from a collection or a data source. All collection types inherit from this interface.
  public IEnumerable<Ingredient> Ingredients { get; }

  public Recipe(IEnumerable<Ingredient> ingredients)
  {
    Ingredients = ingredients;
  }
}
