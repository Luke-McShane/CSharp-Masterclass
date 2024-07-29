// See https://aka.ms/new-console-template for more information
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography;
using System.Text.Json;

var newline = Environment.NewLine;

Console.WriteLine("Create a new cookie recipe! Available ingredients are:");
Console.WriteLine(@$"1. Wheat flour{newline}2. Cocounut flour{newline}3. Butter{newline}4. Chocolate 
5. Sugar{newline}6. Cardamon{newline}7. Cinnamon{newline}8. Cocoa powder");
Recipe.Create();

public static class Recipe
{
  private const FileType fileType = FileType.Json;

  public static void Create()
  {
    bool addIngredients = true;

    Ingredients ingredient;
    Ingredient toBeAdded;

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
          case Ingredients.Wheat_flour:
            toBeAdded = new WheatFlour();
            FileManipulator.WriteToFile(toBeAdded, fileType);
            break;

          case Ingredients.Coconut_flour:
            toBeAdded = new CoconutFlour();
            FileManipulator.WriteToFile(toBeAdded, fileType);
            break;

          case Ingredients.Butter:
            toBeAdded = new Butter();
            FileManipulator.WriteToFile(toBeAdded, fileType);
            break;

          case Ingredients.Chocolate:
            toBeAdded = new Chocolate();
            FileManipulator.WriteToFile(toBeAdded, fileType);
            break;

          case Ingredients.Sugar:
            toBeAdded = new Sugar();
            FileManipulator.WriteToFile(toBeAdded, fileType);
            break;

          case Ingredients.Cardamon:
            toBeAdded = new Cardamon();
            FileManipulator.WriteToFile(toBeAdded, fileType);
            break;

          case Ingredients.Cinnamon:
            toBeAdded = new Cinnamon();
            FileManipulator.WriteToFile(toBeAdded, fileType);
            break;

          case Ingredients.Cocoa_powder:
            toBeAdded = new CocoaPowder();
            FileManipulator.WriteToFile(toBeAdded, fileType);
            break;

          default:
            break;
        }

      }
      else { addIngredients = false; }
    } while (addIngredients);
  }
}

public static class FileManipulator
{
  public static void WriteToFile(Ingredient ingredient, FileType fileType)
  {
    System.Console.WriteLine(ingredient.Id);
    System.Console.WriteLine(ingredient.Name);
    System.Console.WriteLine(ingredient.PreparationInstructions);
    var asJson = JsonSerializer.Serialize(ingredient);
    System.Console.WriteLine("As JSON: " + asJson);
  }

  public static void ReadFromFile()
  {

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
  Wheat_flour,
  Coconut_flour,
  Butter,
  Chocolate,
  Sugar,
  Cardamon,
  Cinnamon,
  Cocoa_powder
}

public enum FileType
{
  Txt,
  Json
}
