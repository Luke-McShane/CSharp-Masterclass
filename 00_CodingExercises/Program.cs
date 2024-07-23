// PolymorphismInheritanceInterfacesExerices.Entry();
// PolymorphismPractise.Entry();
using Coding.Animal;
using Coding.StringProcessor;
var poly = new Coding.StringProcessor.Exercise();

List<string> result = poly.ProcessAll(new List<string> { "hello", "hi", "wakaka", "mcshane", "eggman", "gorilla", "wolverine", "bobcat" });

foreach (string res in result)
{
  System.Console.WriteLine(res);
}
/*
Below we have 9 lines of code that perform the same task as the single line of code above. This is because we have top-level statements
enabled in our project. All code in C# must be contained withing a class, and top level statements remove the excess code by placing
your program's entry point inside a static method within a class. This happens upon compilation and can only occur in the entry point
of the application, nowhere else.

If we define methods inside a file with top-level statements, they cannot have access modifiers, as they will by default only be accessible
from within that file.
*/

// namespace _00_CodingExercises
// {
//   internal class Program
//   {
//     public static void Main(string[] args)
//     {
//       CSharpFundementalExercises.Entry();
//     }
//   }
// }

