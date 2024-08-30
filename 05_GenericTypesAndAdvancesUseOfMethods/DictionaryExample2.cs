using System;

namespace _05_GenericTypesAndAdvancesUseOfMethods
{
  public static class DictionaryExample2
  {
    public static void Main()
    {
      // Create a list of pets
      var petList = new List<Pet> {
       new Pet(PetType.Dog, 10),
       new Pet(PetType.Cat, 5),
       new Pet(PetType.Fish, 0.9),
       new Pet(PetType.Dog, 45),
       new Pet(PetType.Cat, 2),
       new Pet(PetType.Fish, 0.02)
      };

      Dictionary<PetType, double> maxWeightDict = FindMaxWeights(petList);

      // Iterate through the newly-created dictionary and print out the max weight of each animal
      foreach (var pet in maxWeightDict)
      {
        System.Console.WriteLine(pet.ToString());
      }
    }

    // Return a dictionary containing each PetType and its corresponding max weight, and take a list of pets
    public static Dictionary<PetType, double> FindMaxWeights(List<Pet> pets)
    {

      // Create a reference dictionary that will store the list of relevant pets per PetType, and will be used to iterate through to find the max weight per PetType
      var referenceDict = new Dictionary<PetType, List<Pet>>();
      // Create the result dictionary that will store the max weight per PetType
      var resultDict = new Dictionary<PetType, double>();

      // Iterate through each pet in the List<Pet> and, if the referenceDict doesn't contain this PetType, add it to the dictionary, then add the pet that corresponds to this PetType to the
      // list of pets which is the corresponding value to the key.
      foreach (var pet in pets)
      {
        if (!referenceDict.ContainsKey(pet.PetType))
        {
          referenceDict[pet.PetType] = new List<Pet>();
        }
        referenceDict[pet.PetType].Add(pet);
      }

      // Iterate through each List<Pet> for each PetType and check which is the max weight, and finally store the PetType and the max weight as a key-value pair in the dictionary we will return.
      double maxWeight = 0;
      foreach (var pet in referenceDict)
      {
        maxWeight = 0;
        foreach (var value in pet.Value)
        {
          if (value.Weight > maxWeight) maxWeight = value.Weight;
        }
        resultDict[pet.Key] = maxWeight;
      }
      return resultDict;
    }
  }

  public class Pet
  {
    public PetType PetType { get; }
    public double Weight { get; }

    public Pet(PetType petType, double weight)
    {
      PetType = petType;
      Weight = weight;
    }

    public override string ToString() => $"{PetType}, {Weight} kilos";
  }

  public enum PetType { Dog, Cat, Fish }
}