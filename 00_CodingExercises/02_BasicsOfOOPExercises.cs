
var myRec = new Rectangle();
System.Console.WriteLine($"Width: {myRec.width}\nHeight: {myRec.height}");
myRec.width = 3;
myRec.height = 2;
class Rectangle
{
  // These variables are the fields of the Rectangle class.
  public int Width, Height;
  public Rectangle(int w, int h)
  {
    Width = w;
    Height = h;
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
*/
