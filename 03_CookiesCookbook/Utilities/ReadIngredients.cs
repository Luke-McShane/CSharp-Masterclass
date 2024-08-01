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

  public Ingredient? GetAllIngredients(string strId)
  {
    bool valid = int.TryParse(strId, out int id);
    if (!valid) return null;
    List<Ingredient> allIngredients = new List<Ingredient>{
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

  private Ingredient? FindIngredientById(List<Ingredient> ingredients, int id)
  {
    foreach (var ingredient in ingredients)
    {
      if (ingredient.Id == id) { return ingredient; }
    }
    return null;
  }

}

// var enmumCov = new CreateObjectFromEnum();
// bool flag = int.TryParse(ingredient, out result);
// Ingredients.Ingredients whichIngredient = (Ingredients.Ingredients)(result - 1);
// // Ingredient newIng = Activator.CreateInstance(Type.GetType);
// // var newIng = (Ingredient?)Activator.CreateInstance(((Ingredients.Ingredients)result - 1).GetType());
// // Ingredient newIng = enmumCov.GetIngredient((Ingredients)result - 1);
// // Ingredient newIng = new (nameof())
// // Console.WriteLine($"{newIng.Name}. {newIng.PreparationInstructions}");