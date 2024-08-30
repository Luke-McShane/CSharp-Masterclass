using System;

/*
A dictionary is an important type in C# that stores key-value pairs. We index the dictionary, not using indices, but using
the key, and the corresponding value is returned.
*/

namespace _05_GenericTypesAndAdvancesUseOfMethods;

public class Dictionaries
{
  public static void Main()
  {
    var countryToCurrencyMapping = new Dictionary<string, string>();

    countryToCurrencyMapping.Add("UK", "GBP");
    countryToCurrencyMapping.Add("Spain", "EUR");
    countryToCurrencyMapping.Add("India", "INR");
    countryToCurrencyMapping.Add("Australia", "AUD");
    countryToCurrencyMapping["USA"] = "USD";

    /// We can use "ContainsKey" to check if the dictionary contains this key.
    // if (countryToCurrencyMapping.ContainsKey("UK"))
    // {
    //   System.Console.WriteLine("The currency of the UK is: " + countryToCurrencyMapping["UK"]);
    // }


    // We can iterate through the key-value pairs of a dictionary and reference each key/value by using the Key and Value properties.
    foreach (var countryCurrencyPair in countryToCurrencyMapping)
    {
      System.Console.WriteLine($"Country: {countryCurrencyPair.Key}" +
                               $"Currency: {countryCurrencyPair.Value}");
    }


    // We can initialise dictionaries in different ways, as soon below. These both have the same effect:

    var bankAccountInfo = new Dictionary<string, int> {
      {"David", 1582},
      {"Mary", 9835},
      {"Tony", 2558},
      {"Anne", 8142},
    };

    var phoneNumbers = new Dictionary<string, float>
    {
      ["David"] = 07385274634,
      ["Mary"] = 07837452345,
      ["Tony"] = 07984557214,
      ["Anne"] = 07572478242,
    };
  }
}
