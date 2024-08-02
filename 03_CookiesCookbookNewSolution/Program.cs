// It is always a great idea to begin a project with creating the interface of how the project may function. It's much more difficult
// to create a solid and understandable interface than it is to create the details, so spend time at the beginning of each project
// mapping out all the classes, methods, folders, etc., of the project before you jump into coding the details.


var cookiesRecipeApp = new CookiesRecipeApp();
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
  private readonly RecipesRepository _recipesRepository;
  // This object will handle all the user interaction.
  private readonly IRecipesUserInteraction _recipesUserInteraction;

  public CookiesRecipeApp(
    RecipesRepository recipesRepository,
    RecipesConsoleUserInteraction recipesConsoleUserInteraction
  )
  {
    _recipesRepository = recipesRepository;
    _recipesUserInteraction = recipesConsoleUserInteraction;
  }


  public void Run()
  {
    var allRecipes = _recipesRepository.Read(filePath);
    _recipesUserInteraction.PrintExistingRecipes(allRecipes);

    _recipesUserInteraction.PromptToCreateRecipe();

    var ingredients = _recipesConsoleUserInteraction.ReadIngredientsFromUser();

    if (ingredients.Count > 0)
    {
      var recipes = new Recipe(ingredients);
      allRecipes.Add(recipes);
      _recipesRepository.Write(filePath, allRecipes);
      _recipesConsoleUserInteraction.ShowMessage("Recipe added:");
      _recipesConsoleUserInteraction.ShowMessage(recipe.ToString());
    }
    else
    {
      _recipesConsoleUserInteraction.ShowMessage(
        "No ingredients have been selected. " +
        "Recipe will not be saved.");
    }

    _recipesConsoleUserInteraction.Exit();
  }
}

internal interface IRecipesUserInteraction
{
  public void ShowMessage(string message);
  public void Exit();
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

public class RecipesRepository
{
}