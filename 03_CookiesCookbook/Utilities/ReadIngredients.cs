using Ingredients;
using Ingredients.Cardamon;
using Ingredients.Chocolate;
using Ingredients.Cinnamon;
using Ingredients.CocoaPowder;
using Ingredients.CoconutFlour;
using Ingredients.Sugar;
using Ingredients.WheatFlour;

namespace Utilities;

// This class is used to generate and return an IIngredient object based on an integer provided (this int is read from a line from a file).
public class ReadIngredients
{
  public IIngredient? GetAllIngredients(string strId)
  {
    // If the input is valid, create a list of objects.
    bool valid = int.TryParse(strId, out int id);
    if (!valid) return null;
    List<IIngredient> allIngredients = new List<IIngredient>{
          new Butter(),
          new Cardamon(),
          new Chocolate(),
          new Cinnamon(),
          new CocoaPowder(),
          new CoconutFlour(),
          new Sugar(),
          new WheatFlour(),
    };
    // Return an object based on the id passed.
    return FindIngredientById(allIngredients, id);

  }

  // We want to return an object and we take as arguments a list of objects and an id we would like to index the list of objects with.
  private IIngredient? FindIngredientById(List<IIngredient> ingredients, int id)
  {
    // If the id of the object matches the integer passed, return this IIngredient object.
    foreach (var ingredient in ingredients)
    {
      if (ingredient.Id == id) { return ingredient; }
    }
    return null;
  }
}