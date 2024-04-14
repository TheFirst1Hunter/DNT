namespace DotNetTemplate.Core.Exceptions;

public class InvalidCredentialsExceptions : BaseException
{
    public InvalidCredentialsExceptions() : base("Invalid Username or Password", 400, "USER_NOT_FOUND") { }
}