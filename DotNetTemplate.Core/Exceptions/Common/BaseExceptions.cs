namespace DotNetTemplate.Core.Exceptions;

public class BaseException : Exception
{
    public int StatusCode { set; get; }
    public string ErrorCode { set; get; }

    public BaseException() : base() { }

    public BaseException(string message, int statusCode, string errorCode) : base(message)
    {
        this.StatusCode = statusCode;
        this.ErrorCode = errorCode;
    }

    public BaseException(string message, Exception innerException)
        : base(message, innerException) { }
}
