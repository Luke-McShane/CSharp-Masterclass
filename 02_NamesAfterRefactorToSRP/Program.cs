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

// A non-static class to store lists of names and add received names/lists of names to its All property.
public class Names
{
  // 'All' property will store all strings to be written to/read from the file
  public List<string> All { get; } = new List<string>();

  // Validate and add names to the All property.
  public void AddNames(List<string> names)
  {
    foreach (string name in names) { AddName(name); }
  }

  public void AddName(string name)
  {
    if (NameValidator.IsValid(name))
    {
      All.Add(name);
    }
  }
}

// This class has methods that follow, very basically, the Repository Patten, as they abstract CRUD (Create, Read, Update, Delete) operations
// away from the data entities.
static class StringRepository
{
  // The Read method returns a string and takes a list of string, whilst the Write method takes both a string and a last of strings. This
  // is consistent and clean.
  public static List<string> Read(string path)
  {
    var fileContents = File.ReadAllText(path);
    return fileContents.Split(Environment.NewLine).ToList();

  }
  public static void Write(string path, List<string> names) =>
      File.WriteAllText(path, string.Join(Environment.NewLine, names));
}

// This class simply validates a string, and needs no instance data within so can be static.
static class NameValidator
{
  static public bool IsValid(string name)
  {
    return
        name.Length >= 2 &&
        name.Length < 25 &&
        char.IsUpper(name[0]) &&
        name.All(char.IsLetter);
  }
}

// This class simply stores a method that returns the file path.
static class BuildFilePath
{
  public static string Build()
  {
    //we could imagine this is much more complicated
    //for example that path is provided by the user and validated
    return "names.txt";
  }
}