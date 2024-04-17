namespace DotNetTemplate.Core.Exceptions;

public class InvalidRefreshTokenExceptions : BaseException
{
    public InvalidRefreshTokenExceptions() : base("Invalid Refresh Token", 400, "INVALID_REFRESH_TOKEN") { }
}