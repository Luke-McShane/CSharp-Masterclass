// See https://aka.ms/new-console-template for more information
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;

var newline = Environment.NewLine;

Console.WriteLine("Create a new cookie recipe! Available ingredients are:");
Console.WriteLine(@$"1. Wheat flour{newline}2. Cocounut flour{newline}3. Butter{newline}4. Chocolate 
5. Sugar{newline}6. Cardamon{newline}7. Cinnamon{newline}8. Cocoa powder");

Recipe.Create();

public static class Recipe
{
  private const FileType fileType = FileType.txt;


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
      FileManipulator.WriteToFile(ingredients, fileType);
    }
  }
}

public class CreateObjectFromEnum
{
  public Ingredient? GetIngredient(Ingredients ingredient)
  {
    return (Ingredient?)Activator.CreateInstance(Type.GetType(ingredient.ToString()));
  }
}

public static class FileManipulator
{
  public static void WriteToFile(List<Ingredient> ingredients, FileType fileType)
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
                        : toWriteToFileString += toWriteToFileArr;

    File.AppendAllText($"Recipes.{fileType}", Environment.NewLine + toWriteToFileString);
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

public abstract class Ingredient
{
  public abstract int Id { get; }
  public abstract string Name { get; }
  public abstract string PreparationInstructions { get; }

}

public class WheatFlour : Ingredient
{
  public override int Id { get => 1; }
  public override string Name { get => "Wheat flour"; }
  public override string PreparationInstructions { get => "Sieve. Add to other ingredients."; }
}

public class CoconutFlour : Ingredient
{
  public override int Id { get => 2; }
  public override string Name { get => "Coconut flour"; }
  public override string PreparationInstructions { get => "Sieve. Add to other ingredients."; }
}
public class Butter : Ingredient
{
  public override int Id { get => 3; }
  public override string Name { get => "Butter"; }
  public override string PreparationInstructions { get => "Melt on low heat. Add to other ingredients."; }
}
public class Chocolate : Ingredient
{
  public override int Id { get => 4; }
  public override string Name { get => "Chocolate"; }
  public override string PreparationInstructions { get => "Melt in a water bath. Add to other ingredients."; }
}
public class Sugar : Ingredient
{
  public override int Id { get => 5; }
  public override string Name { get => "Sugar"; }
  public override string PreparationInstructions { get => "Add to other ingredients."; }
}
public class Cardamon : Ingredient
{
  public override int Id { get => 6; }
  public override string Name { get => "Cardamon"; }
  public override string PreparationInstructions { get => "Take half a teaspoon. Add to other ingredients."; }
}
public class Cinnamon : Ingredient
{
  public override int Id { get => 7; }
  public override string Name { get => "Cinnamon"; }
  public override string PreparationInstructions { get => "Take half a teaspoon. Add to other ingredients."; }
}
public class CocoaPowder : Ingredient
{
  public override int Id { get => 8; }
  public override string Name { get => "Cocoa powder"; }
  public override string PreparationInstructions { get => "Add to other ingredients."; }
}

public enum Ingredients
{
  WheatFlour,
  CoconutFlour,
  Butter,
  Chocolate,
  Sugar,
  Cardamon,
  Cinnamon,
  CocoaPowder
}

public enum FileType
{
  txt,
  json
}
