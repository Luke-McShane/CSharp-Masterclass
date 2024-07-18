
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
