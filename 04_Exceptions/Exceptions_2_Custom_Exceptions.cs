// Here we create a custom exception which we can throw. As you can see, we add a property called StatusCode, and we handle the instances where this
// code may be passed in the constructors.
// We should really think before creating a custom exception, because it is likely that one of the built-in exceptions will be able to handle the exception.
// We can create a custom exception if we want to store some data, for example. So if we have a JSON parsing exception, we can create a JSONParsingException
// that will store the JSON we were attempting to parse.
public class CustomException : Exception
{
  public int StatusCode { get; }

  public CustomException()
  {
  }

  public CustomException(int statusCode, string message) : base(message)
  {
    StatusCode = statusCode;
  }

  public CustomException(int statusCode, string message, Exception innerExcption) : base(message, innerExcption)
  {
    StatusCode = statusCode;
  }

  public CustomException(string message) : base(message)
  {
  }

  public CustomException(string message, Exception innerExcption) : base(message, innerExcption)
  {
  }
}