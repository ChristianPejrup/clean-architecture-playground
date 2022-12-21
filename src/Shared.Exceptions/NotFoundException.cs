namespace Shared.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException()
            : base("The requested resource could not be found") { }
    }
}
