// using Ingredients;
namespace Ingredients;
public class CreateObjectFromEnum
{
  public Ingredient? GetIngredient(Ingredients ingredient)
  {
    // Assembly a = Assembly.Load("Ingredients");
    // string aqn = typeof(Ingredients.Ingredients).AssemblyQualifiedName;
    // var ns = typeof(Ingredients.Ingredients).Namespace; //or your classes namespace if different
    // var typeName = ns + "." + ingredient.ToString();

    System.Console.WriteLine("Ingredient: " + ingredient);
    System.Console.WriteLine("Ingredient as String: " + ingredient.ToString());
    System.Console.WriteLine("Ingredient type: " + Type.GetType(ingredient.ToString()));

    return (Ingredient?)Activator.CreateInstance(Type.GetType(ingredient.ToString()));
    // return (Ingredient?)Activator.CreateInstance(Type.GetType(typeName));
  }
}

