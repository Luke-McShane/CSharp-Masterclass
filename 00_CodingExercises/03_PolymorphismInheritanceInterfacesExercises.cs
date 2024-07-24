using System.Runtime.ConstrainedExecution;

public class PolymorphismInheritanceInterfacesExerices
{
  public static void Entry()
  {

    // If we did not add the abstract method Prepare in the abstract Ingredient class, and we only added the Prepare method manually in
    // each derived class, then the foreach loop below would not work as each variable is of type ingredient, and there would be no Prepare
    // method to be found. But since we make add it as an abstract method, the compiler knows to check the relevant derive type for the definition.
    List<Ingredient> ingredients = new List<Ingredient>
    {
      new Cheddar(1, 12),
      new Mozzarella(2),
      new Tomato(1, 100)
    };

    foreach (Ingredient ingredientItem in ingredients)
    {
      ingredientItem.Prepare();
    }

    // This is called upcasting, which is what happens when we assign an object of a derived type to a base type.
    // Downcasting is when we assign an object of a base type to a derived type.
    Ingredient cheddar = new Cheddar(12, 1);
    System.Console.WriteLine(cheddar);

    // Using the 'is' operator to return a boolean after evaluating a condition.
    System.Console.WriteLine("is object? " + (cheddar is object));
    System.Console.WriteLine("is object? " + (cheddar is Ingredient));
    System.Console.WriteLine("is object? " + (cheddar is Cheddar));
    System.Console.WriteLine("is object? " + (cheddar is Mozzarella));
    System.Console.WriteLine("is object? " + (cheddar is Tomato));


    Ingredient ingredient = new Cheddar(1);
    // Here we are downcasting, which is converting a base type to a derived type, which is created here.
    // This statement is saying "If the ingredient variable is of type Cheddar, then enter the if statement
    // creating a Cheddar object called cheddar1. This object will only be accessible within this statement.
    // We could explicitly cast this instead by saying: "Cheddar cheddar1 = (Cheddar)ingredient;"
    if (ingredient is Cheddar cheddar1)
    {
      System.Console.WriteLine("Ingredient is cheddar: " + cheddar1);
    }

    Cheddar cheddar2 = (Cheddar)ingredient; // If this conversion fails we will get a runtime error
    Cheddar cheddar3 = ingredient as Cheddar; // If this conversion fails the value will be null, so is safer.
                                              // Because of this we can only use the 'as' operator to cast to nullable types.

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
public abstract class Ingredient
// The 'abstract' modifier makes it so the class cannot be instantiated. They only serve as base classes for other more concrete types.
{
  public virtual string Name { get; init; } = "Some ingredient";

  public Ingredient(int priceIfExtraTopping)
  {
    PriceIfExtraTopping = priceIfExtraTopping;
  }

  public override string ToString() => Name;

  public int PriceIfExtraTopping { get; }

  // An abstract method *MUST* be overriden in the derived classes - it is not optional like a virtual method might be.
  // And because the class it belongs to is abstract, it means this method specifically will never be directly called as
  // we will never have an Ingredient object, and so we can leave the definition of the method blank.
  // All abstract methods are therefore implicitly virtual.
  public abstract void Prepare();

  public string PublicMethod() => "This is a PUBLIC method meaning all derived classes and non-derived classes can access it.";
  private string PrivateMethod() => "This is a PRIVATE method meaning it can only be access within the base class, i.e. this class.";
  protected string ProtectedMethod() => "This is a PROTECTED method meaning it can be accessed within the base *and* derived classes.";
}

// We can skip overriding the 'Prepare' abstract method in the Cheese class because this class is abstract, meaning that it will never
// be instantiated.
public abstract class Cheese : Ingredient
{
  public Cheese(int priceIfExtraTopping) : base(priceIfExtraTopping)
  {
  }
}

class Tomato : Ingredient
{
  public int NumberIn100Grams { get; init; }
  public Tomato(int priceIfExtraTopping) : base(priceIfExtraTopping)
  {
  }

  public Tomato(int tomatoes, int priceIfExtraTopping) : base(priceIfExtraTopping)
  {
    NumberIn100Grams = tomatoes;
  }
  public override string Name => $"{base.Name}, more specifically, a tomato sauce, with {NumberIn100Grams} tomatoes per 100grams.";

  public override void Prepare()
  {
    throw new NotImplementedException();
  }
}

class Cheddar : Cheese
{
  public Cheddar(int priceIfExtraTopping) : base(priceIfExtraTopping)
  {
  }

  public Cheddar(int agedForMonths, int priceIfExtraTopping) : base(priceIfExtraTopping)
  {
    AgedForMonths = agedForMonths;
  }

  public int AgedForMonths { get; }
  public override string Name => $"{base.Name}, more specifically, a cheddar cheese, aged for {AgedForMonths} months.";

  public override void Prepare()
  {
    throw new NotImplementedException();
  }
}

// Sealing a class means that we cannot derive from this class. So if we wanted to create a new class that inherits from Mozzarella, we
// would no longer be able to do it. This is mainly used by coders for design purposes and to show the coders intention. Classes should not
// be sealed unless we are absolutely certain that we know what we are doing.
// Methods or properties that override virtual methods or properties may also be overridden to prevent classes that inherit from this class
// to override those sealed methods or properties. Sealing a method or property makes it explicit that the overriding stops there.
sealed class Mozzarella : Cheese
{
  // public string Name => "Mozzarella";
  public bool IsLight { get; }

  public Mozzarella(int priceIfExtraTopping) : base(priceIfExtraTopping)
  {
  }
  public override string Name => $"{base.Name}, more specifically, a mozzarella cheese.";

  public override void Prepare()
  {
    throw new NotImplementedException();
  }
}

/*
VIRTUAL vs ABSTRACT Methods
- Virtual methods must have an implementation, and may or may not be overriden.
- Abstract methods cannot have an implementation, and must be overrident.
*/

/*
Static classes are automatically sealed because they can only contain statid methods, and static methods are sealed because they cannot be
overridden, and this is because overriding is used when we want a specific implementation of a method on a specific instance.
So, for example, we could have various Ingredient types that hold Mozzarella, Cheddar, and Tomato variables, and we would want the base
field Name to be virtual and overridden as we want to have more specific data when creating instances of derived classes.
*/