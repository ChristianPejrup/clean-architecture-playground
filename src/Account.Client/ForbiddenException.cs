namespace Account.Client
{
    public class ForbiddenException : AccountServiceBaseException
    {
        public ForbiddenException(string message) : base (message)
        {
        }
    }
}
