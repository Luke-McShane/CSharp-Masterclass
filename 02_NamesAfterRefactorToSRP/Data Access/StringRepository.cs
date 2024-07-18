// Here we have a separate namespace because this logic isn't directly related to the Names class, as other classes could quite easily use
// the logic in this file. 


namespace DataAccess;

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
