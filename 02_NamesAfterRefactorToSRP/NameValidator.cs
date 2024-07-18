// Here is an axample of a class that exploits the Single Responsible Principle, which is the first of the SOLID principles.
// The SRP states that a class should be responsible for one thing only, or a class should only have one reason to change.
// This not only makes code implementation easier and clearer, but means that future changes are going to be easier/
// the codebase will be easier to maintain, for aspects of the program will be split up appropriately/according to this principle.

// Create a new Names class. We don't want this to be static as we may want to create more Names objects in the future.

//Generate the build path.


// Output the names written to/read from the file to the user.
// If we had more instances of using this .Join in a more specific way, then we could move the logic to its own method, and this
// would follow the DRY (Don't Repeat Yourself) concept. But this is not appropriate here.


// A non-static class to store lists of names and add received names/lists of names to its All property.
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
