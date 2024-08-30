using System;

namespace _05_GenericTypesAndAdvancesUseOfMethods;

public class MultipleConstraints
{
  /*
  This is an example where we can have multiple constraints spread across multiple types.
  We can separate the constraints for the same type by using a comma, and we can add another set of constraints for a type by
  simply adding a new 'where' expression.
  So here, the TPet type must derive from the Pet class, and must implement the IComparable interface, and the TOwner
  type must have a parameterless constructor defined.
  */
  public void SomeMethod<TPet, TOwner>(TPet pet, TOwner owner)
    where TPet : Pets, IComparable<TPet>
    where TOwner : new()
  {

  }
}

public class Pets { }
public class Owner { }
