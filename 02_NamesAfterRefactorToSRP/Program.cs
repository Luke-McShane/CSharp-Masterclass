// Although other classes are in their own files (which is best practice), we do not need to import them because all types from
// the same namespace will be able to see each other.

// Namespaces are used to declare a scope that contains a set of related types.
// Types related to each other should be contained in the same namespace, with others in different, relevant namespaces.

using DataAccess;

// Here is an axample of a class that exploits the Single Responsible Principle, which is the first of the SOLID principles.
// The SRP states that a class should be responsible for one thing only, or a class should only have one reason to change.
// This not only makes code implementation easier and clearer, but means that future changes are going to be easier/
// the codebase will be easier to maintain, for aspects of the program will be split up appropriately/according to this principle.

// Create a new Names class. We don't want this to be static as we may want to create more Names objects in the future.
var names = new Names();

//Generate the build path.
var path = BuildFilePath.Build();

if (File.Exists(path))
{
  // Create list of names read from the filepath already generated, and add these names to the names.All property.
  Console.WriteLine("Names file already exists. Loading names.");
  var stringsFromFile = StringRepository.Read(path);
  names.AddNames(stringsFromFile);
}
else
{
  // Add various names to the names.All property. Validation will be used within the AddName method.
  Console.WriteLine("Names file does not yet exist.");

  //let's imagine they are given by the user
  names.AddName("John");
  names.AddName("not a valid name");
  names.AddName("Claire");
  names.AddName("123 definitely not a valid name");

  // After validating the names and creating the list of names, write them to the specified file.
  Console.WriteLine("Saving names to the file.");
  StringRepository.Write(path, names.All);
}

// Output the names written to/read from the file to the user.
// If we had more instances of using this .Join in a more specific way, then we could move the logic to its own method, and this
// would follow the DRY (Don't Repeat Yourself) concept. But this is not appropriate here.
Console.WriteLine(string.Join(Environment.NewLine, names.All));

Console.ReadLine();
