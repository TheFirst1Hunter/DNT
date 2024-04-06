using DotNetTemplate.Data.DTOs;

namespace DotNetTemplate.Infrastructure.DTOs;

public class ErrorResponse
{
    public String Message { get; set; }
    public int StatusCode { get; set; }

    public string ErrorCode { get; set; }


    public ErrorResponse(String _message, int _statusCode, string _errorCode)
    {
        Message = _message;
        StatusCode = _statusCode;
        ErrorCode = _errorCode;
    }
}