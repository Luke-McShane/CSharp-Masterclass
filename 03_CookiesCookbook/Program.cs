var newline = Environment.NewLine;
Console.WriteLine("Create a new cookie recipe! Available ingredients are:");
Console.WriteLine(@$"1. Wheat flour{newline}2. Cocounut flour{newline}3. Butter{newline}4. Chocolate 
5. Sugar{newline}6. Cardamon{newline}7. Cinnamon{newline}8. Cocoa powder");
Recipe.Create();

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
        switch (ingredient)
        {
          case Ingredients.WheatFlour:
            toBeAdded = new WheatFlour();
            ingredients.Add(new WheatFlour());
            break;

          case Ingredients.CoconutFlour:
            toBeAdded = new CoconutFlour();
            ingredients.Add(new CoconutFlour());
            break;

          case Ingredients.Butter:
            toBeAdded = new Butter();
            ingredients.Add(new Butter());
            break;

          case Ingredients.Chocolate:
            toBeAdded = new Chocolate();
            ingredients.Add(new Chocolate());
            break;

          case Ingredients.Sugar:
            toBeAdded = new Sugar();
            ingredients.Add(new Sugar());
            break;

          case Ingredients.Cardamon:
            toBeAdded = new Cardamon();
            ingredients.Add(new Cardamon());
            break;

          case Ingredients.Cinnamon:
            toBeAdded = new Cinnamon();
            ingredients.Add(new Cinnamon());
            break;

          case Ingredients.CocoaPowder:
            toBeAdded = new CocoaPowder();
            ingredients.Add(new CocoaPowder());
            break;

          default:
            break;
        }

      }
      else { addIngredients = false; }
    } while (addIngredients);
    if (ingredients.Count >= 1)
    {
      FileManipulator.WriteToFile(ingredients, fileType, firstWrite);
    }
  }
}



public enum FileType
{
  txt,
  json
}
