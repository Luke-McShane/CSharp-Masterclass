public class BaseClass
{
  public virtual void Method1()
  {
    System.Console.WriteLine("Base - Method 1");
  }

  public void Method2()
  {
    System.Console.WriteLine("Base - Method 2");
  }
}

public class DerivedClass : BaseClass
{
  public override void Method1()
  {
    System.Console.WriteLine("Derived - Method 1");
  }

  public new void Method2()
  {
    System.Console.WriteLine("Derived - Method 2");
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
    dc.Method1();
    dc.Method2();
    bcdc.Method1();
    bcdc.Method2();
  }
}

// When a method is called on some specific type (Baseclass in bcdc, for example), the C# engine first checks if this method is virtual. 
// If not, it simply calls the method it finds in the type of the variable. So for bcdc, because it is of type BaseClass and Method1 
// is not virtual, it will simply call this method because it is not expecting it to be overridden.
// If it does find that the method is virtual, then it will check the actual type (DerivedClass for bcdc) for the overriding method, and
// call this if it does indeed override the inherited method for the generic type. If no overriding method is found (the 'override' keyword
// MUST be used - having a method named the same will not suffice) then the virtual method will be called.