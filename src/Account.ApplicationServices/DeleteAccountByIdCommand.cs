using MediatR;

namespace Account.ApplicationServices
{
    public record DeleteAccountByIdCommand : IRequest
    {
        public Guid Id { get; init; }
    }
}
