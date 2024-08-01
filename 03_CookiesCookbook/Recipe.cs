// Each ingredient has its own namespace nested within the general 'Ingredients' namespace, which contains the interface IIngredient and the enum Ingredients
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

// This is the class that we will use to take user input and convert it into an Ingredient to be eventually written to file.
public static class Recipe
{
  // Create the recepe through prompting user input and creating a list of ingredients, then to be written to file.
  public static void Create()
  {
    // As soon as the user enters an invalid input, this bool is changed to false.
    bool addIngredients = true;

    // Value which will contain the enum value of the ingredient.
    Ingredients.Ingredients ingredient;
    // List to contain all ingredients the user would like in their recipe.
    List<IIngredient> ingredients = new List<IIngredient>();

    // Present all extant files to the user before prompting them to create their own recipe.
    FileManipulator.ReadFromFile();

    // The use of the do-while loop ensures we can prompt the user at least once for an input.
    do
    {
      Console.WriteLine("Add an ingredient by its ID or type anything else if finished.");
      string? input = Console.ReadLine();
      System.Console.WriteLine("Input: " + input);
      // Try and parse user input as an int and, if possible, store that in value in the newly created 'result' variable.
      if (int.TryParse(input, out int result))
      {
        if (result <= 8 && result >= 1)
        {
          ingredient = (Ingredients.Ingredients)result - 1;
          System.Console.WriteLine("Ingredient: " + ingredient);
          ingredients.Add(CreateIngredient(ingredient));
        }
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
