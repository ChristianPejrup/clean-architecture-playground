using MediatR;

namespace Account.ApplicationServices
{
    public record GetAccountByEmailQuery : IRequest<Domain.Account>
    {
        public string Email { get; init; }
    }
}
