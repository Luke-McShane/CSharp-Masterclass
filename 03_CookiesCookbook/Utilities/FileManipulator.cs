using System.Text.Json;
using Ingredients;

namespace Utilities;
public static class FileManipulator
{
  private const FileType fileType = FileType.json;
  static string recipesFile = $"Recipes.{fileType}";
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
    int result;
    string[] lines = File.ReadAllLines(file);
    for (int i = 0; i < lines.Length; ++i)
    {
      System.Console.WriteLine($"*****{i + 1}*****");
      string line = lines[i];
      string[] ingredients = line.Trim('[', ']').Split(',');
      foreach (string ingredient in ingredients)
      {
        var enmumCov = new CreateObjectFromEnum();
        bool whichIngredient = int.TryParse(ingredient, out result);
        Ingredient newIng = enmumCov.GetIngredient((Ingredients.Ingredients)result - 1);
        Console.WriteLine($"{newIng.Name}. {newIng.PreparationInstructions}");
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