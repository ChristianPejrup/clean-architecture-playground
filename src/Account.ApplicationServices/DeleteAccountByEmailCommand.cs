using MediatR;

namespace Account.ApplicationServices
{
    public record DeleteAccountByEmailCommand : IRequest
    {
        public string Email { get; init; }
    }
}
