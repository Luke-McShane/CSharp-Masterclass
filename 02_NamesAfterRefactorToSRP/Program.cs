// Here is an axample of a class that exploits the Single Responsible Principle, which is the first of the SOLID principles.
// The SRP states that a class should be responsible for one thing only, or a class should only have one reason to change.
// This not only makes code implementation easier and clearer, but means that future changes are going to be easier/
// the codebase will be easier to maintain, for aspects of the program will be split up appropriately/according to this principle.

var names = new Names();
var path = BuildFilePath.Build();

if (File.Exists(path))
{
  Console.WriteLine("Names file already exists. Loading names.");
  var stringsFromFile = StringRepository.Read(path);
  names.AddNames(stringsFromFile);
}
else
{
  Console.WriteLine("Names file does not yet exist.");

  //let's imagine they are given by the user
  names.AddName("John");
  names.AddName("not a valid name");
  names.AddName("Claire");
  names.AddName("123 definitely not a valid name");

  Console.WriteLine("Saving names to the file.");
  StringRepository.Write(path, names.All);
}
Console.WriteLine(string.Join(Environment.NewLine, names.All));

Console.ReadLine();

public class Names
{
  public List<string> All { get; } = new List<string>();

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

class StringRepository
{
  public static List<string> Read(string path)
  {
    var fileContents = File.ReadAllText(path);
    return fileContents.Split(Environment.NewLine).ToList();

  }
  public static void Write(string path, List<string> names) =>
      File.WriteAllText(path, string.Join(Environment.NewLine, names));
}

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

static class BuildFilePath
{
  public static string Build()
  {
    //we could imagine this is much more complicated
    //for example that path is provided by the user and validated
    return "names.txt";
  }
}