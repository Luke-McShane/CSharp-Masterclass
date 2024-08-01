using System.Text.Json;
using Ingredients;
using Ingredients.Cardamon;
using Ingredients.Chocolate;
using Ingredients.Cinnamon;
using Ingredients.CocoaPowder;
using Ingredients.CoconutFlour;
using Ingredients.Sugar;
using Ingredients.WheatFlour;

namespace Utilities;
public static class FileManipulator
{
  private const FileType fileType = FileType.json;
  static string recipesFile = $@"C:\Users\admin\Projects\CSharpMasterclass\03_CookiesCookbook\Recipes.{fileType}";
  private static bool firstWrite = true;
  public static void WriteToFile(List<Ingredient> ingredients)
  {
    int[] toWriteToFileArr = new int[ingredients.Count];
    System.Console.WriteLine(toWriteToFileArr.Length);
    string toWriteToFileString = "";
    for (int i = 0; i < ingredients.Count; ++i)
    {
      Ingredient ingredient = ingredients[i];

      toWriteToFileArr[i] = ingredient.Id;
    }
    toWriteToFileString = fileType == FileType.json
                        ? toWriteToFileString + JsonSerializer.Serialize(toWriteToFileArr)
                        : toWriteToFileString += string.Join(",", toWriteToFileArr);

    if (firstWrite == false) toWriteToFileString = Environment.NewLine + toWriteToFileString;
    File.AppendAllText($"Recipes.{fileType}", toWriteToFileString);
  }

  public static void ReadFromFile()
  {
    if (!File.Exists(recipesFile))
    {
      return;
    }
    firstWrite = false;
    Ingredient? currentIngredient;
    var readIngredients = new ReadIngredients();
    string[] lines = File.ReadAllLines(recipesFile);
    for (int i = 0; i < lines.Length; ++i)
    {
      System.Console.WriteLine($"*****{i + 1}*****");
      string line = lines[i];
      string[] ingredients = line.Trim('[', ']').Split(',');
      foreach (string ingredient in ingredients)
      {
        currentIngredient = readIngredients.GetAllIngredients(ingredient);
        Console.WriteLine(currentIngredient.Name);
        Console.WriteLine(currentIngredient.PreparationInstructions);
      }
      Console.WriteLine();
    }

  }
}

public enum FileType
{
  txt,
  json
}


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