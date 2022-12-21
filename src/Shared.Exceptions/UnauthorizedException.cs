namespace Shared.Exceptions
{
    internal class UnauthorizedException : BaseException
    {
        public UnauthorizedException()
            : base ("Unauthorized access")
        {
        }
    }
}
