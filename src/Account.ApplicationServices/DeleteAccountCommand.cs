using MediatR;

namespace Account.ApplicationServices
{
    public record DeleteAccountCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
