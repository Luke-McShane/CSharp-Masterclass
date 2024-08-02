// It is always a great idea to begin a project with creating the interface of how the project may function. It's much more difficult
// to create a solid and understandable interface than it is to create the details, so spend time at the beginning of each project
// mapping out all the classes, methods, folders, etc., of the project before you jump into coding the details.


var cookiesRecipeApp = new CookiesRecipeApp(
  new RecipesRepository(),
  new RecipesConsoleUserInteraction());
cookiesRecipeApp.Run();

// Coupling is the amount of interdependence between classes, a measure of how closely they are connected.
// It is an undesirable trait to have because it reduces usability of classes if the requirements of the program change.
// This is due to how the class we may want to change is depended/dependent on another class.

// This brings us nicely into the 'D' principle of the 'SOLID' principles: The Dependency Inversion Principle.
// This states that higher level should not depend on lower level modules; instead. both should depend on abstraction.
// Higher level modules should not know much about lower level modules, and vice versa, as a simple change to a lower
// level module could break a higher level module, which would mean the modules are couples. The looser the coupling, the better.
public class CookiesRecipeApp
{

  // We want to have instaces of these two other classes here to separate responsibilities. We don't want to have any direct user interaction
  // or reading or writing to text files within this class because that would break the Single Responsibility Principle.
  // This object will handle all the reading and writing to the text files.
  private readonly IRecipesRepository _recipesRepository;
  // This object will handle all the user interaction.
  private readonly IRecipesUserInteraction _recipesUserInteraction;

  // Dependency Injection: The class is given the dependencies it needs; it doesn't create them itself.
  // Here we are shown some dependencies passed (injected) into the constructor, which is an example of constructor dependency injection,
  // as opposed to creating all the dependencies by hard coding them in the class.
  public CookiesRecipeApp(
    IRecipesRepository recipesRepository,
    IRecipesUserInteraction recipesUserInteraction
  )
  {
    _recipesRepository = recipesRepository;
    _recipesUserInteraction = recipesUserInteraction;
  }


  public void Run()
  {
    var allRecipes = _recipesRepository.Read(filePath);
    _recipesUserInteraction.PrintExistingRecipes(allRecipes);

    _recipesUserInteraction.PromptToCreateRecipe();

    var ingredients = _recipesUserInteraction.ReadIngredientsFromUser();

    if (ingredients.Count > 0)
    {
      var recipes = new Recipe(ingredients);
      allRecipes.Add(recipes);
      _recipesRepository.Write(filePath, allRecipes);
      _recipesUserInteraction.ShowMessage("Recipe added:");
      _recipesUserInteraction.ShowMessage(recipe.ToString());
    }
    else
    {
      _recipesUserInteraction.ShowMessage(
        "No ingredients have been selected. " +
        "Recipe will not be saved.");
    }

    _recipesUserInteraction.Exit();
  }
}

public interface IRecipesUserInteraction
{
  public void ShowMessage(string message);
  public void Exit();
  object ReadIngredientsFromUser();
  void PrintExistingRecipes(object allRecipes);
  void PromptToCreateRecipe();
}

public class RecipesConsoleUserInteraction : IRecipesUserInteraction
{
  public void ShowMessage(string message)
  {
    Console.WriteLine(message);
  }
  public void Exit()
  {
    Console.WriteLine("Press any key to close.");
    Console.ReadKey();
  }
}

public interface IRecipesRepository
{
  object Read(object filePath);
}

public class RecipesRepository : IRecipesRepository
{
}