using System.Text.Json;
using Ingredients;

namespace Utilities;
public static class FileManipulator
{
  private const FileType fileType = FileType.json;
  static string recipesFile = $@"C:\Users\admin\Projects\CSharpMasterclass\03_CookiesCookbook\Recipes.{fileType}";
  private static bool firstWrite = true;
  public static void WriteToFile(List<IIngredient> ingredients)
  {
    int[] toWriteToFileArr = new int[ingredients.Count];
    System.Console.WriteLine(toWriteToFileArr.Length);
    string toWriteToFileString = "";
    for (int i = 0; i < ingredients.Count; ++i)
    {
      IIngredient ingredient = ingredients[i];

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
    IIngredient? currentIngredient;
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
        if (currentIngredient is not null)
        {
          Console.WriteLine(currentIngredient.Name);
          Console.WriteLine(currentIngredient.PreparationInstructions + Environment.NewLine);
        }
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




/*
This code is my attempt to dynamically create instances of ingredients based on the value read from
a text file. This worked when all the code was in a single file, but after organising my code this stopped working.
I believe this is something to do with assemblies and dll files, and it felt too comprehensive and difficult
a problem to persist with, so I created a new solution. This can be used for reference, however, as it
is an interesting idea to dynamically create objects based on referencing an enum, I believe.
*/
// var enmumCov = new CreateObjectFromEnum();
// bool flag = int.TryParse(ingredient, out result);
// Ingredients.Ingredients whichIngredient = (Ingredients.Ingredients)(result - 1);
// // IIngredient newIng = Activator.CreateInstance(Type.GetType);
// // var newIng = (IIngredient?)Activator.CreateInstance(((Ingredients.Ingredients)result - 1).GetType());
// // IIngredient newIng = enmumCov.GetIngredient((Ingredients)result - 1);
// // IIngredient newIng = new (nameof())
// // Console.WriteLine($"{newIng.Name}. {newIng.PreparationInstructions}");