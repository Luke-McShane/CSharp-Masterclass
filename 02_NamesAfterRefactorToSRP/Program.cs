// Here is an axample of a class that exploits the Single Responsible Principle, which is the first of the SOLID principles.
// The SRP states that a class should be responsible for one thing only, or a class should only have one reason to change.
// This not only makes code implementation easier and clearer, but means that future changes are going to be easier/
// the codebase will be easier to maintain, for aspects of the program will be split up appropriately/according to this principle.

var names = new Names();
var path = BuildFilePath.Build();

if (File.Exists(path))
{
  Console.WriteLine("Names file already exists. Loading names.");
  StringRepository.Read(path);
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

Console.WriteLine(string.Join(Environment.NewLine, names));

Console.ReadLine();

public class Names
{
  public List<string> All { get; } = new List<string>();
  public void AddName(string name)
  {
    if (NameValidator.IsValid(name))
    {
      All.Add(name);
    }
  }
}

static class NameValidator
{
  public static bool IsValid(string name)
  {
    return
        name.Length >= 2 &&
        name.Length < 25 &&
        char.IsUpper(name[0]) &&
        name.All(char.IsLetter);
  }
}

static class StringRepository
{
  private static readonly string Separator = Environment.NewLine;
  static public void Read(string path)
  {
    var fileContents = File.ReadAllText(path);
    List<string> namesFromFile = fileContents.Split(Separator).ToList();
  }

  static public void Write(string path, List<string> names) =>
      File.WriteAllText(path, string.Join(Separator, names));
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