using System.Text.Json;

public static class FileManipulator
{
  public static void WriteToFile(List<Ingredient> ingredients, FileType fileType, bool firstWrite)
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

    System.Console.WriteLine("TEXT BEING WRITTEN: " + toWriteToFileString);
    if (firstWrite == false) toWriteToFileString = Environment.NewLine + toWriteToFileString;
    File.AppendAllText($"Recipes.{fileType}", toWriteToFileString);
  }

  public static void ReadFromFile(string file)
  {
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
        Ingredient newIng = enmumCov.GetIngredient((Ingredients)result - 1);
        System.Console.WriteLine($"{newIng.Name}. {newIng.PreparationInstructions}");
      }
      System.Console.WriteLine();
    }

  }
}
