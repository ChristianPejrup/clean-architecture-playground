namespace Shared.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException()
            : base("The requested resource could not be found") { }

        public NotFoundException(Guid id)
            : base($"The requested resource ({id}) could not be found") { }

        public NotFoundException(string message)
            : base(message) { }

        public NotFoundException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
