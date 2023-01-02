namespace Shared.Exceptions
{
    public class UnauthorizedException : BaseException
    {
        public UnauthorizedException()
            : base ("Unauthorized access") { }

        public UnauthorizedException(string message)
            : base(message) { }

        public UnauthorizedException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
