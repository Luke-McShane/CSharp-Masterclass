// See https://aka.ms/new-console-template for more information
using System.Globalization;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography;

var newline = Environment.NewLine;

Console.WriteLine("Create a new cookie recipe! Available ingredients are:");
Console.WriteLine(@$"1. Wheat flour{newline}2. Cocounut flour{newline}3. Butter{newline}4. Chocolate 
                     5. Sugar{newline}6. Cardamon{newline}7. Cinnamon{newline}8. Cocoa powder");


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


public class Recipe
{

  public void Create()
  {
    bool addIngredients = true;
    Ingredients ingredient;
    do
    {
      Console.WriteLine("Add an ingredient by its ID or type anything else if finished.");
      var input = Console.ReadKey().ToString();
      if (int.TryParse(input, out int result) && result <= 8 && result >= 1)
      {
        ingredient = (Ingredients)result - 1;
      }
    } while (addIngredients);
  }
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
