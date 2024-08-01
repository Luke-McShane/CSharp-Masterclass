using Ingredients;
using Ingredients.Cardamon;
using Ingredients.Chocolate;
using Ingredients.Cinnamon;
using Ingredients.CocoaPowder;
using Ingredients.CoconutFlour;
using Ingredients.Sugar;
using Ingredients.WheatFlour;

namespace Utilities;

public class ReadIngredients
{
  public IIngredient? GetAllIngredients(string strId)
  {
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
    return FindIngredientById(allIngredients, id);

  }

  private IIngredient? FindIngredientById(List<IIngredient> ingredients, int id)
  {
    foreach (var ingredient in ingredients)
    {
      if (ingredient.Id == id) { return ingredient; }
    }
    return null;
  }
}