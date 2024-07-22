using System.Data;
using Microsoft.VisualBasic;

public class BaseClass
{
  public static int X { get; } = 55;
  public virtual void Method1()
  {
    System.Console.WriteLine("Base - Method 1");
  }

  public virtual void Method2()
  {
    System.Console.WriteLine("Base - Method 2");
  }

  public void Method3()
  {
    System.Console.WriteLine("Base - Method 3");
  }
}

public class DerivedClass : BaseClass
{
  // The new keyword makes the compiler aware that this is a new instance of the X variable, and hides the original definition.
  public new static int X { get; } = 100;
  public override void Method1()
  {
    System.Console.WriteLine("Derived - Method 1");
  }

  public void Method2()
  {
    System.Console.WriteLine("Derived - Method 2");
  }

  public new void Method3()
  {
    System.Console.WriteLine("Derived - Method 3");
  }

  public void WriteX()
  {
    // Here we can access the definition of X as defined in the derived class (100), using the new keyword. We can also access the
    // inherited definition of X, but we must specify this by referencing the base class.
    System.Console.WriteLine(X);
    System.Console.WriteLine(BaseClass.X);
  }
}

public static class PolymorphismPractise
{
  public static void Entry()
  {
    BaseClass bc = new BaseClass();
    DerivedClass dc = new DerivedClass();
    BaseClass bcdc = new DerivedClass();

    bc.Method1();
    bc.Method2();
    bc.Method3();

    System.Console.WriteLine();

    dc.Method1();
    dc.Method2();
    dc.Method3();
    dc.WriteX();

    System.Console.WriteLine();

    // The inherited class has two virtual methods, but since the derived class only has one overriden method, only this method will be run from
    // the derived class.
    bcdc.Method1();
    bcdc.Method2();
    bcdc.Method3();
  }
}

// When a method is called on some specific type (Baseclass in bcdc, for example), the C# engine first checks if this method is virtual. 
// If not, it simply calls the method it finds in the type of the variable. So for bcdc, because it is of type BaseClass and Method1 
// is not virtual, it will simply call this method because it is not expecting it to be overridden.
// If it does find that the method is virtual, then it will check the actual type (DerivedClass for bcdc) for the overriding method, and
// call this if it does indeed override the inherited method for the generic type. If no overriding method is found (the 'override' keyword
// MUST be used - having a method named the same will not suffice) then the virtual method will be called.