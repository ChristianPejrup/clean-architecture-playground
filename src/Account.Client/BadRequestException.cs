namespace Account.Client
{
    public class BadRequestException : AccountServiceBaseException
    {
        public BadRequestException(string message) : base(message)
        {
        }
    }
}
