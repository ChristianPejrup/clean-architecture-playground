namespace Account.Client
{
    public class NotFoundException : AccountServiceBaseException
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
