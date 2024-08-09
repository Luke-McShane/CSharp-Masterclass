// Here we create a custom exception which we can throw. As you can see, we add a property called StatusCode, and we handle the instances where this
// code may be passed in the constructors.
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