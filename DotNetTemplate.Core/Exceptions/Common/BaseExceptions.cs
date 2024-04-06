namespace DotNetTemplate.Core.Exceptions;

public class BaseException : Exception
{
    public int StatusCode { set; get; }
    public string ErrorMsg { set; get; }

    public BaseException() : base() { }

    public BaseException(string message, int statusCode, string errorMsg) : base(message)
    {
        this.StatusCode = statusCode;
        this.ErrorMsg = errorMsg;
    }

    public BaseException(string message, Exception innerException)
        : base(message, innerException) { }
}
