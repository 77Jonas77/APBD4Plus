namespace Cw11.Exceptions;

public class UnauthorizedException : Exception
{
    public UnauthorizedException(string? message) : base(message)
    {
    }
}