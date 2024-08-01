// Each ingredient has its own namespace nested within the general 'IIngredient' namespace, which contains the abstract IIngredient
// class and also the Ingredients enum.
using Ingredients;
using Ingredients.Cardamon;
using Ingredients.Chocolate;
using Ingredients.Cinnamon;
using Ingredients.CocoaPowder;
using Ingredients.CoconutFlour;
using Ingredients.Sugar;
using Ingredients.WheatFlour;
using Utilities;

//
public static class Recipe
{
  private const FileType fileType = FileType.json;
  private static bool firstWrite = true;

  public static void Create()
  {
    bool addIngredients = true;

    Ingredients.Ingredients ingredient;
    List<IIngredient> ingredients = new List<IIngredient>();

    FileManipulator.ReadFromFile();

    do
    {
      Console.WriteLine("Add an ingredient by its ID or type anything else if finished.");
      string? input = Console.ReadLine();
      System.Console.WriteLine("Input: " + input);
      if (int.TryParse(input, out int result) && result <= 8 && result >= 1)
      {
        ingredient = (Ingredients.Ingredients)result - 1;
        System.Console.WriteLine("IIngredient: " + ingredient);
        ingredients.Add(CreateIngredient(ingredient));
      }
      else { addIngredients = false; }
    } while (addIngredients);

    if (ingredients.Count >= 1)
    {
      FileManipulator.WriteToFile(ingredients);
    }
  }

  private static IIngredient? CreateIngredient(Ingredients.Ingredients ingredient)
  {
    switch (ingredient)
    {
      case Ingredients.Ingredients.WheatFlour:
        return new WheatFlour();

      case Ingredients.Ingredients.CoconutFlour:
        return new CoconutFlour();

      case Ingredients.Ingredients.Butter:
        return new Butter();

      case Ingredients.Ingredients.Chocolate:
        return new Chocolate();

      case Ingredients.Ingredients.Sugar:
        return new Sugar();

      case Ingredients.Ingredients.Cardamon:
        return new Cardamon();

      case Ingredients.Ingredients.Cinnamon:
        return new Cinnamon();

      case Ingredients.Ingredients.CocoaPowder:
        return new CocoaPowder();
      default:
        return null;
    }
  }
}
