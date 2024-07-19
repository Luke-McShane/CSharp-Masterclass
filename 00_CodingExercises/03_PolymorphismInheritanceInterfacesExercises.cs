public class PolymorphismInheritanceInterfacesExerices
{
  public static void Entry()
  {
    Pizza pizza = new Pizza();
    pizza.AddIngredients(new Tomato());
    pizza.AddIngredients(new Cheddar());
    pizza.AddIngredients(new Mozzarella());
  }
}

public class Pizza
{

  private List<Ingredient> _ingredients = new List<Ingredient>();
  public string Describe() => $"This is a pizza with  {string.Join(",", _ingredients)}";

  public void AddIngredients(Ingredient ingredient) => _ingredients.Add(ingredient);
}

// Polymorphism is the provision of a single interface to entities different types.
// There is a generic concept of something (Ingredient), and this concept can be made concrete by various types (Cheddar Mozzerella, Tomatoes).
// All of these concrete types can be used wherever the generic concept is needed (in the ingredients list).
// Inheritence enables us to create new classes that reuse, extend, and modify the behaviour defined in other classes.
// The base class is the class whose members are inherited. The derived classes are those that inherit these members.
public class Ingredient
{
  public string PublicMethod() => "This is a PUBLIC method meaning all derived classes and non-derived classes can access it.";
  private string PrivateMethod() => "This is a PRIVATE method meaning it can only be access within the base class, i.e. this class.";
  protected string ProtectedMethod() => "This is a PROTECTED method meaning it can be accessed within the base *and* derived classes.";
}

class Tomato : Ingredient
{
  // public string Name => "Tomato Sauce";
  public int NumberIn100Grams { get; init}
  public Tomato() { }

  public Tomato(string name, int tomatoes)
  {
    Name = name;
    NumberIn100Grams = tomatoes;
  }
}

class Cheddar : Ingredient
{
  // public string Name => "Cheddar Cheese";
  public int AgedForMonths { get; }
}

class Mozzarella : Ingredient
{
  // public string Name => "Mozzarella";
  public bool IsLight { get; }
}