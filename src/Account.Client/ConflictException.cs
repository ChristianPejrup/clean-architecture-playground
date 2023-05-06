namespace Account.Client
{
    public class ConflictException : AccountServiceBaseException
    {
        public ConflictException(string message) : base(message)
        {
        }
    }
}
