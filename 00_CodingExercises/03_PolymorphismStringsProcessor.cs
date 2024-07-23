using System;

namespace Coding.StringProcessor
{
  public class Exercise
  {
    public List<string> ProcessAll(List<string> words)
    {
      var stringsProcessors = new List<StringsProcessor>
                {
                    new StringsTrimmingProcessor(),
                    new StringsUppercaseProcessor()
                };

      List<string> result = words;
      foreach (var stringsProcessor in stringsProcessors)
      {
        result = stringsProcessor.Process(result);
      }
      return result;
    }
  }

  public class StringsProcessor
  {
    public List<string> Process(List<string> words)
    {
      List<string> result = new List<string>();
      foreach (string word in words)
      {
        result.Add(ProcessString(word));

      }
      return result;
    }

    public virtual string ProcessString(string word)
    {
      return word;
    }
  }

  public class StringsUppercaseProcessor : StringsProcessor
  {
    public override string ProcessString(string word)
    {
      return word.ToUpper();
    }
  }

  public class StringsTrimmingProcessor : StringsProcessor
  {
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
