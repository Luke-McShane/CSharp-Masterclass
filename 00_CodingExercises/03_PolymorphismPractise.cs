public class BaseClass
{
  public void Method1()
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
  public new void Method1()
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