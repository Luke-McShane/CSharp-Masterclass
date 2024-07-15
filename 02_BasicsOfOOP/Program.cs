
var myRec = new Rectangle();
System.Console.WriteLine($"Width: {myRec.Width}\nHeight: {myRec.Height}");
myRec.Width = 3;
myRec.Height = 2;
System.Console.WriteLine($"Width: {myRec.Width}\nHeight: {myRec.Height}");

var appointment = new MedicalAppointment("Dave");
appointment.Reschedule(8, 12);

class Rectangle
{
  // These variables are the fields of the Rectangle class.
  public int Width, Height;
  public Rectangle() { }
  public Rectangle(int w, int h)
  {
    Width = w;
    Height = h;
  }

  // Names of methods should *always* start with a verb.
  // The default access modifier for a field or method is always the *most restrictive* that is valid in a given context.
  public int CalculateArea()
  {
    // An expression is something that evaluates to a value, such as this statment below.
    return Width * Height;

    // A statement is something that does *not* evaluate to a value, such as Console.Writeline("Hello world"); or an if-statement.
  }

  // Above we have a standard method, but we can create an expression-bodied method whenever we have a single line of code in the body.
  // It can only be when we have a single line of code, and we use the '=>' arrow to define an expression-bodied method.
  public int CalculateCircumference() => (Width * Height) * 2;
}



//Here we create a class that prints information from a MedicalAppointment object we pass it.
// We can access the public method GetAppointment from the passed object, as shown below.
class MedicalAppointmentPrinter
{
  public void Print(MedicalAppointment appointment) =>
              Console.WriteLine($"Your appointment will now take place on: {appointment.GetAppointment()}");
}

class MedicalAppointment
{
  private string _patientName;
  private DateTime _date;

  public MedicalAppointment(string patientName, DateTime date)
  {
    _patientName = patientName;
    _date = date;
  }

  // Here we call one constructor from another. The functionality in this constructor says "If the user doesn't give an appointment date,
  // automatically set an appointment one week from now. If there were code in the constructor body, it would be executed after the 
  // second constructor call. The 'this' keyword refers to the current instance of the class (the object).
  public MedicalAppointment(string patientName) : this(patientName, 7)
  {
    // This code below is now redundant because we have overloaded the constructor and passed the appropriate arguments.
    // _patientName = patientName;
    // _date = DateTime.Now.AddDays(7);
  }

  public MedicalAppointment(string patientName, int daysFromNow)
  {
    _patientName = patientName;
    _date = DateTime.Now.AddDays(daysFromNow);
    System.Console.WriteLine($"Date of appointment: {_date}. Name: {_patientName}");
  }

  public DateTime GetAppointment() => _date;

  // Overloading
  // Here we set the first instance of the method, and below we set a second instance. We can do this because of the ability to overload
  // methods and constructors in C#, meaning we can create methods of the same name, which may serve a similar function, but will be differentiated by their
  // parameter list/signature.
  public void Reschedule(DateTime date)
  {
    _date = date;
    var printer = new MedicalAppointmentPrinter();
    printer.Print(this);
  }

  public void Reschedule(int month, int day)
  {
    _date = new DateTime(_date.Year, month, day);
    var printer = new MedicalAppointmentPrinter();
    printer.Print(this);
  }
}
/*
An alternative method to procedural programming is object-oriented programming (OOP), which is a paradigm where objects containing data
and methods play a central role.

We can define what data and methods objects of some type will contain by defining classes.

We can have any amount of objects (instances) of any class.



Some of the issues potentially faced with procedural programming are as follows:
1. We will be more likely to write spaghetti code (untidy, complicated, hard-to-follow code), which is an antipattern.
2. We have no control over who can and cannot access methods, because no methods are encapsulated within methods with levels of protection.
3. There is no separation by levels of abstraction, meaning code is much more difficult to maintain with changing requirements.
4. Logic is not easily configurable due to the complexity of the code.

Some benefits of OOP:
1. Code is modular, making it easier to resuse, maintain, and modify.
2. Code is flexible, meaning we can change its behaviour easily.
3. Code is easier to understand.
4. Code is less prone to error given how we can control how methods and data are accessed.

There are 4 fundamentals of OOP:
1. Inheritence.
2. Polymorphism.
3. Abstraction.
    Abstraction hides certain properties and methods of a class that need not be accessed outside the class.
    Users should be given an interface to operate on the type, not everything within the type as much would be irrelevant to the user.
4. Encapsulation.
    Encapsulation is binding together the data and the methods that manipulate them in a single class.
    If we have separate classes that directly manipulate fields of a class then we add unnecessary complexity to our program.
    Also, we would have to decrease the restriction level of fields, which increases the risk to our program.
    Data hiding is not the same as encapsulation. Encapsulation is the bundling of fields and methods into one class, whereas data hiding
    is increasing the protection level of fields. Often encapsulation *enables* data hiding.

An object may have fields, which are variables that specifically belong to that object of the class.
Unlike standard variables, fields do not need to be initialised to have a value. When an object is created, unless the fields are initialised,
they will be set to the default value for their type. For example, the width and height fields for Rectangle, when the parameterless constructor
is called, will be set to 0.

Data hiding is when we make the members of a class non-public, meaning not able to be directly written over from outside the class.
Class members are things such as fields and methods.
As a rule of thumb, class members should only be made public if absolutely necessary.

We can change the level of protection of a class member using access modifiers:
1. 'public' - Can be accessed anywhere.
2. 'private' - Can only be accessed from within the class the member belongs to.
3. 'protected' - Only code in the same class or in a derived class can access this type or member.
4. 'internal' - Only code in the same assembly can access this type or member. The 'currenct assembly' means the current project/code currently executing

The default access modifier for a class is 'private'.
The coding convention for naming public fields is pascal casing.
The coding convention for naming private fields is to start the name of the field with an underscore, then lower camel case

Constructors:
A constructor is a type of method called only upon the creation of an object, and may be used when we want to pass arguments to the new object.
The constructor handles these arguments passed, which may be used to initialise fields.
The only functionality a constructor should have is initialising fields, and to validate the arguments it is passed. Any other functionality would be 
considered as antipattern.

A constructor must be named the same as the class.
A constructor must have have any return type.
A constructor may only be called when the object is first initialised. It may not be called at any other point.

The default parameterless constructor is only autogenerated if we do not provide any constructor of our own.
So if we create a single constructor for Rectangle with two parameters, we are no longer able to create a rectangle with 'var myRec = new Rectangle();'
as there is no constructor for this, unless we now create our own parameterless constructor.
*/
