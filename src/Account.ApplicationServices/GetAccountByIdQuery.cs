using MediatR;

namespace Account.ApplicationServices
{
    public record GetAccountByIdQuery : IRequest<Domain.Account>
    {
        public Guid Id { get; init; }
    }
}
