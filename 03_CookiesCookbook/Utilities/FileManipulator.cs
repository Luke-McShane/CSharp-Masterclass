using System.Text.Json;
using Ingredients;

namespace Utilities;

// A class used for reading to and writing from files.
public static class FileManipulator
{
  // We can change this const at any point outside of compilation to change the target file.
  private const FileType fileType = FileType.json;
  static string recipesFile = $@"C:\Users\admin\Projects\CSharpMasterclass\03_CookiesCookbook\Recipes.{fileType}";
  private static bool firstWrite = true;

  // Takes the list of ingredients to be written, iterates through them, and writes them to a file after creating a string containing them.
  public static void WriteToFile(List<IIngredient> ingredients)
  {
    // Create an array to house all the ids of the ingredients.
    int[] toWriteToFileArr = new int[ingredients.Count];
    // Create a string that will house the final recipe to be written.
    string toWriteToFileString = "";
    // Iterate through the ingredients and add the ids to the array.
    for (int i = 0; i < ingredients.Count; ++i)
    {
      IIngredient ingredient = ingredients[i];

      toWriteToFileArr[i] = ingredient.Id;
    }
    // Check the file type and formate the string container appropriately.
    toWriteToFileString = fileType == FileType.json
                        ? toWriteToFileString + JsonSerializer.Serialize(toWriteToFileArr)
                        : toWriteToFileString += string.Join(",", toWriteToFileArr);

    // If we have written to the file before, add a newline so our recipe sits beneath the previous one.
    if (firstWrite == false) toWriteToFileString = Environment.NewLine + toWriteToFileString;
    File.AppendAllText($"Recipes.{fileType}", toWriteToFileString);
  }

  public static void ReadFromFile()
  {
    // If no file exists, return.
    if (!File.Exists(recipesFile))
    {
      return;
    }
    // Create a series of variables, including a Read Ingredients object that we will use to determine which ingredients to print.
    firstWrite = false;
    IIngredient? currentIngredient;
    ReadIngredients readIngredients = new();
    // Create a string array containing all lines read from the file.
    string[] lines = File.ReadAllLines(recipesFile);
    for (int i = 0; i < lines.Length; ++i)
    {
      // Iterate through the current line, printing information of the relevant ingredient by creating an object of the appropriate type
      // and printing its Name and PreparationInstructions to the console.
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