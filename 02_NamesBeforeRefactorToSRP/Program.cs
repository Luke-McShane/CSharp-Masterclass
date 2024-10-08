﻿// Here is an axample of a class that exploits the Single Responsible Principle, which is the first of the SOLID principles.
// The SRP states that a class should be responsible for one thing only, or a class should only have one reason to change.
// This not only makes code implementation easier and clearer, but means that future changes are going to be easier/
// the codebase will be easier to maintain, for aspects of the program will be split up appropriately/according to this principle.

var names = new Names();
var path = names.BuildFilePath();

if (File.Exists(path))
{
  Console.WriteLine("Names file already exists. Loading names.");
  names.ReadFromTextFile();
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
  names.WriteToTextFile();
}
Console.WriteLine(names.Format());

Console.ReadLine();

public class Names
{
  private readonly List<string> _names = new List<string>();

  public void AddName(string name)
  {
    if ((name))
    {
      _names.Add(name);
    }
  }

  public void ReadFromTextFile()
  {
    var fileContents = File.ReadAllText(BuildFilePath());
    var namesFromFile = fileContents.Split(Environment.NewLine).ToList();
    foreach (var name in namesFromFile)
    {
      AddName(name);
    }
  }

  public void WriteToTextFile() =>
      File.WriteAllText(BuildFilePath(), Format());

  public string BuildFilePath()
  {
    //we could imagine this is much more complicated
    //for example that path is provided by the user and validated
    return "names.txt";
  }

  public string Format() =>
      string.Join(Environment.NewLine, _names);
}