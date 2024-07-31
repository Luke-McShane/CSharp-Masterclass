public static class Recipe
{
  private const FileType fileType = FileType.json;
  private static bool firstWrite = true;

  public static void Create()
  {
    bool addIngredients = true;
    string recipesFile = $"Recipes.{fileType}";

    Ingredients ingredient;
    Ingredient toBeAdded;
    List<Ingredient> ingredients = new List<Ingredient>();

    if (File.Exists(recipesFile))
    {
      FileManipulator.ReadFromFile(recipesFile);
      firstWrite = false;
    }

    do
    {
      Console.WriteLine("Add an ingredient by its ID or type anything else if finished.");
      string? input = Console.ReadLine();
      System.Console.WriteLine("Input: " + input);
      if (int.TryParse(input, out int result) && result <= 8 && result >= 1)
      {
        ingredient = (Ingredients)result - 1;
        System.Console.WriteLine("Ingredient: " + ingredient);
        ingredients.Add(CreateIngredient(ingredient));
      }
      else { addIngredients = false; }
    } while (addIngredients);

    if (ingredients.Count >= 1)
    {
      FileManipulator.WriteToFile(ingredients, fileType, firstWrite);
    }
  }

  private static Ingredient? CreateIngredient(Ingredients ingredient)
  {
    switch (ingredient)
    {
      case Ingredients.WheatFlour:
        return new WheatFlour();

      case Ingredients.CoconutFlour:
        return new CoconutFlour();

      case Ingredients.Butter:
        return new Butter();

      case Ingredients.Chocolate:
        return new Chocolate();

      case Ingredients.Sugar:
        return new Sugar();

      case Ingredients.Cardamon:
        return new Cardamon();

      case Ingredients.Cinnamon:
        return new Cinnamon();

      case Ingredients.CocoaPowder:
        return new CocoaPowder();
      default:
        return null;
    }
  }
}
