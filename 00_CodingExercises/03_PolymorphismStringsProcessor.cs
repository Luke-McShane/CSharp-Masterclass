using System;

// Create a separate namespace for thid coding exercise
namespace Coding.StringProcessor
{
  public class Exercise
  {
    // Create a method that will take a list of strings, process them, and return a list of the processed strings
    public List<string> ProcessAll(List<string> words)
    {
      // Create a list of objects of variable type StringsProcessor
      var stringsProcessors = new List<StringsProcessor>
                {
                    new StringsTrimmingProcessor(),
                    new StringsUppercaseProcessor()
                };

      List<string> result = words;
      // Iterate through each object in the stringsProcessors list
      foreach (var stringsProcessor in stringsProcessors)
      {
        // Access each 'Process' method of each object, performing its relevant overriding method on the list of strings to be processed.
        // The order of the objects in the stringsProcessors determines which order the relevant ProcessString methods will take.
        result = stringsProcessor.Process(result);
      }
      return result;
    }
  }

  public class StringsProcessor
  {
    // Takes the 'result' parameter and operates on it depending on stringsProcessor being used.
    public List<string> Process(List<string> words)
    {
      List<string> result = new List<string>();
      foreach (string word in words)
      {
        // Calls the relevant ProcessString method, which may be a derived method.
        result.Add(ProcessString(word));

      }
      return result;
    }

    // The base method which is called if the processorString is of type StringsProcessor
    public virtual string ProcessString(string word)
    {
      return word;
    }
  }

  public class StringsUppercaseProcessor : StringsProcessor
  {
    // An overriding method that returns an uppercase version of the word
    public override string ProcessString(string word)
    {
      return word.ToUpper();
    }
  }

  public class StringsTrimmingProcessor : StringsProcessor
  {
    // An overriding method that returns the first half of the word.
    public override string ProcessString(string word)
    {
      if (word.Length >= 2)
      {
        return word.Substring(0, (word.Length / 2));
      }
      else return word;
    }
  }
}
