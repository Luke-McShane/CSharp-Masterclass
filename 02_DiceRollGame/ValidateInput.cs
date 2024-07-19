class ValidateInput
{
  public static bool IsValid(string? input, out int num) => int.TryParse(input, out num);
}
