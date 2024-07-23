using System.Runtime.ConstrainedExecution;

public class PolymorphismInheritanceInterfacesExerices
{
  public static void Entry()
  {
    Pizza pizza = new Pizza();
    pizza.AddIngredients(new Tomato(1));
    pizza.AddIngredients(new Cheddar(1));
    pizza.AddIngredients(new Mozzarella(2));

    System.Console.WriteLine(pizza.Describe());

    // System.Console.WriteLine(pizza.Describe());

    // Here we can see that the Name value for the object of type Cheddar (as opposed to type ingredient) has overrident the inherited Name
    // property of the object of type Ingredient.
    // Cheddar cheddar = new Cheddar();
    // Ingredient ingredient = new Cheddar();

    // System.Console.WriteLine(cheddar.Name);
    // System.Console.WriteLine(ingredient.Name);

    // The below code doesn't work because the 'ingredient' object is of type ingredient, and the AgedForMonths property exists only in the
    // cheddar class. Although we can create the ingredient (because it inherits from Ingredient), we cannot access Cheddar-specific members.
    //int agedForMonths = ingredient.AgedForMonths;
  }
}

public class Pizza
{
  private List<Ingredient> _ingredients = new List<Ingredient>();
  public string Describe() => $"This is a pizza with {string.Join(", ", _ingredients)}";

  public void AddIngredients(Ingredient ingredient) => _ingredients.Add(ingredient);
}

// Polymorphism is the provision of a single interface to entities different types.
// There is a generic concept of something (Ingredient), and this concept can be made concrete by various types (Cheddar Mozzerella, Tomatoes).
// All of these concrete types can be used wherever the generic concept is needed (in the ingredients list).
// Inheritence enables us to create new classes that reuse, extend, and modify the behaviour defined in other classes.
// The base class is the class whose members are inherited. The derived classes are those that inherit these members.
public class Ingredient
{
  public string Name { get; init; } = "Some ingredient";

  public Ingredient(int priceIfExtraTopping)
  {
    PriceIfExtraTopping = priceIfExtraTopping;
  }

  public override string ToString() => Name;

  public int PriceIfExtraTopping { get; }

  public string PublicMethod() => "This is a PUBLIC method meaning all derived classes and non-derived classes can access it.";
  private string PrivateMethod() => "This is a PRIVATE method meaning it can only be access within the base class, i.e. this class.";
  protected string ProtectedMethod() => "This is a PROTECTED method meaning it can be accessed within the base *and* derived classes.";
}

public class Cheese : Ingredient
{
  public Cheese(int priceIfExtraTopping) : base(priceIfExtraTopping)
  {
  }
}

class Tomato : Ingredient
{
  // public string Name => "Tomato Sauce";
  public int NumberIn100Grams { get; init; }
  public Tomato(int priceIfExtraTopping) : base(priceIfExtraTopping)
  {
    Name = "Tomato Sauce";
  }

  public Tomato(string name, int tomatoes, int priceIfExtraTopping) : base(priceIfExtraTopping)
  {
    Name = name;
    NumberIn100Grams = tomatoes;
  }
}

class Cheddar : Cheese
{
  public Cheddar(int priceIfExtraTopping) : base(priceIfExtraTopping)
  {
    Name = "Cheddar Cheese";
  }

  public int AgedForMonths { get; }
}

class Mozzarella : Cheese
{
  // public string Name => "Mozzarella";
  public bool IsLight { get; }

  public Mozzarella(int priceIfExtraTopping) : base(priceIfExtraTopping)
  {
    Name = "Mozzarella Cheese";
  }
}